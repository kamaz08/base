import { Component, Input, ViewChild } from '@angular/core';
import { IOrderDisplay, OrderOwnerEnum } from './../../../../model/order.models';
import { OrderService } from './../../../../service/order.service';

import { CustomerOrderComponent } from './../customer/customer.order.component'
import { ShowMessageComponent } from './../../message/show/show.message.component'

@Component({
    selector: 'showorder',
    templateUrl: './show.order.component.html',
    styles: [``]
})
export class ShowOrderComponent {
    @Input()
    public Order: IOrderDisplay;
    public OrderOwner: OrderOwnerEnum;

    @ViewChild('customertab') customertab: any;
    @ViewChild('messagetab') messagetab: any;
    @ViewChild('customer') private customerComponent: CustomerOrderComponent;
    @ViewChild('messagec') private messageComponent: ShowMessageComponent;

    constructor(private _service: OrderService) { }
    ngOnInit() {
        this.GetOrderOwner();
    }

    tabChanged = (tabChangeEvent: any): void => {
        if (this.customertab && this.customertab.isActive) {
            this.customerComponent.GetCustomers();
        }
        if (this.messagetab && this.messagetab.isActive) {
            this.messageComponent.Load();
        }
    }

    public SignIn() {
        this._service.SignInOrder(this.Order.Id).subscribe(x => { this.GetOrderOwner(); });
    }

    public SignOut() {
        this._service.SignOutOrder(this.Order.Id).subscribe(x => { this.GetOrderOwner(); });
    }

    public DeleteOrder() {
        this._service.DeleteOrder(this.Order.Id).subscribe(x => { this.Order = null; });
    }

    public GetOrderOwner() {
        this._service.GetOrderOwner(this.Order.Id).subscribe(x => { this.OrderOwner = x; });
    }


}