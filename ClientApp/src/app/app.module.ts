import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { ListDiagnoserComponent } from './diagnoseListe/listdiagnoser.component';
import { logInComponent } from './logIn/logIn.component';

import { Component } from '@angular/core';
import { InfoAppComponent } from './informasjon om appen/infoApp.component';
import { NavMenuUserComponent } from './nav-menu-user/nav-menu-user.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    logInComponent,
    EndreComponent,
    LagreComponent,
    InfoSymptomGruppeComponent,
    InfoSymptomComponent,
    NavMenuUserComponent,
    InfoDiagnoseComponent,
    InfoAppComponent,
    ListDiagnoserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,

    RouterModule.forRoot([
      { path: '', component: logInComponent, pathMatch: 'full' },
      { path: 'login', component: logInComponent, pathMatch: 'full' },
      { path: 'endre/:id', component: EndreComponent, pathMatch: 'full' },
      { path: 'lagre', component: LagreComponent, pathMatch: 'full' },
      { path: 'infoSymptomGruppe/:id', component: InfoSymptomGruppeComponent, pathMatch: 'prefix' },
      { path: 'infoSymptom/:id', component: InfoSymptomComponent, pathMatch: 'prefix' },
      { path: 'infoDiagnose/:id', component: InfoDiagnoseComponent, pathMatch: 'prefix' },
      { path: 'listDiagnoser', component: ListDiagnoserComponent, pathMatch: 'prefix' },
      { path: 'home', component: HomeComponent, pathMatch: 'prefix' },
      { path: 'infoApp', component: InfoAppComponent, pathMatch: 'prefix' }

      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
