import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { REST_API_SERVER } from '../../services/apiUrl'

@Component({
  selector: 'app-accomodation',
  templateUrl: './accomodation.component.html',
  styleUrls: ['./accomodation.component.css']
})
export class AccomodationComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public accomodations = []

  ngOnInit(): void {
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
}
