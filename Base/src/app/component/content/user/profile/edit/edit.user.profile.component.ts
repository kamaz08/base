import { Component, ViewChild } from '@angular/core';
import { PersonalEditUserProfileComponent } from "./personal.edit.user.profile.component";
import { PublicEditUserProfileComponent} from "./public.edit.user.profile.component";

@Component({
    templateUrl: './edit.user.profile.component.html'
})
export class EditUserProfileComponent {

    @ViewChild('personal')
    private personalTab: PersonalEditUserProfileComponent;

    @ViewChild('public')
    private publicTab: PublicEditUserProfileComponent;

    ngOnInit() {
        this.publicTab.Load();
    }

    indexChanged = (index: number): void => {
        switch (index) {
            case 0:
                this.publicTab.Load();
                break;
            case 1:
                this.personalTab.Load();
                break;
        }
    }
}