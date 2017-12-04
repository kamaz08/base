import { Component, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPublicMessage, IMessage, IPrivateMessageUser } from './../../../../model/message.models';
import { MessageService } from './../../../../service/message.service';

@Component({
    selector: 'privatemessage',
    templateUrl: './private.message.component.html',
    styles: [`.message{width: 100%;display:inline-flex; min-height: 600px; max-height: 600px;`, '.person-panel{min-width:200px}', '.message-panel{width:100%}']
})
export class PrivateMessageComponent {
    public LoadUsers: boolean = true;
    public LoadMessages: boolean = false;
    @Input() public OrderId: Number = null;
    public PrivateMessageUsers: IPrivateMessageUser[] = null;
    public SelectedUser: IPrivateMessageUser;
    public Message: FormGroup;
    public MessageTab: IMessage[];
    private isScrolled: boolean = true;
    private refresh: boolean = true;
    private isRun = false;

    private cryptico: any;

    @ViewChild('messdiv') private messdiv: any;

    constructor(private _fb: FormBuilder, private _service: MessageService) { }
    ngOnInit() {
        this.Message = this._fb.group({
            mess: ['']
        });
    }

    Load() {
        this.LoadPrivateMessage();
    }

    private LoadPrivateMessage() {
        this.LoadUsers = true;
        this._service.GetPrivateMessagesUser(this.OrderId).subscribe(x => {
            this.PrivateMessageUsers = x;
            this.LoadUsers = false;
        });
    }

    public onSubmit(mess: any) {
        debugger;
        this._service.SendPrivateMessage(this.SelectedUser.UserId, this.OrderId, mess.mess, this.SelectedUser.PublicKey).subscribe();
    }

    public MessagesChange(lastMessageId: Number) {
        this.LoadMessages = true;
        this.GetMessages(lastMessageId);
    }


    private GetMessages(lastMessageId: Number) {
        if (lastMessageId == null)
            this.MessageTab = null;
        var me = this;
        if (this.SelectedUser && this.refresh && !this.isRun) {
            this.isRun = true;
            this._service.GetPrivateMessages(this.SelectedUser.UserId, this.OrderId, lastMessageId).subscribe((x: IMessage[]) => {
                this.LoadMessages = false;
                this.isScrolled = this.messdiv.nativeElement.scrollTop == this.messdiv.nativeElement.scrollHeight - this.messdiv.nativeElement.clientHeight;
                if (x.length > 0) {
                    for (var i = 0; i < x.length; i++)
                        x[i].Message[0] = this._service.DecryptMessage(x[i].Message[0]);

                    this.MessageTab = this.MessageTab ? this.MessageTab.concat(x) : x;
                }
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
        if (this.messdiv.nativeElement.scrollTop == 0 && this.SelectedUser.UserId && this.MessageTab && this.MessageTab.length > 0) {
            let first = this.MessageTab[0];
            this._service.GetOldPrivateMessages(this.SelectedUser.UserId, this.OrderId, first.Id).subscribe((x: IMessage[]) => {
                for (var i = 0; i < x.length; i++)
                    x[i].Message[0] = this._service.DecryptMessage(x[i].Message[0]);

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