import { Component, Input, ViewChild } from '@angular/core';
import { IOrderDisplay, OrderOwnerEnum } from './../../../../model/order.models';
import { OrderService } from './../../../../service/order.service';

import { CandidateOrderComponent } from './../candidates/candidate.order.component'

@Component({
    selector: 'showorder',
    templateUrl: './show.order.component.html',
    styles: [``]
})
export class ShowOrderComponent {
    @Input()
    public Order: IOrderDisplay;
    public OrderOwner: OrderOwnerEnum;

    @ViewChild('candidatetab') candidatetab: any;
    @ViewChild('messagetab') messagetab: any;
    @ViewChild('candidate')
    private candidateComponent: CandidateOrderComponent;


    constructor(private _service: OrderService) { }
    ngOnInit() {
        this.GetOrderOwner();
    }

    tabChanged = (tabChangeEvent: any): void => {
        if (this.candidatetab && this.candidatetab.isActive) {
            this.candidateComponent.GetCandidates();
        }
        if (this.messagetab && this.messagetab.isActive) {

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