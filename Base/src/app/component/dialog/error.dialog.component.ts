import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef, MdDialog } from "@angular/material";

@Component({
    selector: 'error-dialog',
    template: `<md-card>
    <md-card-header>
        <md-card-title><h1>Coś poszło nie tak</h1></md-card-title>
    </md-card-header>
    <md-card-content>
        <p>{{data}}</p>
    </md-card-content>
    <md-card-actions>
        <button md-button (click)="onNoClick()">Ok</button>
    </md-card-actions>
</md-card>
`
})

export class ErrorDialog {
    constructor(
        public dialogRef: MdDialogRef<ErrorDialog>,
        @Inject(MD_DIALOG_DATA) public data: any) { debugger; }

    onNoClick(): void {
        this.dialogRef.close();
    }
}