import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DiagnoseDetailModel } from '../../models/DiagnoseDetailModel';

@Component({
  selector: 'app-infoDiagnose',
  templateUrl: './infoDiagnose.component.html',
})
export class InfoDiagnoseComponent {
  public id: Number | undefined;
  diagnose: DiagnoseDetailModel | undefined;
  public fromPage: String = "listDiagnoser";

  getDiagnose(id: Number) {
    if (id == null)
      return;
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    const url = "Diagnose/hentDiagnoseGittDiagnoseId/" + String(id);
    this.http.get<DiagnoseDetailModel>(url, { 'headers': headers }).subscribe((res) => {
      this.diagnose = res;

    });
  }
  constructor(private http: HttpClient,  private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.fromPage = params.fromPage;
      this.getDiagnose(Number(this.id));
    })
  }
}
