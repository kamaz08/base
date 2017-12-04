import { Component, ViewChild } from '@angular/core';

import { AuthorizeService } from './../../service/authorize.service'

@Component({
    selector: 'start',
    templateUrl: './start.component.html',
    styleUrls: ['./start.component.css']
})
export class StartComponent {
    showButton: boolean;
    showMenu: boolean;
    @ViewChild('main') main: any; 
    @ViewChild('router') router: any; 
    constructor(private _authorizeService: AuthorizeService) {
        this._authorizeService.CheckLogin();
    }


    ngOnInit() {
        window.addEventListener('mousemove', this.UpdateLogin, false);
        window.addEventListener('keypress', this.UpdateLogin, false);
        this.showMenu = !(this.showButton = window.innerWidth < 1000);
        window.onresize = (e) => {
            let temp = window.innerWidth < 1000;
            if (this.showButton == temp) return;
            this.showButton = temp;
            this.showMenu = !temp;
        };
    }

    UpdateLogin(): void  {
        
    }
}
