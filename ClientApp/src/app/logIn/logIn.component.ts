import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-LogIn',
  templateUrl: './logIn.component.html',
})
export class logInComponent {
  logInSkjema: FormGroup;
  constructor(private fb: FormBuilder) {
    this.logInSkjema = fb.group({
      bruker: ["", Validators.required],
      passord: ["", Validators.pattern("[0-9a-zA-Z]{8,20}")]
    });
  }

  onSubmit() {
    console.log("Bruker logget:");
    console.log(this.logInSkjema);
    console.log(this.logInSkjema.value.bruker);
    console.log(this.logInSkjema.touched);
  }
}
