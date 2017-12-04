import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

export class CustomerService {

    private cryptico : any
    //private privKey: any = any;

    public GenerateNewKey(passphrase: String): String {
        let x = this.cryptico.generateRSAKey(passphrase, 1024);

        return null;
    }






}