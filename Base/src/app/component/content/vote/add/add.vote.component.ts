import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IOrder } from './../../../../model/order.models';
import { CustomerService } from './../../../../service/customer.service';

@Component({
    selector: 'addvote',
    templateUrl: './add.vote.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px;} .form-full-width{width: 90%;}`]
})
export class AddVoteComponent {
    @Input() Vote: any;
    public Description: String = "";
    public Value: Number = 5;

    constructor(private _service: CustomerService) { }

    public AddVote() {
        this._service.AddVote(this.Vote.Id, this.Value, this.Description).subscribe(x=> this.Vote = null);
    }


}

