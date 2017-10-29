import { Component, Input } from '@angular/core';


@Component({
    selector: 'showprofile',
    templateUrl: './show.profile.component.html'
})
export class ShowProfileComponent {
    @Input()
    public UserId: String = "";

    ngOnInit() {
    }
}