export class SymptomGruppeListModel {
  symptomGruppeId: Number;
  navn: String;
  beskrivelse: String;

  hidden: boolean = true;

  constructor(navn: String, beskrivelse: String, symptomGruppeId: Number) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.symptomGruppeId = symptomGruppeId;

  }

}
