import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-infoSymptom',
  templateUrl: './infoSymptom.component.html',
})
export class InfoSymptomComponent {
  public id: Number | undefined;

  constructor(private http: HttpClient,  private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => { this.id = params.id })
  }
}
