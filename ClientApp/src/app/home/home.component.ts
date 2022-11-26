import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SymptomGruppeListModel } from '../../models/SymptomGruppeListModel';
import { SymptomListModel } from '../../models/SymptomListModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {


  symptomGrupper: SymptomGruppeListModel[] | undefined;

  symptomerMap: Map<Number, SymptomListModel[]>

  symptomGruppeMap: Map<Number, SymptomGruppeListModel> | undefined;

  constructor(private http: HttpClient, private route: ActivatedRoute, private fb: FormBuilder, private router: Router) {
    this.symptomerMap = new Map<Number, SymptomListModel[]>();
    this.symptomGruppeMap = new Map<Number, SymptomGruppeListModel>();

  }

  ngOnInit() {
    this.hentSymptomGrupper();
  }
  hentSymptomer(symptomGruppeId: Number) {
    const headers = { 'content-type': 'application/json; charset=utf-8' };


    const url = "Diagnose/getSymptomerGittGruppeId/" + String(symptomGruppeId);
    this.http.get<SymptomListModel[]>(url, { 'headers': headers }).subscribe((res) => {
      this.symptomerMap.set(Number(symptomGruppeId), res);
    });
  }
  toggleKategori(symptomGruppeId: Number) {

    if (this.symptomGruppeMap) {
      const symptomGruppeListModel = this.symptomGruppeMap.get(Number(symptomGruppeId));
      if (symptomGruppeListModel) {
        if (symptomGruppeListModel.hidden)
          symptomGruppeListModel.hidden = false;
        else
          symptomGruppeListModel.hidden = true;
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
