import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IChangeEmail, IChangePassword } from './../../../../../model/userdata.models';
import { UserService } from './../../../../../service/user.service';

@Component({
    selector: 'securityedituser',
    templateUrl: './security.edit.user.profile.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px; padding: 10px; display: inline-flex;} .form-full-width{width: 90%; padding: 10px;}`]
})
export class SecurityEditUserProfileComponent {
    public ChangePassword: FormGroup;
    public ChangeEmail: FormGroup;

    constructor(private _fb: FormBuilder, private _service: UserService) { }

    ngOnInit() {
        this.ChangePassword = this._fb.group({
            OldPassword: [''],
            Password: [''],
            ConfirmPassword: ['']
        });

        this.ChangeEmail = this._fb.group({
            Email: ['']
        });
    }

    public ChangePasswordFunc(data: IChangePassword) {
        this._service.ChangePassword(data).subscribe();
    }

    public ChangeEmailFunc(data: IChangeEmail) {
        this._service.ChangeEmial(data).subscribe();
    }
}