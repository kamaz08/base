import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IOrder } from './../../../../model/order.models';
import { CustomerService } from './../../../../service/customer.service';

@Component({
    selector: 'showvote',
    templateUrl: './show.vote.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px;} .form-full-width{width: 90%;}`]
})
export class ShowVoteComponent {
    @Input() UserId: String = null;
    public Load = true;
    public LastResult: any[] = null;
    public VoteList: any[] = [];
    constructor(private _service: CustomerService) { }

    ngOnInit() {
        this.GetVote();
    }

    private GetLastId() {
        if (this.VoteList.length > 0)
            return this.VoteList[this.VoteList.length - 1].Id;
        return null;
    }

    private GetVote() {
        this.Load = true;
        this._service.GetVotes(this.UserId, this.GetLastId()).subscribe((x: any[]) => this.SetVote(x));
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

