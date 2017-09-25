import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    showButton: boolean;
    showMenu: boolean;

    ngOnInit() {
        this.showMenu = !(this.showButton = window.innerWidth < 700);
        window.onresize = (e) => {
            let temp = window.innerWidth < 700;
            if (this.showButton == temp) return;
            this.showButton = temp;
            this.showMenu = !temp;
        };
    }
}
