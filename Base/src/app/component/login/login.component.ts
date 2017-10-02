import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material';
import { LoginService } from './../../service/login.service';
import { AuthorizeService } from './../../service/authorize.service';
import { ILogin, IRegistrationUser } from './../../model/authorization.models';


@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    zLogin: string;
    zPassword: string;
    zOtp: string;

    rLogin: string;
    rPassword: string;
    rPassword2: string;
    rEmail: string;


    constructor(private _formBuilder: FormBuilder, private _loginService: LoginService, private _authorizeService: AuthorizeService ) { };
    ngOnInit() { };

    SendOTP(): void {
        this._loginService.SendOTPToken(this.zLogin).subscribe(
            () => { },
            (error) => { });
    };

    Zaloguj(): void {
        let data: ILogin = {
            grant_type: 'password',
            username: this.zLogin,
            password: this.zPassword,
            otpkey: this.zOtp
        };

        this._loginService.Login(data).subscribe(
            (x : any) => { this._authorizeService.SetAccess(x.access_token, x.refresh_token); },
            (err) => { debugger; });
    };

    Rejestruj(): void {
        let data: IRegistrationUser = {
            UserName: this.rLogin,
            Password: this.rPassword,
            ConfirmPassword: this.rPassword2,
            Email: this.rEmail
        };

        this._loginService.Register(data).subscribe(
            (x) => { debugger; },
            (x) => { debugger; }
        );

    }
}