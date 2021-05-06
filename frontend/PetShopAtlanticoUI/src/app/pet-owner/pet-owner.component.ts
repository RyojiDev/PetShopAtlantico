import { Component, OnInit } from '@angular/core';
import { REST_API_SERVER } from '../../services/apiUrl';
import { HttpClient } from '@angular/common/http';

import { PetOwner } from './petOwner';

@Component({
  selector: 'app-pet-owner',
  templateUrl: './pet-owner.component.html',
  styleUrls: ['./pet-owner.component.css']
})
export class PetOwnerComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public petOwners = undefined
  petOwner: PetOwner
  message: string  

  ngOnInit(): void {
    this.petOwner = new PetOwner()
    this.getAllPetOwner();
  }

  salvar(){
    
    this.http.post(`${REST_API_SERVER}/petOwner/SavePetOwner`, this.petOwner).subscribe((petOwnerRest: PetOwner)=>{
      this.petOwner = new PetOwner();
      this.message = "Usuario cadastrado com sucesso!"
      setTimeout(()=>{
        this.message = ""
      },2000)
    })
  }

  getAllPetOwner = () => {
    this.http.get(`${REST_API_SERVER}/PetOwner/GetAllPetOwner`).subscribe((data: PetOwner)=>{
      console.log(data);
      this.petOwners = data;
      console.log(data);
    });
  }

}
