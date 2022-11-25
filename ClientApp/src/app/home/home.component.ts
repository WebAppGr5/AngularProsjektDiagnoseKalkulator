import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SymptomGruppeListModel } from '../../models/SymptomGruppeListModel';
import { SymptomListModel } from '../../models/SymptomListModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  symptomGrupper: SymptomGruppeListModel[] | undefined;
  //Alternativ 1... motta symptomgrupper, og bruk map for å finne tilhørende symptomer
  symptomer: Map<Number, SymptomListModel[]>

  //Alternativ 2: hent alle symptomer, og plasser dem i riktig kategori før en printer ut.
  symptomerAlt2: SymptomListModel[] | undefined;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.symptomer = new Map<Number, SymptomListModel[]>();
    //this.symptomer.set(1, ...)
    //liste: SymptomListModel[] = this.symptomer.get(...);
  }


   
}
