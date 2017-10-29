import { Injectable, EventEmitter } from "@angular/core";

@Injectable()
export class ErrorService {
    private _errorMessage: string = '';
    public errorUpdated = new EventEmitter();

    public SetError(err: any): void {
        debugger;
        if (err.error && err.error.error_description) {
            this._errorMessage = err.error.error_description;
        } else if (err.error) {
            this._errorMessage = err.error.Message;
        } else {
            this._errorMessage = err.message;
        }

        this.errorUpdated.emit(this._errorMessage);
    }

    public GetError(): string {
        return this._errorMessage;
    }
}