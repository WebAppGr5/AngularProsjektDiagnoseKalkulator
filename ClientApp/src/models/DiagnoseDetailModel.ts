export class DiagnoseDetailModel {
  diagnoseId: Number;
  navn: String;
  beskrivelse: String;
  dypForklaring: String;

  constructor(navn: String, beskrivelse: String, dypForklaring: String, diagnoseId: Number) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.diagnoseId = diagnoseId;
    this.dypForklaring = dypForklaring;
  }

}
