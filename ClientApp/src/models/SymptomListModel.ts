export class SymptomListModel {
  symptomGruppeId: Number;
  navn: String;
  beskrivelse: String;
  symptomId: Number;


  doHave: boolean = false;
  varighetsValg: Number = 0;

  constructor(navn: String, beskrivelse: String, symptomGruppeId: Number, symptomId: Number) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.symptomGruppeId = symptomGruppeId;
    this.symptomGruppeId = symptomGruppeId;
    this.symptomId = symptomId;
  }

}
