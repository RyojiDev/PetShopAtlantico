import { Component, OnInit } from '@angular/core';
import { REST_API_SERVER } from '../../services/apiUrl';

import { PetOwner } from './petOwner';

@Component({
  selector: 'app-pet-owner',
  templateUrl: './pet-owner.component.html',
  styleUrls: ['./pet-owner.component.css']
})
export class PetOwnerComponent implements OnInit {

  constructor() { }

  petOwner: PetOwner  

  ngOnInit(): void {
    this.petOwner = new PetOwner()
  }

  salvar(){
    let teste = this.petOwner
  }

}
