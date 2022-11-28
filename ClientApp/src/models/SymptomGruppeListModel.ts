export class SymptomGruppeListModel {
  symptomGruppeId: Number;
  navn: String;
  beskrivelse: String;

  doShow: boolean = false;

  constructor(navn: String, beskrivelse: String, symptomGruppeId: Number) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.symptomGruppeId = symptomGruppeId;

  }

}
