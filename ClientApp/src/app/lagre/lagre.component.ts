import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DiagnoseDetailModel } from '../../models/DiagnoseDetailModel';

@Component({
  selector: 'app-lagre',
  templateUrl: './lagre.component.html',
})
export class LagreComponent {
  id: Number | undefined;
  lageSchema: FormGroup;
  diagnose: DiagnoseDetailModel | undefined;

  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
    this.lageSchema = fb.group({

      navn: ["", Validators.compose([
        Validators.required,
        Validators.pattern(/^[a-zA-Z0-9\s-]{3,40}$/),
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

  }
}
