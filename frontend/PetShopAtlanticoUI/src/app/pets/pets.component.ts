import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { REST_API_SERVER } from '../../services/apiUrl'

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public pets = [];

  ngOnInit(): void {
    this.http.get(`${REST_API_SERVER}pet/GetAllPets`).subscribe((data: any[])=>{
      this.pets = data;
    });
  }

}
