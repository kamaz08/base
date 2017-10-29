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
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json') }
        );
    };
}