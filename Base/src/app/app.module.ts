import { NgModule, ErrorHandler } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule, NgModel } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';

import { MatTabsModule, MatInputModule, MatMenuModule, MatSidenavModule, MatToolbarModule, MatListModule, MatIconModule, MatCardModule, MatButtonModule, MatDialogModule } from '@angular/material';

import { Routing } from './app.routing';
import { GlobalErrorHandler } from './helper/error-handler';
import { ErrorDialog } from './component/dialog/error.dialog.component';


import { LoginService } from './service/login.service';
import { AuthorizeService } from './service/authorize.service';
import { ErrorService } from './service/error.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './component/login/login.component'
import { StartComponent } from './component/start/start.component';
import { UserComponent } from './component/userpanel/userpanel.component';
import { MenuComponent } from './component/menu/menu.component';
import { UserProfileComponent } from './component/content/user/profile/user.profile.component';
import { UserSearchComponent } from './component/content/user/search/user.search.component';
import { TestAddComponent } from './component/content/test/add/test.add.component';


@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpClientModule, Routing, Ng2Bs3ModalModule, BrowserAnimationsModule, FormsModule,
        MatTabsModule, MatInputModule, MatMenuModule, MatSidenavModule, MatToolbarModule, MatListModule, MatIconModule, MatCardModule, MatButtonModule, MatDialogModule],
    entryComponents: [ErrorDialog],
    declarations: [AppComponent, LoginComponent, StartComponent, UserComponent, MenuComponent, UserProfileComponent, UserSearchComponent, TestAddComponent, ErrorDialog],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, { provide: ErrorHandler, useClass: GlobalErrorHandler }, ErrorService, LoginService, AuthorizeService],
    bootstrap: [AppComponent]
})
export class AppModule { }
