import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { REST_API_SERVER } from '../../services/apiUrl'
import { PetAccomodation } from './petAccomodation';
 
@Component({
  selector: 'app-accomodation',
  templateUrl: './accomodation.component.html',
  styleUrls: ['./accomodation.component.css']
})
export class AccomodationComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public accomodations = []
  petAccomodation: PetAccomodation
  message: string

  ngOnInit(): void {
    this.petAccomodation = new PetAccomodation();
    this.getListAccomodation()
  }

  getListAccomodation = () =>{
    this.http.get(`${REST_API_SERVER}/PetAccommodation/getListAllAccomodation`).subscribe((data: any[])=>{
      console.log(data);
      this.accomodations = data;
    });
  }

  getStatusAccomodation = (status) =>{
    switch(status){
      case 0:
        return "Livre"
      case 1:
        return "Ocupado"
      case 2: "Aguardando o Dono"   
    } 
  }

  verifyAvaiable = (available) =>{
    if(available == false){
      return 'text-danger'
    }else{
      return 'text-success'
    }
  }

  SaveAccomodation(){
    this.petAccomodation.available = true;
    this.http.post(`${REST_API_SERVER}/PetAccommodation/SaveAccomodation`, this.petAccomodation).subscribe((accomodationRest: PetAccomodation)=>{
      this.petAccomodation = new PetAccomodation()
      this.getListAccomodation()

      this.message = "Alojamento cadastrado com sucesso!"
      setTimeout(()=>{
        this.message = ""
      },2000)
    },erro => {
      if(erro.status == 404 || erro.status == 400 || 500){
        this.message = "Erro ao tentar cadastrar o alojamento"
        this.petAccomodation = new PetAccomodation();
        this.getListAccomodation()
        setTimeout(()=>{
          this.message = ""
        },2000)
      }
    })
  }
}
