import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthorizeService } from './authorize.service';
import { IPersonalData, IPublicProfile, IChangeEmail, IChangePassword } from './../model/userdata.models';

@Injectable()
export class UserService {
    constructor(private _http: HttpClient, private _auth: AuthorizeService) { }

    public UpdatePersonalData(data: IPersonalData): Observable<any> {
        return this._http.post(
            '/api/User/UpdatePersonalData',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetPersonalData(): Observable<any> {
        return this._http.get(
            '/api/User/GetPersonalData',
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetPersonalProfile(): Observable<any> {
        return this._http.get(
            '/api/User/GetPersonalProfile',
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public UpdatePersonalProfile(data: IPublicProfile): Observable<any> {
        return this._http.post(
            '/api/User/UpdatePersonalProfile',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public ChangeEmial(data: IChangeEmail): Observable<any> {
        return this._http.post(
            '/api/Account/ChangeEmail',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public ChangePassword(data: IChangePassword): Observable<any> {
        return this._http.post(
            '/api/Account/ChangePassword',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetPublicUser(Login: String): Observable<any> {
        return this._http.get(
            '/api/User/GetPublicUser?userId='+Login,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

}