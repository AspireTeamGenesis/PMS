import { Component, Input, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-snapbar',
  templateUrl: './snapbar.component.html',
  styleUrls: ['./snapbar.component.css']
})
export class SnapbarComponent implements OnInit {

  @Input() snackBarMessage: string = '';
  @Input() snackBarAction: string = '';
  constructor(private _snackBar: MatSnackBar) {}
  ngOnInit(): void {
    this.openSnackBar();
  }

  openSnackBar() {
    this._snackBar.open(this.snackBarMessage, this.snackBarAction, {
      duration: 3000,
    });
  }

}
