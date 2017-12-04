import { Component, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPublicMessage, IMessage } from './../../../../model/message.models';
import { MessageService } from './../../../../service/message.service';

@Component({
    selector: 'publicmessage',
    templateUrl: './public.message.component.html',
    styles: [`.message{width: 100%;display:inline-flex; min-height: 600px; max-height: 600px;`, '.person-panel{min-width:200px}', '.message-panel{width:100%}']
})
export class PublicMessageComponent {
    public LoadUsers: boolean = true;
    public LoadMessages: boolean = false;
    @Input() public OrderId: Number = null;
    public PublicMessage: IPublicMessage[] = null;
    public PublicMessageId: Number;
    public Message: FormGroup;
    public MessageTab: IMessage[];
    private isScrolled: boolean = true;
    private refresh: boolean = true;
    private isRun = false;

    @ViewChild('messdiv') private messdiv: any;

    constructor(private _fb: FormBuilder, private _service: MessageService) { }
    ngOnInit() {
        this.Message = this._fb.group({
            mess: ['']
        });
        if (this.OrderId == null)
            this.Load();
    }

    Load() {
        this.LoadPublicMessage();
    }

    private LoadPublicMessage() {
        this.LoadUsers = true;
        this._service.GetPublicMessage(this.OrderId).subscribe(x => {
            this.LoadUsers = false;
            this.PublicMessage = x;
        });
    }

    public onSubmit(mess: any) {
        this._service.SendMessage(this.PublicMessageId, mess.mess).subscribe();

    }

    public MessagesChange(lastMessageId: Number) {
        this.LoadMessages = true;
        debugger;
        this.GetMessages(lastMessageId);
    }


    private GetMessages(lastMessageId: Number) {
        if (lastMessageId == null)
            this.MessageTab = null;
        var me = this;
        if (this.PublicMessageId && this.refresh && !this.isRun) {
            this.isRun = true;
            this._service.GetMessages(this.PublicMessageId, lastMessageId).subscribe((x: IMessage[]) => {
                this.LoadMessages = false;
                this.isScrolled = this.messdiv.nativeElement.scrollTop == this.messdiv.nativeElement.scrollHeight - this.messdiv.nativeElement.clientHeight;
                if (x.length > 0)
                    this.MessageTab = this.MessageTab ? this.MessageTab.concat(x) : x;
                setTimeout(() => { this.isRun = false; this.GetMessages(this.GetLastId()); }, 1000);
                setTimeout(() => { if (this.isScrolled) this.messdiv.nativeElement.scrollTop = this.messdiv.nativeElement.scrollHeight - this.messdiv.nativeElement.clientHeight; }, 100);
            });
        }
    }

    private GetLastId(): Number {
        let length = this.MessageTab ? this.MessageTab.length : 0;
        return length > 0 ? this.MessageTab[length - 1].Id : null
    }


    public scrollEvent(): void {
        if (this.messdiv.nativeElement.scrollTop == 0 && this.PublicMessageId && this.MessageTab && this.MessageTab.length > 0) {
            let first = this.MessageTab[0];
            this._service.GetOldMessage(this.PublicMessageId, first.Id).subscribe((x: IMessage[]) => {
                this.MessageTab = x.concat(this.MessageTab);
            })
        }
    }

    public mouseEvents(val: boolean): void {
        this.refresh = val;
        if (val)
            this.GetMessages(this.GetLastId());
    }
}