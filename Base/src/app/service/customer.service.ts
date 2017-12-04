import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthorizeService } from './authorize.service';
import { IOrder } from './../model/order.models';

@Injectable()
export class CustomerService {

    constructor(private _http: HttpClient, private _auth: AuthorizeService) { }

    public AddOrder(data: IOrder): Observable<any> {
        return this._http.post(
            '/api/Order/AddOrder',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetCandidates(id: Number): Observable<any> {
        return this._http.get(
            '/api/Customer/GetOrderCustomers?id=' + id,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public ChooseCandidates(orderId: Number, customerIdList: String[]) {
        return this._http.post(
            '/api/Customer/ChooseCandidates',
            JSON.stringify({ OrderId: orderId, CustomerIdList: customerIdList}),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetRawVote(id: Number): Observable<any> {
        return this._http.get(
            '/api/Customer/GetRawVote?lastId=' + id,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public AddVote(id: Number, vote: Number, description: String) {
        return this._http.post(
            '/api/Customer/AddVote',
            JSON.stringify({ Id: id, Vote: vote, Description: description }),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetVotes(userId: String, lastId: Number) {
        return this._http.get(
            '/api/Customer/GetVotes?userId=' + userId +'&lastId='+lastId,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

}
