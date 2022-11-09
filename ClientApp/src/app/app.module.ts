import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EndreComponent } from './endre/endre.component';
import { LagreComponent } from './lagre/lagre.component';
import { InfoSymptomGruppeComponent } from './infoSymptomGruppe/infoSymptomGruppe.component';
import { InfoSymptomComponent } from './infoSymptom/infoSymptom.component';
import { InfoDiagnoseComponent } from './infoDiagnose/infoDiagnose.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EndreComponent,
    LagreComponent,
    InfoSymptomGruppeComponent,
    InfoSymptomComponent,
    InfoDiagnoseComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'endre', component: EndreComponent, pathMatch: 'full' },
      { path: 'lagre', component: LagreComponent, pathMatch: 'full' },
      { path: 'infoSymptomGruppe', component: InfoSymptomGruppeComponent, pathMatch: 'prefix' },
      { path: 'infoSymptom', component: InfoSymptomComponent, pathMatch: 'prefix' },
      { path: 'infoDiagnose', component: InfoDiagnoseComponent, pathMatch: 'prefix' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
