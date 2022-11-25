import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-lagre',
  templateUrl: './lagre.component.html',
})
export class LagreComponent {
  id: Number | undefined;

  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

  }
}
