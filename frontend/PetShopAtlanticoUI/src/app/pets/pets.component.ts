import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {

  constructor(private http: HttpClient) { }

  private REST_API_SERVER = "https://localhost:44389/api/Pet/GetAllPets";

  public pets = [];

  ngOnInit(): void {
    this.http.get(this.REST_API_SERVER).subscribe((data: any[])=>{
      this.pets = data;
    });
  }

}
