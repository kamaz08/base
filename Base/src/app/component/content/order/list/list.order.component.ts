import { Component, Input } from '@angular/core';
import { IOrderDisplay } from './../../../../model/order.models';
import { OrderService } from './../../../../service/order.service';
import { ShowOrderComponent } from './../show/show.order.component';

@Component({
    selector: 'listorder',
    templateUrl: './list.order.component.html',
    styles: [``]
})
export class ListOrderComponent {
    public OrderList: IOrderDisplay[];
    
    constructor(private _service: OrderService) { }
    ngOnInit() {
        this.GetOrder();
    }


    public GetOrder() {
        this._service.GetOrder().subscribe(x => { this.OrderList = x; }, x => { debugger; });
    }

    public Delete() {

    }


}