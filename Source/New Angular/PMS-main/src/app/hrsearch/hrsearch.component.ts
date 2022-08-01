import { Component,EventEmitter, OnInit ,Output} from '@angular/core';

@Component({
  selector: 'app-hrsearch',
  templateUrl: './hrsearch.component.html',
  styleUrls: ['./hrsearch.component.css']
})
export class HrsearchComponent implements OnInit {

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
