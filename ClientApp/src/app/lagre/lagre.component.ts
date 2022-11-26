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
