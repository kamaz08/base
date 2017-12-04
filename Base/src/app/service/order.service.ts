import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthorizeService } from './authorize.service';
import { IOrder} from './../model/order.models';

@Injectable()
export class OrderService {
    constructor(private _http: HttpClient, private _auth: AuthorizeService) { }

    public AddOrder(data: IOrder): Observable<any> {
        return this._http.post(
            '/api/Order/AddOrder',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public SignInOrder(id: Number): Observable<any> {
        return this._http.get(
            '/api/Order/SignInOrder?id='+id,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public SignOutOrder(id: Number): Observable<any> {
        return this._http.get(
            '/api/Order/SignOutOrder?id=' + id,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public DeleteOrder(id: Number): Observable<any> {
        return this._http.delete(
            '/api/Order/DeleteOrder?id=' + id,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetOrderOwner(id: Number): Observable<any> {
        return this._http.get(
            '/api/Order/GetOrderOwner?id=' + id,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetOrder(orderId: Number, preference: boolean): Observable<any> {
        return this._http.get(
            '/api/OrderList/GetOrders?orderId=' + orderId + '&preference=' + preference,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetUserOrders(orderId: Number): Observable<any> {
        return this._http.get(
            '/api/OrderList/GetUserOrders?orderId=' + orderId,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetCustomerOrders(orderId: Number): Observable<any> {
        return this._http.get(
            '/api/OrderList/GetCustomerOrders?orderId=' + orderId,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetCandidateOrders(orderId: Number): Observable<any> {
        return this._http.get(
            '/api/OrderList/GetCandidateOrders?orderId=' + orderId,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }
}