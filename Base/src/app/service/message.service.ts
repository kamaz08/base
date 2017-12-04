import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthorizeService } from './authorize.service';

declare var cryptico: any;

@Injectable()
export class MessageService {
    private key: any = null;


    constructor(private _http: HttpClient, private _auth: AuthorizeService) { }
    //public mess
    public GetPublicMessage(orderId: Number): Observable<any> {
        return this._http.get(
            '/api/Message/GetPublicMessages?orderId=' + orderId,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetMessages(publicMessageId: Number, lastMessage: Number): Observable<any> {
        return this._http.get(
            '/api/Message/GetMessages?publicMessageId=' + publicMessageId + '&lastMessage=' + lastMessage,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public SendMessage(publicMessageId: Number, mess: String): Observable<any> {
        return this._http.post('/api/Message/SendMessage',
            JSON.stringify({ id: publicMessageId, Name: mess }),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetOldMessage(publicMessageId: Number, lastMessage: Number): Observable<any> {
        return this._http.get(
            '/api/Message/GetOldMessages?publicMessageId=' + publicMessageId + '&lastMessage=' + lastMessage,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }
    //private mess
    public GetPrivateMessagesUser(orderId: Number): Observable<any> {
        return this._http.get(
            '/api/Message/GetPrivateMessagesUser?orderId=' + orderId,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetPrivateMessages(userId: String, orderId: Number, lastMessage: Number): Observable<any> {
        if (this.key == null) throw Error('Załaduj klucz prywatny');
        return this._http.get(
            '/api/Message/GetPrivateMessages?userId=' + userId + '&orderId=' + orderId + '&lastMessage=' + lastMessage,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public GetOldPrivateMessages(userId: String, orderId: Number, lastMessage: Number): Observable<any> {
        console.log(cryptico.generateAESKey());
        if (this.key == null) throw Error('Załaduj klucz prywatny');
        return this._http.get(
            '/api/Message/GetOldPrivateMessages?userId=' + userId + '&orderId=' + orderId + '&lastMessage=' + lastMessage,
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public SendPrivateMessage(To: String, OrderId: Number, Message: String, key: String): Observable<any> {
        Message = cryptico.encrypt(this.RemovePolishCharakters(Message), key).cipher;
        return this._http.post('/api/Message/SendPrivateMessage',
            JSON.stringify({ ToUserId: To, OrderId: OrderId, Message: Message }),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public SetKeys(klucz: any) {
        this.key = klucz;
    }

    public GenerateKey(random: String[], pass: String) {
        var byte = this.GenerateAESKey(pass);
        var keygen = cryptico.bytes2string(random);
        var privkey = cryptico.encryptAESCBC(keygen, byte);
        var priv1 = cryptico.decryptAESCBC(privkey, byte);
        console.log(keygen);
        console.log(priv1);

        this.key = cryptico.generateRSAKey(keygen, 1024);
        var pubkey = cryptico.publicKeyString(this.key);
        console.log(pubkey);
        this.ChangePublicKey(pubkey).subscribe();
        return privkey;
    }

    public LoadKey(ciphertext: String, pass: String): Observable<any> {
        var byte = this.GenerateAESKey(pass);
        var keygen = cryptico.decryptAESCBC(ciphertext, byte);
        this.key = cryptico.generateRSAKey(keygen, 1024);
        var pubkey = cryptico.publicKeyString(this.key);
        console.log(pubkey);
        return this._http.post('/api/Message/CheckPublicKey',
            JSON.stringify({ Name: pubkey }),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    private GenerateAESKey(pass: String) {
        var byte = cryptico.string2bytes(cryptico.b256to64(pass));
        while (byte.length < 32) byte = byte.concat(byte);
        byte = byte.slice(0, 32);
        return byte;
    }


    private ChangePublicKey(pubkey: String): Observable<any> {
        return this._http.post('/api/Message/UpdatePublicKey',
            JSON.stringify({ Name: pubkey }),
            { headers: new HttpHeaders().set('Content-Type', 'application/json').append('Authorization', 'Bearer ' + this._auth._accessToken) }
        );
    }

    public DecryptMessage(text: String) {
        return cryptico.decrypt(text, this.key).plaintext;
    }

    private RemovePolishCharakters(text: String) {
        var tab = [
            ['ę', 'e'], ['ó', 'o'], ['ą', 'a'], ['ś', 's'], ['ł', 'l'], ['ż', 'z'],
            ['ź', 'z'], ['ć', 'c'], ['ń', 'n'], ['Ę', 'E'], ['Ó', 'O'], ['Ą', 'A'],
            ['Ś', 'S'], ['Ł', 'L'], ['Ż', 'Z'], ['Ź', 'Z'], ['Ć', 'C'], ['Ń', 'N']];

        for (var i = 0; i < tab.length; i++)
            text = this.replaceAll(text, tab[i][0], tab[i][1]);
        return text;
    }

    private replaceAll(text: String, from: string, to: string) {
        while (text.search(from) >= 0) text = text.replace(from, to);
        return text;
    }
}