import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { Router } from '@angular/router';


@Injectable()
export class AuthorizeService {
    constructor(private _http: HttpClient, private _router: Router) { }

    public _accessToken: string;
    private _refreshToken: string;
    private _refreshFunc: any;
    private _lasttime: number;

    public CheckLogin(): void {
        if (this._accessToken == null || this._refreshToken == null) {
            this.Logout();
        }
    }

    public GetAccess(): string {
        return this._accessToken;
    }

    public SetAccess(access: string, refresh: string): void {
        this._accessToken = access;
        this._refreshToken = refresh;
        this._refreshFunc = setInterval(() => this.refresh(), 1000 * 60 * 4 );
        this._router.navigate(['start']);
    }

    private refresh() {
        this._http.post(
            '/token',
            'grant_type=refresh_token&refresh_token=' + this._refreshToken,
            { headers: new HttpHeaders().set('Accept', 'application/json') }
        ).subscribe(
            (x: any) => { this._refreshToken = x.refresh_token; this._accessToken = x.access_token; },
            (err) => { this.Logout(); });

    }

    public Logout(): void {
        clearInterval(this._refreshFunc);
        this._accessToken = this._refreshToken = null;
        this._router.navigate(['login']);
    }
}