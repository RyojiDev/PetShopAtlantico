import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { REST_API_SERVER } from '../../services/apiUrl';
import { Pet } from '../pets/pet';

@Component({
  selector: 'app-pet-detail',
  templateUrl: './pet-detail.component.html',
  styleUrls: ['./pet-detail.component.css']
})
export class PetDetailComponent implements OnInit {

  public pet: Pet
  constructor(private router: Router, private route:
    ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    let id = this.route.snapshot.params['id']
    console.log(id);

    this.http.get(`${REST_API_SERVER}/pet/GetPetById?id=${id}`).subscribe((data: Pet)=>{
      console.log(data);
      this.pet = data;
      console.log(data);
    });
  }

  formatPetHealth(health){
    switch(health){
      case 0:
        return "Em Tratamento"
      case 1:
        return "Se Recuperando"
      case 2:
        return "Recuperado"    
    }
  }

}
