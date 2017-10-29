import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef, MdDialog } from "@angular/material";

@Component({
    selector: 'error-dialog',
    template: `<h1 style = "font-family: Roboto,Helvetica Neue Light,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif">Coś poszło nie tak</h1>
<p style = "font-family: Roboto,Helvetica Neue Light,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif">{{data}}</p>
<button md-button (click)="onNoClick()">Ok</button>
`
})

export class ErrorDialog {
    constructor(
        public dialogRef: MdDialogRef<ErrorDialog>,
        @Inject(MD_DIALOG_DATA) public data: any) { }

    onNoClick(): void {
        this.dialogRef.close();
    }
}