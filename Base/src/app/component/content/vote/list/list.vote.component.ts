import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IOrder } from './../../../../model/order.models';
import { CustomerService } from './../../../../service/customer.service';

@Component({
    templateUrl: './list.vote.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px;} .form-full-width{width: 90%;}`]
})
export class ListVoteComponent {
    public Load = true;
    public LastResult: any[] = null;
    public VoteList: any[] = [];
    constructor(private _service: CustomerService) { }

    ngOnInit() {
        this.GetVote();
    }

    private GetVote() {
        this.Load = true;
        this._service.GetRawVote(this.GetLastId()).subscribe(x => this.SetVote(x));
    }

    private GetLastId(): Number {
        if (this.VoteList.length == 0)
            return null;
        return this.VoteList[this.VoteList.length - 1].Id;
    }

    private SetVote(vote: any[]) {
        this.Load = false;
        this.LastResult = vote;
        this.VoteList = this.VoteList.concat(vote);
    }

    scrollEvent(event: any) {
        this.GetVote();
    }
}

