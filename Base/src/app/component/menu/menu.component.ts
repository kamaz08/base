import { Component } from '@angular/core';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})
export class MenuComponent {
    public menu = [
        {
            name: 'Twoje konto', list: [
                { name: 'Twój profil', icon: 'perm_identity', router: 'profile' },
                { name: 'Edytuj profil', icon: 'create', router: 'editprofile' },
                { name: 'Twoje ofety', icon: 'content_copy', router: 'yourjobs' },
            ]
        },
        {
            name: 'Praca', list: [
                { name: 'Preferencje', icon: 'build', router: 'workprofile' },
                { name: 'Twoje aplikacje', icon: 'class', router: 'application' },
                { name: 'Dodaj ofertę', icon: 'note_add', router: 'add' },
                { name: 'Oceń', icon: 'gavel', router: 'rate' },
                { name: 'Szukaj', icon: 'search', router: 'searchjob' }

            ]
        },
        {
            name: 'Społeczność', list: [
                { name: 'Szukaj osoby', icon: 'search', router: 'searchprofile' },
                { name: 'Wiadomości', icon: 'message', router: 'message' }
            ]
        },
    ];
}