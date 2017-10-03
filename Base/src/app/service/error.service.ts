import { Injectable, EventEmitter } from "@angular/core";

@Injectable()
export class ErrorService {
    private _errorMessage: string = '';
    public errorUpdated = new EventEmitter();

    public SetError(err: any): void {
        debugger;
        if (err.error.error_description) {
            this._errorMessage = err.error.error_description;
        } else {
            this._errorMessage = err.error.Message;
        }
        this.errorUpdated.emit(this._errorMessage);
    }

    public GetError(): string {
        return this._errorMessage;
    }
}