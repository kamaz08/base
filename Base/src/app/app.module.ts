import { NgModule, ErrorHandler } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule, NgModel } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';

import {
    MatTabsModule, MatInputModule, MatMenuModule, MatSidenavModule, MatToolbarModule,
    MatListModule, MatIconModule, MatCardModule, MatButtonModule, MatDialogModule,
    MatDatepickerModule, MdNativeDateModule, MatProgressSpinnerModule, MatCheckboxModule
} from '@angular/material';

import { Routing } from './app.routing';
import { GlobalErrorHandler } from './helper/error-handler';
import { ErrorDialog } from './component/dialog/error.dialog.component';


import { LoginService } from './service/login.service';
import { AuthorizeService } from './service/authorize.service';
import { ErrorService } from './service/error.service';
import { UserService } from './service/user.service';
import { OrderService } from './service/order.service';
import { CandidateService } from './service/candidate.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './component/login/login.component'
import { StartComponent } from './component/start/start.component';
import { UserComponent } from './component/userpanel/userpanel.component';
import { MenuComponent } from './component/menu/menu.component';
import { EditUserProfileComponent } from './component/content/user/profile/edit/edit.user.profile.component';
import { PersonalEditUserProfileComponent } from './component/content/user/profile/edit/personal.edit.user.profile.component';
import { PublicEditUserProfileComponent } from './component/content/user/profile/edit/public.edit.user.profile.component';
import { SecurityEditUserProfileComponent } from './component/content/user/profile/edit/security.edit.user.profile.component';
import { AddOrderComponent } from './component/content/order/add/add.order.component';
import { ShowProfileComponent } from './component/content/user/profile/show/show.profile.component';
import { InfoShowProfileComponent } from './component/content/user/profile/show/info.show.profile.component';
import { ShowOrderComponent } from './component/content/order/show/show.order.component'
import { ListOrderComponent } from './component/content/order/list/list.order.component'
import { CandidateOrderComponent, CandidateDialog } from './component/content/order/candidates/candidate.order.component'


import { UserSearchComponent } from './component/content/user/search/user.search.component';
import { TestAddComponent } from './component/content/test/add/test.add.component';


@NgModule({
    imports: [
        BrowserModule, ReactiveFormsModule, HttpClientModule, Routing, Ng2Bs3ModalModule, BrowserAnimationsModule, FormsModule,
        MatTabsModule, MatInputModule, MatMenuModule, MatSidenavModule, MatToolbarModule, MatListModule, MatIconModule, MatCardModule,
        MatButtonModule, MatDialogModule, MatDatepickerModule, MdNativeDateModule, MatProgressSpinnerModule, MatCheckboxModule
    ],
    entryComponents: [ErrorDialog, CandidateDialog],
    declarations: [
        AppComponent, LoginComponent, StartComponent, UserComponent, MenuComponent, UserSearchComponent, TestAddComponent,
        ErrorDialog, EditUserProfileComponent, PersonalEditUserProfileComponent, PublicEditUserProfileComponent,
        SecurityEditUserProfileComponent, AddOrderComponent, InfoShowProfileComponent, ShowProfileComponent, ShowOrderComponent,
        ListOrderComponent, CandidateOrderComponent, CandidateDialog
    ],
    providers: [
        { provide: APP_BASE_HREF, useValue: '/' },
        { provide: ErrorHandler, useClass: GlobalErrorHandler },
        ErrorService, LoginService, AuthorizeService, UserService, OrderService, CandidateService],
    bootstrap: [AppComponent]
})
export class AppModule { }
