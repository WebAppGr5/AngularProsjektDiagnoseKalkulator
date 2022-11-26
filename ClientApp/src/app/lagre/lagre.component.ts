import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DiagnoseDetailModel } from '../../models/DiagnoseDetailModel';
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

  symptomerMap: Map<Number, SymptomListModel[]>

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

  ngOnInit() {
    this.hentSymptomGrupper();
  }

  hentSymptomer(symptomGruppeId: Number) {
    const headers = { 'content-type': 'application/json; charset=utf-8' };


    const url = "Diagnose/getSymptomerGittGruppeId/" + String(symptomGruppeId);
    this.http.get<SymptomListModel[]>(url, { 'headers': headers }).subscribe((res) => {
      this.symptomerMap.set(symptomGruppeId, res);
    });
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
        if (symptomGruppeListModel.hidden)
          symptomGruppeListModel.hidden = false;
        else
          symptomGruppeListModel.hidden = true;
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

  hentSymptomGrupper() {
    const headers = { 'content-type': 'application/json; charset=utf-8' };


    const url = "Diagnose/getSymptomGrupper/";
    this.http.get<SymptomGruppeListModel[]>(url, { 'headers': headers }).subscribe((res) => {
      this.symptomGrupper = res;


      this.symptomGrupper.forEach((symptomGruppe) => {
        if (symptomGruppe && this.symptomGruppeMap) {
          this.hentSymptomer(symptomGruppe.symptomGruppeId)
          this.symptomGruppeMap.set(Number(symptomGruppe.symptomGruppeId), symptomGruppe);
        }

      });
    });
  }
}
