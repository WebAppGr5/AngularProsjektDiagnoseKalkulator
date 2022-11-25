import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-endre',
  templateUrl: './endre.component.html',
})
export class EndreComponent {

  public id: Number | undefined;
  endreSchema: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
    this.endreSchema = fb.group({

      navn: [null, Validators.compose([
        Validators.required,
        Validators.pattern(/^[a-zA-Z0-9\s-]{3,40}$/),
      ])],
      beskrivelse: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(700)
      ])],
      diagnoseId: ["", Validators.compose([
        Validators.pattern(/^[0-9]{1,6}$/)
      ])],
      dypForklaring: ["", Validators.compose([
        Validators.required,
        Validators.maxLength(5000)
      ])]
    });
  }
 
  ngOnInit() {
    this.route.params.subscribe(params => { this.id = params.id })

  }
}
