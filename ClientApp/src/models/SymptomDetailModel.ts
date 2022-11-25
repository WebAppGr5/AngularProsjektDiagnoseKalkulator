export class SymptomDetailModel {
  symptomGruppeId: Number;
  navn: String;
  beskrivelse: String;
  dypForklaring: String;
  symptomId: Number;

  constructor(navn: String, beskrivelse: String, dypForklaring: String, symptomGruppeId: Number, symptomId : Number) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.symptomGruppeId = symptomGruppeId;
    this.dypForklaring = dypForklaring;
    this.symptomGruppeId = symptomGruppeId;
    this.symptomId = symptomId;
  }

}
