import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './component/login/login.component'
import { StartComponent } from './component/start/start.component'

import { UserSearchComponent } from './component/content/user/search/user.search.component';
import { EditUserProfileComponent } from './component/content/user/profile/edit/edit.user.profile.component';
import { AddOrderComponent } from './component/content/order/add/add.order.component';
import { ShowProfileComponent } from './component/content/user/profile/show/show.profile.component';
import { ListOrderComponent } from './component/content/order/list/list.order.component';
import { AppListOrderComponent } from './component/content/order/list/applist.order.component';
import { JobListOrderComponent } from './component/content/order/list/joblist.order.component';
import { YourListOrderComponent } from './component/content/order/list/yourlist.order.component';
import { ShowMessageComponent } from './component/content/message/show/show.message.component';
import { ListVoteComponent } from './component/content/vote/list/list.vote.component';
import { PreferenceComponent } from './component/content/preference/preference.component';

const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: 'start', component: StartComponent,
        children: [
            { path: 'profile', component: ShowProfileComponent },
            { path: 'editprofile', component: EditUserProfileComponent },
            { path: 'workprofile', component: PreferenceComponent },
            
            { path: 'searchjob', component: ListOrderComponent },
            { path: 'youroffer', component: YourListOrderComponent },
            { path: 'application', component: AppListOrderComponent },
            { path: 'yourjob', component: JobListOrderComponent },
            { path: 'add', component: AddOrderComponent },
            { path: 'rate', component: ListVoteComponent },

        //    { path: 'searchprofile', component: UserSearchComponent },
            { path: 'message', component: ShowMessageComponent },
            { path: '**', redirectTo: 'searchprofile', pathMatch: 'full' }
        ]
    },
    { path: '**', redirectTo: 'start', pathMatch: 'full' }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);