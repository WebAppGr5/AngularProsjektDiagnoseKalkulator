import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu-user',
  templateUrl: './nav-menu-user.component.html',
  styleUrls: ['./nav-menu-user.component.css']
})
export class NavMenuUserComponent {
  isExpanded = false;
  error: boolean = false;
  collapse() {
    this.isExpanded = false;
  }
  constructor(private http: HttpClient) { }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  /**
   * Logger av brukeren
   * */
  logout() {

    const url = "Login/loggUt/";
    const headers = { 'content-type': 'application/json; charset=utf-8' };
    this.http.get<boolean>(url, { 'headers': headers }).subscribe((res) => {
      this.error = false;
      window.location.reload();

    }, (err) => { this.error = true;  });
  }
}
