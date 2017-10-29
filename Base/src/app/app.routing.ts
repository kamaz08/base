import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './component/login/login.component'
import { StartComponent } from './component/start/start.component'

import { UserSearchComponent } from './component/content/user/search/user.search.component';
import { TestAddComponent } from './component/content/test/add/test.add.component';
import { EditUserProfileComponent } from './component/content/user/profile/edit/edit.user.profile.component';
import { AddOrderComponent } from './component/content/order/add/add.order.component';
import { ShowProfileComponent } from './component/content/user/profile/show/show.profile.component';
import { ListOrderComponent } from './component/content/order/list/list.order.component';


const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: 'start', component: StartComponent,
        children: [
            { path: 'searchprofile', component: UserSearchComponent },
            { path: 'profile', component: ShowProfileComponent },
            { path: 'editprofile', component: EditUserProfileComponent },
            { path: 'searchjob', component: ListOrderComponent },
            { path: 'add', component: AddOrderComponent },
            { path: 'test', component: TestAddComponent },
            { path: '**', redirectTo: 'searchprofile', pathMatch: 'full' }
        ]
    },
    { path: '**', redirectTo: 'start', pathMatch: 'full' }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);