import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { REST_API_SERVER } from '../../services/apiUrl';
import { Pet } from './pet';
import { PetOwner } from '../pet-owner/petOwner';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {

  selectedValue = 0;
  healthstatus = 0;
  constructor(private http: HttpClient) { }
 
  public pets = []
  public accomodations = []
  public listhealthStatus = []
  pet: Pet

  message: string;

  ngOnInit(): void {
    this.pet = new Pet();
    this.pet.petOwner = new PetOwner();
    this.pet.accomodationId = 1;
    this.selectedValue = 1;
    this.healthstatus = 1;

    this.http.get(`${REST_API_SERVER}/pet/GetAllPets`).subscribe((data: any[])=>{
      this.pets = data;
    });

    this.getAccomodationId();
    this.getHealthStatus();

  }

  Salvar(){ 
    this.http.post(`${REST_API_SERVER}/pet/SavePet`, this.pet).subscribe((petRest: Pet)=>{
      debugger
      this.pet = new Pet()
      this.pet.petOwner = new PetOwner()
      this.getAccomodationId();

      this.message = "Usuario cadastrado com sucesso!"
      setTimeout(()=>{
        this.message = ""
      },2000)
    },erro => {
      if(erro.status == 404 || erro.status == 400 || 500){
        this.message = "Erro ao tentar cadastrar"
        this.pet = new Pet();
        this.pet.petOwner = new PetOwner()
        this.getAccomodationId();
        setTimeout(()=>{
          this.message = ""
        },2000)
      }
    })
  }

  Alterar(pet: Pet){

  }

  Excluir(pet: Pet){

  }

  getAccomodationId = () =>{
    console.log(this.pet);
  this.http.get(`${REST_API_SERVER}/PetAccommodation/getListAllAccomodation`).subscribe((data: any[])=>{
    console.log(data);
    this.accomodations = data;
  });
}

  getHealthStatus = () =>{
  console.log(this.pet);
  this.http.get(`${REST_API_SERVER}/Pet/GetHealthStatus`).subscribe((data: any[])=>{
  console.log(data);
  this.listhealthStatus = data;
});
}

  selectChangeHandler (event: any){
    this.selectedValue = parseInt(event.target.value);
    this.pet.accomodationId = this.selectedValue;
    console.log(this.pet.accomodationId);
  }

  selectChangeHandlerHealth(event: any){
    console.log(event.target.value);
    this.healthstatus = parseInt(event.target.value)
    this.pet.petHealth = this.healthstatus;
    //console.log(this.selectedValue);
  }

  getStyleIfBusy(available){
    if(available == false){
      return 'text-danger'
    }else{
      return 'text-success'
    }
  }
}
