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
    MatListModule, MatIconModule, MatCardModule, MatButtonModule, MatDialogModule, MatRadioModule,
    MatDatepickerModule, MdNativeDateModule, MatProgressSpinnerModule, MatCheckboxModule, MatProgressBarModule,
    MatSliderModule
} from '@angular/material';

import { Routing } from './app.routing';
import { GlobalErrorHandler } from './helper/error-handler';
import { ErrorDialog } from './component/dialog/error.dialog.component';


import { LoginService } from './service/login.service';
import { AuthorizeService } from './service/authorize.service';
import { ErrorService } from './service/error.service';
import { UserService } from './service/user.service';
import { OrderService } from './service/order.service';
import { CustomerService } from './service/customer.service';
import { MessageService } from './service/message.service';
import { PreferenceService } from './service/preference.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './component/login/login.component'
import { StartComponent } from './component/start/start.component';
import { UserComponent } from './component/userpanel/userpanel.component';
import { MenuComponent } from './component/menu/menu.component';
import { EditUserProfileComponent } from './component/content/user/profile/edit/edit.user.profile.component';
import { PersonalEditUserProfileComponent } from './component/content/user/profile/edit/personal.edit.user.profile.component';
import { PublicEditUserProfileComponent } from './component/content/user/profile/edit/public.edit.user.profile.component';
import { SecurityEditUserProfileComponent } from './component/content/user/profile/edit/security.edit.user.profile.component';
import { KeyEditUserProfileComponent } from './component/content/user/profile/edit/key.edit.user.profile.component';
import { AddOrderComponent } from './component/content/order/add/add.order.component';
import { ShowProfileComponent } from './component/content/user/profile/show/show.profile.component';
import { InfoShowProfileComponent } from './component/content/user/profile/show/info.show.profile.component';
import { ShowOrderComponent } from './component/content/order/show/show.order.component';
import { ListOrderComponent } from './component/content/order/list/list.order.component';
import { AppListOrderComponent } from './component/content/order/list/applist.order.component';
import { JobListOrderComponent } from './component/content/order/list/joblist.order.component';
import { YourListOrderComponent } from './component/content/order/list/yourlist.order.component';
import { CustomerOrderComponent, CustomerDialog } from './component/content/order/customer/customer.order.component';
import { ShowMessageComponent } from './component/content/message/show/show.message.component';
import { PublicMessageComponent } from './component/content/message/public/public.message.component';
import { PrivateMessageComponent } from './component/content/message/private/private.message.component';
import { AddVoteComponent } from './component/content/vote/add/add.vote.component';
import { ListVoteComponent } from './component/content/vote/list/list.vote.component';
import { ShowVoteComponent } from './component/content/vote/show/show.vote.component';
import { PreferenceComponent } from './component/content/preference/preference.component';

import { UserSearchComponent } from './component/content/user/search/user.search.component';


@NgModule({
    imports: [
        BrowserModule, ReactiveFormsModule, HttpClientModule, Routing, Ng2Bs3ModalModule, BrowserAnimationsModule, FormsModule,
        MatTabsModule, MatInputModule, MatMenuModule, MatSidenavModule, MatToolbarModule, MatListModule, MatIconModule, MatCardModule,
        MatButtonModule, MatDialogModule, MatDatepickerModule, MdNativeDateModule, MatProgressSpinnerModule, MatCheckboxModule, MatRadioModule,
        MatProgressBarModule, MatSliderModule
    ],
    entryComponents: [ErrorDialog, CustomerDialog],
    declarations: [
        AppComponent, LoginComponent, StartComponent, UserComponent, MenuComponent, UserSearchComponent, ErrorDialog,
        EditUserProfileComponent, PersonalEditUserProfileComponent, PublicEditUserProfileComponent, CustomerDialog,
        SecurityEditUserProfileComponent, AddOrderComponent, InfoShowProfileComponent, ShowProfileComponent, ShowOrderComponent,
        ListOrderComponent, CustomerOrderComponent, ShowMessageComponent, PublicMessageComponent, PrivateMessageComponent,
        KeyEditUserProfileComponent, AppListOrderComponent, JobListOrderComponent, YourListOrderComponent, AddVoteComponent,
        ListVoteComponent, ShowVoteComponent,PreferenceComponent
    ],
    providers: [
        { provide: APP_BASE_HREF, useValue: '/' },
        { provide: ErrorHandler, useClass: GlobalErrorHandler },
        ErrorService, LoginService, AuthorizeService, UserService, OrderService, CustomerService, MessageService, PreferenceService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
