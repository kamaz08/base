import { NgModule, ErrorHandler } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule, MdNativeDateModule } from '@angular/material';
import { HttpModule } from '@angular/http';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';

import { Routing } from './app.routing';

import { AppComponent } from './component/first/app.component';
import { UserComponent } from './component/userpanel/userpanel.component';
import { MenuComponent } from './component/menu/menu.component';
import { UserProfileComponent } from './component/content/user/profile/user.profile.component';
import { UserSearchComponent } from './component/content/user/search/user.search.component';

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, Routing, Ng2Bs3ModalModule, BrowserAnimationsModule, FormsModule, MaterialModule, MdNativeDateModule],
    declarations: [AppComponent, UserComponent, MenuComponent, UserProfileComponent, UserSearchComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
    bootstrap: [AppComponent]
})
export class AppModule { }
