import { Component, Input, Inject } from '@angular/core';
import { ICustomer } from './../../../../model/customer.models';
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
    public OrderId: Number;
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
        debugger;
        this._service.GetCandidates(this.OrderId).subscribe(x => { debugger; this.Customers = x });
    }
}

@Component({
    selector: 'CustomerDialog',
    template: '<showprofile UserId={{Id}}></showprofile>',
})
export class CustomerDialog {

    constructor(
        public dialogRef: MatDialogRef<CustomerDialog>,
        @Inject(MAT_DIALOG_DATA) public Id: string) { }

    onNoClick(): void {
        this.dialogRef.close();
    }

}