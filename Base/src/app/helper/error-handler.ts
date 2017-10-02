import { ErrorHandler, Injectable } from '@angular/core';
import { LoginService } from './../service/login.service'
@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
    constructor(private _loginService : LoginService) { }
    handleError(error: any) {
        console.log('Hio')
        debugger;
        throw error;
    }

}