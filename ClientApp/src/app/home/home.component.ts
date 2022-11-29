import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DiagnoseListModel } from '../../models/DiagnoseListModel';
import { SymptomDTO } from '../../models/SymptomDTO';
import { SymptomGruppeListModel } from '../../models/SymptomGruppeListModel';
import { SymptomListModel } from '../../models/SymptomListModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {


  symptomGrupper: SymptomGruppeListModel[] | undefined;
  error: boolean = false;
  harKalkulert: boolean = false;
  symptomerMap: Map<Number, SymptomListModel[]>
  diagnoser: DiagnoseListModel[] | undefined;
  symptomGruppeMap: Map<Number, SymptomGruppeListModel> | undefined;

  optionsVarigheter: String[] = ["--", "1-3 dager", "Flere dager", "1-3 måneder", "Flere måneder", "1-3 år", "Flere år"];

  constructor(private http: HttpClient, private route: ActivatedRoute, private fb: FormBuilder, private router: Router) {
    this.symptomerMap = new Map<Number, SymptomListModel[]>();
    this.symptomGruppeMap = new Map<Number, SymptomGruppeListModel>();

  }

  ngOnInit() {
    this.hentSymptomGrupper();
  }
  /**
   * Henter symptomer
   * @param symptomGruppeId Symptomgruppen til disse symptomene 
   */
  hentSymptomer(symptomGruppeId: Number) {
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    

    const url = "Diagnose/getSymptomerGittGruppeId/" + String(symptomGruppeId);
    this.http.get<SymptomListModel[]>(url, { 'headers': headers }).subscribe((res) => {
      this.symptomerMap.set(Number(symptomGruppeId), res);
      this.error = false;
    }, (err) => { this.error = true; });
  }
  /**
   * Gjør listen over symptomer synlig/usynlig
   * 
   * @param symptomGruppeId Hvilke liste over symptomer en snakker om
   */
  toggleKategori(symptomGruppeId: Number) {

    if (this.symptomGruppeMap) {
      const symptomGruppeListModel = this.symptomGruppeMap.get(Number(symptomGruppeId));
      const symptomer = this.symptomerMap.get(Number(symptomGruppeId));

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
  /**
   * Endrer hvorvidt en har dette symptomet
   * 
   * @param symptomGruppeId Hvilke symptomgruppe symptomet ligger i - for å søke etter symptomet 
   * @param symptomId Hvilke symptom en snakker om, og skal påvirke
   * @param event Referanse til all dataene assosiert med det en trykket på
   */
  doSetOption(symptomGruppeId: Number, symptomId: Number, event: any) {

    if (event && event.target && event.target.options) {
      if (this.symptomerMap) {
        const symptomer = this.symptomerMap.get(Number(symptomGruppeId));
        if (symptomer) {
          const symptomListModel = symptomer.filter((x) => x.symptomId == symptomId)[0];
          const varighetsValg = event.target.options.selectedIndex
          symptomListModel.varighetsValg = varighetsValg;
          const symptomDTOListe: SymptomDTO[] = this.hentSymptomerEnHar();
          this.utforKalkulering(symptomDTOListe);
        }


      }
    }
  }
  /**
   * Finn hvilke diagnoser en har gitt symptomer og tilhørende varigheter
   * @param symptomDTOListe Liste over symptomer en har, og tilhørende varigheter. SymptomDto består av et varighetsvalg og en symptomId
   */
  utforKalkulering(symptomDTOListe: SymptomDTO[]) {
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    const url = "Diagnose/getDiagnoserGittSymptomer/";
    this.http.post<DiagnoseListModel[]>(url, JSON.stringify(symptomDTOListe), { 'headers': headers }).subscribe((res) => {
      this.diagnoser = res;
      this.error = false;
    }, (err) => { this.error = true; });
  }
  /**
   * Hvor vidt en skal vise selectlisten assosiert med et symptom
   * @param symptomGruppeId Hvilke symptom gruppe symptomet en letter etter er 
   * @param symptomId Symptomet en leter etter
   */ 
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
          const symptomDTOListe: SymptomDTO[] = this.hentSymptomerEnHar();
          this.utforKalkulering(symptomDTOListe);
        }
      }

    }
  }
  /**
   * Liste over symptomer en har, med tilhørende varigheter
   * */
  hentSymptomerEnHar(): SymptomDTO[] {

    const symptomIdListe: Number[] = new Array<Number>();

    const symptomDTOListe = new Array<SymptomDTO>();
    this.symptomerMap.forEach((symptomListe: SymptomListModel[]) => {
      symptomListe.forEach((symptom: SymptomListModel) => {
        if (symptom.doHave) {
          //Kan hende samme symptom er i flere symptomgrupper
          if (!symptomIdListe.includes(symptom.symptomId)) {
            symptomIdListe.push(symptom.symptomId);
            symptomDTOListe.push(new SymptomDTO(symptom.symptomId, symptom.varighetsValg));


          }
        };
      });
    });

    return symptomDTOListe;
  }
  /**
   * Henter liste over symtpom grupper
   * */
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
