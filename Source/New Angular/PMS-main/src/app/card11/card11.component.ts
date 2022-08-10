import { Component, OnInit, Input } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Card } from 'Models/card';
import { UserserviceService } from '../service/userservice.service';

@Component({
    selector: 'app-card11',
    templateUrl: './card11.component.html',
    styleUrls: ['./card11.component.css']
})
export class Card11Component implements OnInit {
    @Input() artsrc: string = "https://localhost:7021/User/GetSpecificUserDetails";

    totalLength: any;
    page: number = 1;
    constructor(private http: HttpClient, private service: UserserviceService) { }
    search: string;
    searchActive(text: any) {
        this.search = text;
    }

    ngOnInit(): void {
        this.getUsers();
    }
    public data: Card[] = [];
    CancelDrive(userID: number) {
        this.service.CancelDrive(userID).subscribe(() => this.getUsers());

    }
    getUsers() {
        this.http
            .get<any>(this.artsrc)
            .subscribe((data) => {
                this.data = data;
                this.totalLength = data.length;
                console.warn(this.data);
            });
    }

}
