import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    showButton: boolean;
    showMenu: boolean;

    constructor(private router: Router, private location: Location) {
        debugger;
        this.location.replaceState('/');
        this.router.navigate(['profile'])
    }


    ngOnInit() {
        this.showMenu = !(this.showButton = window.innerWidth < 1000);
        window.onresize = (e) => {
            let temp = window.innerWidth < 1000;
            if (this.showButton == temp) return;
            this.showButton = temp;
            this.showMenu = !temp;
        };
    }
}
