import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';
import { DiagnoseChangeDTO } from '../../models/DiagnoseChangeDTO';


import { DiagnoseDetailModel } from '../../models/DiagnoseDetailModel';

@Component({
  selector: 'app-endre',
  templateUrl: './endre.component.html',
})
export class EndreComponent {

  public id: Number | undefined;
  harEndret: boolean = false;
  error: boolean = false;
  endreSchema: FormGroup;
  erInnlogget: boolean = false;
  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
    this.endreSchema = fb.group({

      navn: [null, Validators.compose([
        Validators.required,
        Validators.pattern(/^[a-zA-ZÆØÅæøå0-9\s-]{3,40}$/),
      ])],
      beskrivelse: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(700)
      ])],
      diagnoseId: ["", Validators.compose([
        Validators.pattern(/^[0-9]{1,6}$/)
      ])],
      dypForklaring: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(5000)
      ])]
    });
  }

  /**
   *
   * Henter en diagnose
   * @param id Diagnosen en skal hente
   */
  getDiagnose(id: Number) {
    if (id == null)
      return;
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    const url = "Diagnose/hentDiagnoseGittDiagnoseId/" + String(id);
    this.http.get<DiagnoseDetailModel>(url, { 'headers': headers }).subscribe((res) => {

      this.endreSchema.setValue({
        navn: String(res.navn),
        beskrivelse: String(res.beskrivelse),
        diagnoseId: Number(res.diagnoseId),
        dypForklaring: String(res.dypForklaring)

      });

    });
  }
  /**
   * Sjekker om en er logget inn
   * */
  sjekkErInnlogget() {

    const url = "Login/erInnlogget/";
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    this.http.get<boolean>(url, { 'headers': headers }).subscribe((res) => {
      this.error = false;
      this.erInnlogget = res;

    }, (err) => { this.error = true; this.erInnlogget = false; });
  }
  /**
   * Endrer en diagnose
   * */
  utforEndring() {
    if (this.endreSchema.valid) {
      const diagnoseChangeDTO = new DiagnoseChangeDTO(this.endreSchema.value.navn, this.endreSchema.value.beskrivelse, this.endreSchema.value.dypForklaring, this.endreSchema.value.diagnoseId);
      const headers = { 'content-type': 'application/json; charset=utf-8' };
      const data = JSON.stringify(diagnoseChangeDTO);

      const url = "Diagnose/Update/";
      this.http.put<any>(url, data, { 'headers': headers }).subscribe((res) => {
        this.error = false;
        this.harEndret = true;

      }, (err) => { this.error = true; });

    }
  }
  ngOnInit() {
    this.sjekkErInnlogget();
    this.route.params.subscribe(params => {
      
      if (params.id != null) {
        this.id = params.id;
        this.getDiagnose(Number(this.id));
      }

    })


  }
}
