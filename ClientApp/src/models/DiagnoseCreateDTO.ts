export class DiagnoseCreateDTO {
  diagnoseId: Number;
  navn: String;
  beskrivelse: String;
  dypForklaring: String;
  symptomer: Number[];
  varigheter: Number[];

  constructor(navn: String, beskrivelse: String, dypForklaring: String, diagnoseId: Number, symptomer : Number[], varigheter : Number[]) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.diagnoseId = diagnoseId;
    this.dypForklaring = dypForklaring;
    this.symptomer = symptomer;
    this.varigheter = varigheter;
  }

}
