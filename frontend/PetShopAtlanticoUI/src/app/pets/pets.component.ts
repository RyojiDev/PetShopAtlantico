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
 
  public pets = undefined 
  public accomodations = []
  public listhealthStatus = []
  pet: Pet
  petSearch: Pet

  message: string;

  ngOnInit(): void {
    this.pet = new Pet();
    this.pet.petOwner = new PetOwner();
    this.pet.accomodationId = 1;
    this.selectedValue = 1;
    this.healthstatus = 1;

    
    this.getAllPets();
    this.getAccomodationId();
    this.getHealthStatus();

  }

  Save(){ 
    this.http.post(`${REST_API_SERVER}/pet/SavePet`, this.pet).subscribe((petRest: Pet)=>{
      this.pet = new Pet()
      this.pet.petOwner = new PetOwner()
      this.getAccomodationId();
      this.getAllPets();

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

  UpdatePet(pet: Pet){
    this.pet = pet
    this.http.put(`${REST_API_SERVER}/pet/UpdatePet`,pet).subscribe((newPet: Pet)=>{
      this.pet = new Pet()
      this.pet.petOwner = new PetOwner()
      this.getAccomodationId();
      this.getAllPets();
      
      this.message = "Usuario Atualizado com sucesso!"
      setTimeout(()=>{
        this.message = ""        
        document.getElementById("btn-update").style.display = "none"
        document.getElementById("btn-save").style.display = "block";
      },2000)
    })
  }

  Update(_pet: Pet, _owner: PetOwner){
    this.pet = _pet
    this.pet.petOwner = _owner;
    document.getElementById("btn-save").style.display = "none";
    document.getElementById("btn-update").style.display = "block"
  }

  Delete(pet){
    if(confirm(`Tem certeza que deseja deletar o pet ${pet.name} ?`)){
      this.http.delete(`${REST_API_SERVER}/pet/DeletePet?id=${pet.id}`).subscribe(()=>{
        this.pet = new Pet()
        this.pet.petOwner = new PetOwner()
        this.getAccomodationId();
        this.getAllPets();
        
        this.message = "Usuario Atualizado com sucesso!"
        setTimeout(()=>{
          this.message = ""        
          document.getElementById("btn-update").style.display = "none"
          document.getElementById("btn-save").style.display = "block";
        },2000)
      })
    }
  }

  getAccomodationId = () =>{
  this.http.get(`${REST_API_SERVER}/PetAccommodation/getListAllAccomodation`).subscribe((data: any[])=>{
    console.log(data);
    this.accomodations = data;
  });
}

  getHealthStatus = () =>{
  this.http.get(`${REST_API_SERVER}/Pet/GetHealthStatus`).subscribe((data: any[])=>{
  console.log(data);
  this.listhealthStatus = data;
});
}

  getAllPets = () =>{  
      let name = (<HTMLSelectElement>document.getElementById("search")).value;
    if(name){
      this.http.get(`${REST_API_SERVER}/pet/SearchPet?name=${name}`).subscribe((data: Pet)=>{
        console.log(data);
        this.pets = data;
      });
    }else{
    this.http.get(`${REST_API_SERVER}/pet/GetAllPets`).subscribe((data: any[])=>{
      this.pets = data;
      console.log(data);
    });
  }
  }

  getPetByName(){
    let name = (<HTMLSelectElement>document.getElementById("search")).value;

    alert(name);
    this.http.get(`${REST_API_SERVER}/pet/SearchPet?name=${name}`).subscribe((data: Pet)=>{
      console.log(data);
      this.petSearch = data;
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
