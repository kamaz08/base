import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthorizeService } from './authorize.service';
import { IOrder } from './../model/order.models';

@Injectable()
export class CandidateService {

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
            '/api/Candidate/GetOrderCandidates?id=' + id,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }
}
