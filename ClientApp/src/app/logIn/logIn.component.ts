import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { BrukerLogin } from '../../models/BrukerLogin';

@Component({
  selector: 'logIn-home',
  templateUrl: './logIn.component.html',
})
export class logInComponent{
  logInSkjema: FormGroup;
  error: boolean = false;

  innloggingFeil: boolean = false;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.logInSkjema = fb.group({
      brukernavn: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(4)
      ])],
      passord: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(8)
      ])]
    });
  }
  /**
   * Logger inn bruker
   * */
  LoggInn() {
    if (this.logInSkjema.valid) {
      const headers = { 'content-type': 'application/json; charset=utf-8' };
      const brukerLogin = new BrukerLogin(this.logInSkjema.value.brukernavn, this.logInSkjema.value.passord);
      
      const url = "Login/loggInn/";
      this.http.post<boolean>(url, brukerLogin, { 'headers': headers }).subscribe((res) => {
        if (res == true) {
          this.innloggingFeil = false;

          window.location.reload();
        }
        else {
          this.innloggingFeil = true;

        }

        this.error = false;
      }, (err) => { this.error = true; this.innloggingFeil = false;  });
    }
  }
}
