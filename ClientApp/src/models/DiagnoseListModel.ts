export class DiagnoseListModel {
  diagnoseId: Number;
  navn: String;
  beskrivelse: String;

  constructor(navn: String, beskrivelse: String, dypForklaring: String, diagnoseId: Number) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.diagnoseId = diagnoseId;

  }

}
