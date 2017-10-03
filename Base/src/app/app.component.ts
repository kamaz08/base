import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { ErrorDialog } from './component/dialog/error.dialog.component';
import { ErrorService } from './service/error.service';

@Component({
    selector: 'app',
    template: `<router-outlet></router-outlet>`
})
export class AppComponent {
    constructor(public _errorService: ErrorService, private _mdDialog: MdDialog) { }
    ngOnInit() {
        this._errorService.errorUpdated.subscribe(
            (err: string) => { this.ShowDialog(err); });
    }
    value: any;

    private ShowDialog(text: string): void {
        let dialogRef = this._mdDialog.open(ErrorDialog, {
            data: text
        });
    }
}