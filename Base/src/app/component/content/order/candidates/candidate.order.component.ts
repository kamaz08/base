import { Component, Input, Inject } from '@angular/core';
import { ICandidate } from './../../../../model/candidate.models';
import { CandidateService } from './../../../../service/candidate.service';
import { ShowOrderComponent } from './../show/show.order.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
    selector: 'candidateorder',
    templateUrl: './candidate.order.component.html',
    styles: [``]
})
export class CandidateOrderComponent {
    @Input()
    public OrderId: Number;
    public Candidates: ICandidate;

    constructor(private _service: CandidateService, public dialog: MatDialog) { }
    ngOnInit() {
        
    }

    openDialog(Id: String): void {
        debugger;
        let dialogRef = this.dialog.open(CandidateDialog, {
            data: Id
        });
    }

    GetCandidates() {
        this._service.GetCandidates(this.OrderId).subscribe(x => { debugger; this.Candidates = x });
    }


}

@Component({
    selector: 'CandidateDialog',
    template: '<showprofile UserId={{Id}}></showprofile>',
})
export class CandidateDialog {

    constructor(
        public dialogRef: MatDialogRef<CandidateDialog>,
        @Inject(MAT_DIALOG_DATA) public Id: string) { }

    onNoClick(): void {
        this.dialogRef.close();
    }

}