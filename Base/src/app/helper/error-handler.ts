import { ErrorHandler, Injectable } from '@angular/core';
import { ErrorService } from './../service/error.service';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
    constructor(private _errorService: ErrorService) { }
    handleError(error: any) {
        this._errorService.SetError(error);
    }
}