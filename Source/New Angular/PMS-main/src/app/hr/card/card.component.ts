import { Component, Input, OnInit } from '@angular/core';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import{Card} from 'Models/card';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  @Input() artsrc: string="https://localhost:7024/User/Getallusers";
  totalLength:any;
  page:number=1;


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>(this.artsrc)
      .subscribe((data)=>{
       this.data=data;
        this.totalLength=data.length;
        console.log(data);
      });
       
  }
  public data:Card[]=[
    
  ];

}
