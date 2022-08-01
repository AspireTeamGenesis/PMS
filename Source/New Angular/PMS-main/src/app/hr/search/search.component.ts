import { Component,EventEmitter, OnInit ,Output} from '@angular/core';
// import { UserserviceService } from 'src/app/service/userservice.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchtext : string;
  name:any;
  dashboardCount:any;
  constructor() { }
  
  ngOnInit(): void {
  }

  @Output()
  SearchtextChanged : EventEmitter<string>  = new EventEmitter<string>();

  


  onsearch(){
    this.SearchtextChanged.emit(this.searchtext)
  }


}
