import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPublicProfile } from './../../../../../model/userdata.models';
import { UserService } from './../../../../../service/user.service';

@Component({
    selector: 'publicedituser',
    templateUrl: './public.edit.user.profile.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px; padding: 10px; display: inline-flex;} .form-full-width{width: 90%; padding: 10px;}`]
})
export class PublicEditUserProfileComponent {
    public PublicData: FormGroup;
    public isLoading: boolean;

    constructor(private _fb: FormBuilder, private _service: UserService) { }

    ngOnInit() {
        this.PublicData = this._fb.group({
            ShowFirstName: [true],
            ShowLastName: [false],
            ShowBirthDate: [false],
            ShowPhoneNumber: [false],
            ShowEmail: [false],
            Education: [''],
            Description: ['']
        });
    }

    Load(): void {
        this.isLoading = true;
        this._service.GetPersonalProfile().subscribe(x => {
            this.PublicData.setValue(x);
            this.isLoading = false;
        });
    }

    public onSubmit(data: IPublicProfile) {
        this._service.UpdatePersonalProfile(data).subscribe(x => { }, x => { }, () => this.Load());
    }


}