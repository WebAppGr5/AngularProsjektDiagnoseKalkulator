import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(private http: HttpClient) {
 
  }
  erInnlogget: boolean = false;
  error: boolean = false;

  ngOnInit() {
    this.sjekkErInnlogget();
  }

  sjekkErInnlogget() {

    const url = "Login/erInnlogget/";
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    this.http.get<boolean>(url, { 'headers': headers }).subscribe((res) => {
      this.error = false;
      this.erInnlogget = res;

    }, (err) => { this.error = true; this.erInnlogget = false; });
  }
  
}
