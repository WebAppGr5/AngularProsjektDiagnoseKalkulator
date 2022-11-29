import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DiagnoseCreateDTO } from '../../models/DiagnoseCreateDTO';
import { DiagnoseDetailModel } from '../../models/DiagnoseDetailModel';
import { SymptomDTO } from '../../models/SymptomDTO';
import { SymptomGruppeListModel } from '../../models/SymptomGruppeListModel';
import { SymptomListModel } from '../../models/SymptomListModel';

@Component({
  selector: 'app-lagre',
  templateUrl: './lagre.component.html',
})
export class LagreComponent {
  id: Number | undefined;
  lageSchema: FormGroup;
  diagnose: DiagnoseDetailModel | undefined;
  symptomGrupper: SymptomGruppeListModel[] | undefined;
  harLagret: boolean = false;
  error: boolean = false;
  symptomerMap: Map<Number, SymptomListModel[]>
  erInnlogget: boolean = false;
  symptomGruppeMap: Map<Number, SymptomGruppeListModel> | undefined;

  optionsVarigheter: String[] = ["--", "1-3 dager", "Flere dager", "1-3 måneder", "Flere måneder", "1-3 år", "Flere år"];


  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
    this.symptomerMap = new Map<Number, SymptomListModel[]>();
    this.symptomGruppeMap = new Map<Number, SymptomGruppeListModel>();
    this.lageSchema = fb.group({

      navn: ["", Validators.compose([
        Validators.required,
        Validators.pattern(/^[a-zA-ZÆØÅæøå0-9\s-]{3,40}$/),
      ])],
      beskrivelse: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(700)
      ])],
      dypForklaring: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(5000)
      ])]
    });
  }

 

  doSetOption(symptomGruppeId: Number, symptomId: Number, event: any) {

    if (event && event.target && event.target.options) {
      if (this.symptomerMap) {
        const symptomer = this.symptomerMap.get(Number(symptomGruppeId));
        if (symptomer) {
          const symptomListModel = symptomer.filter((x) => x.symptomId == symptomId)[0];
          const varighetsValg = event.target.options.selectedIndex
          symptomListModel.varighetsValg = varighetsValg;
        }


      }
    }
  }
  sjekkErInnlogget() {

    const url = "Login/erInnlogget/";
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    this.http.get<boolean>(url, { 'headers': headers }).subscribe((res) => {
      this.error = false;
      this.erInnlogget = res;

    }, (err) => { this.error = true; this.erInnlogget = false; });
  }
  ngOnInit() {
    this.sjekkErInnlogget();
    this.hentSymptomGrupper();
  }

  hentSymptomer(symptomGruppeId: Number) {
    const headers = { 'content-type': 'application/json; charset=utf-8' };


    const url = "Diagnose/getSymptomerGittGruppeId/" + String(symptomGruppeId);
    this.http.get<SymptomListModel[]>(url, { 'headers': headers }).subscribe((res) => {
      this.symptomerMap.set(symptomGruppeId, res);
      this.error = false;
    }, (err) => { this.error = true; });
  }
  toggleKategori(symptomGruppeId: Number) {

    if (this.symptomGruppeMap) {
      const symptomGruppeListModel = this.symptomGruppeMap.get(Number(symptomGruppeId));
      const symptomer = this.symptomerMap.get(Number(symptomGruppeId));
      //Når en legger closer, så har en ikke valgt noen av disse symtomene
      if (symptomer) {
        symptomer.forEach((symptom) => {
          symptom.doHave = false;
          symptom.varighetsValg = 0;
        });
      }
      if (symptomGruppeListModel) {
        if (symptomGruppeListModel.doShow)
          symptomGruppeListModel.doShow = false;
        else
          symptomGruppeListModel.doShow = true;
      }
    }

  }
  toggleSelectList(symptomGruppeId: Number, symptomId: Number) {
    if (this.symptomerMap) {
      const symptomer = this.symptomerMap.get(Number(symptomGruppeId));
      if (symptomer) {
        const symptomListModel = symptomer.filter((x) => x.symptomId == symptomId)[0];
        if (symptomListModel) {
          symptomListModel.varighetsValg = 0;
          if (symptomListModel.doHave)
            symptomListModel.doHave = false;
          else
            symptomListModel.doHave = true;
        }
      }

    }
  }
  lagre() {
    if (this.lageSchema.valid) {
      const SymptomListModelListe: SymptomListModel[] = this.hentSymptomerEnHar();



      if (SymptomListModelListe) {

        const symptomIdListe: Number[] = new Array<Number>();
        const varighetListe: Number[] = new Array<Number>();

        SymptomListModelListe.forEach((symptom) => {
          symptomIdListe.push(symptom.symptomId);
          varighetListe.push(symptom.varighetsValg);
        });

        const headers = { 'content-type': 'application/json; charset=utf-8' };
        const diagnoseCreateDTO: DiagnoseCreateDTO = new DiagnoseCreateDTO(this.lageSchema.value.navn, this.lageSchema.value.beskrivelse, this.lageSchema.value.dypForklaring, symptomIdListe, varighetListe);
        const data = JSON.stringify(diagnoseCreateDTO);

        const url = "Diagnose/nyDiagnose/";
        this.http.post<any>(url, data, { 'headers': headers }).subscribe((res) => {
          this.error = false;
          this.harLagret = true;

        }, (err) => { this.error = true; });
      }
    }
    
  }
  hentSymptomerEnHar(): SymptomListModel[] {

    const symptomIdListe: Number[] = new Array<Number>();

    const SymptomListModelListe = new Array<SymptomListModel>();
    this.symptomerMap.forEach((symptomListe: SymptomListModel[]) => {
      symptomListe.forEach((symptom: SymptomListModel) => {
        if (symptom.doHave) {
          //Kan hende samme symptom er i flere symptomgrupper
          if (!symptomIdListe.includes(symptom.symptomId)) {
            symptomIdListe.push(symptom.symptomId);
            SymptomListModelListe.push(symptom);


          }
        };
      });
    });

    return SymptomListModelListe;
  }
  hentSymptomGrupper() {
    const headers = { 'content-type': 'application/json; charset=utf-8' };


    const url = "Diagnose/getSymptomGrupper/";
    this.http.get<SymptomGruppeListModel[]>(url, { 'headers': headers }).subscribe((res) => {
      this.symptomGrupper = res;
      this.error = false;

      this.symptomGrupper.forEach((symptomGruppe) => {
        if (symptomGruppe && this.symptomGruppeMap) {
          this.hentSymptomer(symptomGruppe.symptomGruppeId)
          this.symptomGruppeMap.set(Number(symptomGruppe.symptomGruppeId), symptomGruppe);
        }

      });
    }, (err) => { this.error = true; });
  }
}
