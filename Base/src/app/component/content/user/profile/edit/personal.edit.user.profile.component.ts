import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPersonalData } from './../../../../../model/userdata.models';
import { UserService } from './../../../../../service/user.service';

@Component({
    selector: 'personaledituser',
    templateUrl: './personal.edit.user.profile.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px; padding: 10px;}`]
})
export class PersonalEditUserProfileComponent {
    public PersonalData: FormGroup;
    public isLoading: boolean;

    constructor(private _fb: FormBuilder, private _service: UserService) { }

    ngOnInit() {
        this.PersonalData = this._fb.group({
            FirstName: [''],
            LastName: [''],
            BirthDate: [''],
            Pesel: [''],
            PhoneNumber: [''],
            City: [''],
            State: [''],
            Street: [''],
            ZipCode: [''],
            HouseNumber: [''],
            FlatNumber: ['']
        });
    }

    Load(): void {
        this.isLoading = true;
        this._service.GetPersonalData().subscribe(x => {
            this.PersonalData.setValue(x);
            this.isLoading = false;
        });
    }

    public onSubmit(data: IPersonalData) {
        this._service.UpdatePersonalData(data).subscribe(x => { }, x => { }, () => this.Load());
    }
}