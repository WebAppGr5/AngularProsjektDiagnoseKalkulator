import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DiagnoseDetailModel } from '../../models/DiagnoseDetailModel';
import { DiagnoseListModel } from '../../models/DiagnoseListModel';

@Component({
  selector: 'app-listDiagnoser',
  templateUrl: './listDiagnoser.component.html',
})
export class ListDiagnoserComponent {
  id: Number | undefined;

  diagnoser: DiagnoseListModel[] | undefined;

  error: boolean = false;
  harSlettet: boolean = false;
  erInnlogget: boolean = false;
  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {

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
    this.hentDiagnoser();
  }
  hentDiagnoser() {
    const headers = { 'content-type': 'application/json; charset=utf-8' };


    const url = "Diagnose/getDiagnoser/";
    this.http.get<DiagnoseListModel[]>(url, { 'headers': headers }).subscribe((res) => {
      this.diagnoser = res;
      this.error = false;
    }, (err) => { this.error = true; });
  }

  forgetDiagnose(diagnoseId: Number) {
    const url = "Diagnose/forgetDiagnose/" + String(diagnoseId);
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    this.http.get<any>(url, { 'headers': headers }).subscribe((res) => {
      this.error = false;
      this.harSlettet = true;
       this.hentDiagnoser();
    }, (err) => { this.error = true; });
  }
}
