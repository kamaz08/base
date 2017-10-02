import { Injectable} from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ILogin, IRegistrationUser } from './../model/authorization.models'

@Injectable()
export class LoginService {
    constructor(private _http: HttpClient) { }

    private _accessToken: string;
    private _refreshToken: string;
    private _refreshFunc: any;
    private _lasttime: Date;

    SendOTPToken(login: string) {
        return this._http.get(
            '/api/Account/LoginOtpCode',
            { params: new HttpParams().set('login', login) }
        );
    };

    Login(data: ILogin) {
        return this._http.post(
            '/token',
            'grant_type=' + data.grant_type + '&username=' + data.username + '&password=' + data.password + '&otpkey=' + data.otpkey,
            { headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded') }
        );
    };

    Register(data: IRegistrationUser) {
        return this._http.post(
            '/api/Account/Register',
            data,
            { headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded') }
        );
    };

   


    //get(url: string): Observable<any> {
    //    return this._http.get(url)
    //        .map((response: Response) => <any>response.json());
    //}

    //post(url: string, model: any): Observable<any> {
    //    let body = JSON.stringify(model);
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });
    //    return this._http.post(url, body, options)
    //        .map((response: Response) => <any>response.json());
    //}

    //put(url: string, id: number, model: any): Observable<any> {
    //    let body = JSON.stringify(model);
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });
    //    return this._http.put(url + id, body, options)
    //        .map((response: Response) => <any>response.json());
    //}

    //delete(url: string, id: number): Observable<any> {
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });
    //    return this._http.delete(url + id, options)
    //        .map((response: Response) => <any>response.json());
    //}
}