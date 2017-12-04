import { Component, Input, Inject } from '@angular/core';
import { ICustomer } from './../../../../model/customer.models';
import { IOrderDisplay } from './../../../../model/order.models';
import { CustomerService } from './../../../../service/customer.service';
import { ShowOrderComponent } from './../show/show.order.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
    selector: 'customerorder',
    templateUrl: './customer.order.component.html',
    styles: [``]
})
export class CustomerOrderComponent {
    @Input()
    public Order: IOrderDisplay;
    public Customers: ICustomer;

    constructor(private _service: CustomerService, public dialog: MatDialog) { }
    ngOnInit() {

    }

    openDialog(Id: String): void {
        let dialogRef = this.dialog.open(CustomerDialog, {
            data: Id
        });
    }

    GetCustomers() {
        this._service.GetCandidates(this.Order.Id).subscribe(x => { debugger; this.Customers = x });
    }

    public ChoosCandidates(candidates: any[]) {
        var result: string[] = [];
        candidates.forEach(function (x) { result.push(x.value); })
        this._service.ChooseCandidates(this.Order.Id, result).subscribe(x => this.GetCustomers())
    }
}

@Component({
    selector: 'CustomerDialog',
    template: '<div style="min-width:500px; max-height:600px"><showprofile UserId={{Id}}></showprofile></div>',
})
export class CustomerDialog {

    constructor(
        public dialogRef: MatDialogRef<CustomerDialog>,
        @Inject(MAT_DIALOG_DATA) public Id: string) { }

    onNoClick(): void {
        this.dialogRef.close();
    }

}