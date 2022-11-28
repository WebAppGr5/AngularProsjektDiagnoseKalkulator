import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DiagnoseCreateDTO } from '../../models/DiagnoseCreateDTO';
import { DiagnoseDetailModel } from '../../models/DiagnoseDetailModel';
import { SymptomDTO } from '../../models/SymptomDTO';
import { SymptomGruppeListModel } from '../../models/SymptomGruppeListModel';
import { SymptomListModel } from '../../models/SymptomListModel';

@Component({
  selector: 'app-infoApp',
  templateUrl: './infoApp.component.html',
})
export class InfoAppComponent {
 
}
