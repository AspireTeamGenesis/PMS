import { Component,EventEmitter, OnInit ,Output} from '@angular/core';
import { UserserviceService } from 'src/app/service/userservice.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchtext : string;
  name:any;
  dashboardCount:any;
  designationValue:any;
  constructor(private service: UserserviceService) { }
  
  filter:any={
    designationId:0,
  }
  
  ngOnInit(): void {
    this.getDesignation();
  }
 
  getDesignation()
  {
    this.service.getDesignation().subscribe((data:any)=>
    {
      this.designationValue=data;
    });

  }
  @Output()
  SearchtextChanged : EventEmitter<string>  = new EventEmitter<string>();

  onsearch(){
    this.SearchtextChanged.emit(this.searchtext)
  }


}
