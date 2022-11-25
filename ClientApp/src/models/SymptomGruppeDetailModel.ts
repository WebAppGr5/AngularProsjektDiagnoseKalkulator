export class SymptomGruppeDetailModel {
  symptomGruppeId: Number;
  navn: String;
  beskrivelse: String;
  dypForklaring: String;

  constructor(navn: String, beskrivelse: String, dypForklaring: String, symptomGruppeId: Number) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.symptomGruppeId = symptomGruppeId;
    this.dypForklaring = dypForklaring;
  }

}
