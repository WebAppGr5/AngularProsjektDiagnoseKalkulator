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
  endreSchema: FormGroup;

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
      this.endreSchema.value.navn = res.navn;
      this.endreSchema.value.beskrivelse = res.beskrivelse;
      this.endreSchema.value.diagnoseId = res.diagnoseId;
      this.endreSchema.value.dypForklaring = res.dypForklaring;
    });
  }

  utforEndring() {
    if (this.endreSchema.valid) {
      const diagnoseChangeDTO = new DiagnoseChangeDTO(this.endreSchema.value.navn, this.endreSchema.value.beskrivelse, this.endreSchema.value.dypForklaring, this.endreSchema.value.diagnoseId);
      const headers = { 'content-type': 'application/json; charset=utf-8' };
      const data = JSON.stringify(diagnoseChangeDTO);

      const url = "Diagnose/Update/";
      this.http.put(url, data, {'headers':headers}).subscribe((res) => {
   
      });

    }
  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      
      if (params.id != null) {
        this.id = params.id;
        this.getDiagnose(Number(this.id));
      }

    })


  }
}
