import { Component, Input, ViewChild } from '@angular/core';
import { PublicMessageComponent } from './../public/public.message.component';
import { PrivateMessageComponent } from './../private/private.message.component';

@Component({
    selector: 'message',
    templateUrl: './show.message.component.html',
    styles: [``]
})
export class ShowMessageComponent {
    @Input()
    public OrderId: Number = null;

    @ViewChild('publictab') publictab: any;
    @ViewChild('privatetab') privatetab: any;
    @ViewChild('public') private publicComponent: PublicMessageComponent;
    @ViewChild('private') private privateComponent: PrivateMessageComponent;

    constructor() { }
    tabChanged = (tabChangeEvent: any): void => {
        if (this.publictab && this.publictab.isActive) {
            this.publicComponent.Load();
        }
        if (this.privatetab && this.privatetab.isActive) {
            this.privateComponent.Load();
        }
    }

    Load() {
        this.publicComponent.Load();
    }
}