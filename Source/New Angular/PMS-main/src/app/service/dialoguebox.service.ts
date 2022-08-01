import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { lastValueFrom } from 'rxjs';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';

@Injectable({
  providedIn: 'root'
})
export class DialogueboxService {

  constructor(private dialog: MatDialog) { }
  
  async IsDeleteConfirmed() : Promise<boolean>{
    
    var result:boolean=false;
    await lastValueFrom( this.dialog.open(DialogBoxComponent).afterClosed()).then((data) => {
      if (data == 'confirm')
        result = true
    }
    );
    return result;
  }
}
