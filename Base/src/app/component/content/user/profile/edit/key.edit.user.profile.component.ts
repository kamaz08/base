import { Component, OnInit } from '@angular/core';
import { IChangeEmail, IChangePassword } from './../../../../../model/userdata.models';
import { MessageService } from './../../../../../service/message.service';

@Component({
    selector: 'keyedituser',
    templateUrl: './key.edit.user.profile.component.html',
    styles: [`.form-width{width: 45%;max-width: 450px;min-width: 200px; padding: 10px; display: inline-flex;} .form-full-width{width: 90%; padding: 10px;}`]
})
export class KeyEditUserProfileComponent {
    public pass: String = null;
    private ciphertext: String = null;
    public IsGenerate: boolean = false;
    public RandomTab: String[] = [];
    public info: String;

    constructor(private _service: MessageService) { }

    public ReadKey($event: any) {
        var me = this;
        var reader = new FileReader();
        reader.onloadend = function (evt: any) {
            if (evt.target.readyState == 2) {
                me.ciphertext = evt.target.result;
            }
        };
        var file = $event.target.files[0];
        var blob = file.slice(0, file.size);
        reader.readAsBinaryString(blob);
    }

    public LoadKey() {
        this._service.LoadKey(this.ciphertext, this.pass)
            .subscribe(x => { this.info = "Klucz załadowany pomyślnie" });
    }

    public GenerateKey() {
        this.RandomTab = [];
        this.IsGenerate = true;
    }

    public MouseMove(event: MouseEvent) {
        if (this.RandomTab.length >= 1024) {
            this.IsGenerate = false;
            var key = this._service.GenerateKey(this.RandomTab, this.pass);
            this.download(key);
        }
        else
            this.RandomTab.push(((event.layerX * event.layerY) % 256).toString());
    }

    public SaveKey() {

    }

    private download(text: string) {
        var pom = document.createElement('a');
        pom.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
        pom.setAttribute('download', 'private.ppk');

        if (document.createEvent) {
            var event = document.createEvent('MouseEvents');
            event.initEvent('click', true, true);
            pom.dispatchEvent(event);
        }
        else {
            pom.click();
        }
    }


}