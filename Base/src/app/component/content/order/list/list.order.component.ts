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
    public OrderList: IOrderDisplay[] = [];
    public Load: boolean = true;
    public LastResult: IOrderDisplay[] = [];
    public Preference: boolean = true;
    
    constructor(private _service: OrderService) { }
    ngOnInit() {
        this.GetOrder();
    }


    private GetLastId(): Number {
        if (this.OrderList.length == 0)
            return null;
        return this.OrderList[this.OrderList.length - 1].Id;
    }

    public GetOrder() {
        this.Load = true;
        this._service.GetOrder(this.GetLastId(), this.Preference).subscribe(x => this.SetOrders(x), x => { });
    }

    private SetOrders(orders: IOrderDisplay[]) {
        this.Load = false;
        this.LastResult = orders;
        this.OrderList = this.OrderList.concat(orders);
    }

    public scrollEvent(): void {
        this.GetOrder();
    }

    public ChangeOrder() {
        this.OrderList = [];
        this.GetOrder();
    }
}