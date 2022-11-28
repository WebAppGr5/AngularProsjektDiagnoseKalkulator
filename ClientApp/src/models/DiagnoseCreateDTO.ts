export class DiagnoseCreateDTO {

  navn: String;
  beskrivelse: String;
  dypForklaring: String;
  symptomer: Number[];
  varigheter: Number[];

  constructor(navn: String, beskrivelse: String, dypForklaring: String,  symptomer : Number[], varigheter : Number[]) {
    this.navn = navn;
    this.beskrivelse = beskrivelse;
    this.dypForklaring = dypForklaring;
    this.symptomer = symptomer;
    this.varigheter = varigheter;
  }

}
