import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html'
})
export class AppComponent {
    tiles = [
        { text: 'One', cols: 1, rows: 1, color: 'lightblue' },
        { text: 'Two', cols: 1, rows: 1, color: 'lightgreen' },
        { text: 'Three', cols: 1, rows: 1, color: 'lightpink' },
        { text: 'Four', cols: 1, rows: 1, color: '#DDBDF1' },
    ];
}
