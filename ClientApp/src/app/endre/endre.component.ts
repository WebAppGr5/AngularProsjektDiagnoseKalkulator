import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-endre',
  templateUrl: './endre.component.html',
})
export class EndreComponent {

  public id: Number | undefined;

  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute, private router : Router) { }
 
  ngOnInit() {
    this.route.params.subscribe(params => {this.id = params.id })
  }
}
