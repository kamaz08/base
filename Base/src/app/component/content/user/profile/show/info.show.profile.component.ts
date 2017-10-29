import { Component, Input } from '@angular/core';
import { IPublicData } from './../../../../../model/userdata.models';
import { UserService } from './../../../../../service/user.service';

@Component({
    selector: 'infoshowprofile',
    templateUrl: './info.show.profile.component.html',
    styles: ['h1, h2 {color:#673ab7};']
})
export class InfoShowProfileComponent {
    public PublicData: IPublicData;
    @Input()
    public UserId: String;
    constructor(private _service: UserService) { }



    ngOnInit() {
        this.Load();
    }

    Load(): void {
        this._service.GetPublicUser(this.UserId).subscribe(x => this.PublicData = x);
    }
}