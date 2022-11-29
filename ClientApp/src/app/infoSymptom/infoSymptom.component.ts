import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SymptomDetailModel } from '../../models/SymptomDetailModel';

@Component({
  selector: 'app-infoSymptom',
  templateUrl: './infoSymptom.component.html',
})
export class InfoSymptomComponent {
  public id: Number | undefined;
  symptom: SymptomDetailModel | undefined;
  error: boolean = false;

  /**
   *
   * Henter et symptom
   * @param id Symptomet en henter
   */
  getSymptom(id: Number) {
    if (id == null)
      return;
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    const url = "Diagnose/hentSymptomGittSymptomId/" + String(id);
    this.http.get<SymptomDetailModel>(url, { 'headers': headers }).subscribe((res) => {
      this.symptom = res;
      this.error = false;
    }, (err) => { this.error = true; });
  }
  constructor(private http: HttpClient,  private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.getSymptom(Number(this.id));
})
  }
}
