import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SymptomGruppeDetailModel } from '../../models/SymptomGruppeDetailModel';

@Component({
  selector: 'app-infoSymptomGruppe',
  templateUrl: './infoSymptomGruppe.component.html',
})
export class InfoSymptomGruppeComponent {
  public id: Number | undefined;
  public symptomGruppe: SymptomGruppeDetailModel | undefined;

  getSymptomGruppe(id: Number) {
    if (id == null)
      return;
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    const url = "Diagnose/hentSymptomGruppeGittSymptomGruppeId/" + String(id);
    this.http.get<SymptomGruppeDetailModel>(url, { 'headers': headers }).subscribe((res) => {
      this.symptomGruppe = res;

    });
  }
  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.getSymptomGruppe(Number(this.id));

    })
  }
}
