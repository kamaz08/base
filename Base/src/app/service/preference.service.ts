import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthorizeService } from './authorize.service';
import { IPreference } from './../model/preference.models';

@Injectable()
export class PreferenceService {
    constructor(private _http: HttpClient, private _auth: AuthorizeService) { }

    public GetCityPreference(): Observable<any> {
        return this._http.get(
            '/api/Preference/GetCityPreference',
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetCategoryPreference(): Observable<any> {
        return this._http.get(
            '/api/Preference/GetCategoryPreference',
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public UpdateCategoryPreference(data: IPreference[]): Observable<any> {
        return this._http.post(
            '/api/Preference/UpdateCategoryPreference',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public UpdateCityPreference(data: IPreference[]): Observable<any> {
        return this._http.post(
            '/api/Preference/UpdateCityPreference',
            JSON.stringify(data),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }


}