import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators, FormBuilder} from '@angular/forms';
import {LagreComponent} from 'lagre.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'App';
}

export class logInComponent{
  title = 'login-app';
  Skjema: Formgroup;

  constructor(private fb: FormBuilder){
  this.skjema = fb.group({
    brukernavn: ["", Validators.required],
    passord: ["", Validators.pattern("[0-9A-Za-z]{6,30}")]
  )};
  }

 onSubmit(){
  console.log("Innloggings skjema levert":);
  console.log(this.skjema);
  console.log(this.skjema.value.brukernavn);
  console.log(this.skjema.value.touched);
  }
}
export class home-component{
  title = 'symptomer';
  SymptSkjema: FormGroup;
  constructor(private fb: Formbuilder){
  this.symptSkjema = fb.group({
    symptomListe = new list<symptomer>;
    if (symptom.doHave=true){
      symptomListe.add(symptom.ID, symptom.varighet);
    }
    return symptomListe;
  });
  onChange(){
  console.log("Symptomene krysset av er:");
  console.log(this.symptSkjema);
  console.log(this.symptSkjema.symptomListe);
  console.log(this.skjema.value.touched);
  }
}
