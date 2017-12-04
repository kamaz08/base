import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IOrder } from './../../../../model/order.models';
import { OrderService } from './../../../../service/order.service';

@Component({
    templateUrl: './add.order.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px;} .form-full-width{width: 90%;}`]
})
export class AddOrderComponent {
    public Order: FormGroup;

    constructor(private _fb: FormBuilder, private _service: OrderService) { }

    ngOnInit() {
        this.Order = this._fb.group({
            Name: [''],
            Category: [''],
            Rate: [''],
            NumberOfEmploye: [1],
            State: [''],
            City: [''],
            Street: [''],
            ResultDate: [''],
            WorkDate: [''],
            Description: [''],
            ExecutionTime: [''],
            Requirements: ['']
        });
    }

    public onSubmit(data: IOrder) {
        this._service.AddOrder(data).subscribe(x => {  });
    }


}