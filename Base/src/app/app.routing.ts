//import { ModuleWithProviders } from '@angular/core';
//import { Routes, RouterModule } from '@angular/router';

//import { UserProfileComponent } from './component/content/user/profile/user.profile.component';
//import { UserSearchComponent } from './component/content/user/search/user.search.component';
//import { TestAddComponent } from './component/content/test/add/test.add.component';

//const appRoutes: Routes = [
//    { path: '', component: UserSearchComponent },
//    { path: 'searchprofile', component: UserSearchComponent },
//    { path: 'profile', component: UserProfileComponent },
//    { path: 'test', component: TestAddComponent },
//    //{ path: 'user', component: null },
//    //{ path: 'getwork', component: null },
//    //{ path: 'addwork', component: null },
//    //{ path: 'search', component: null },
//    { path: '**', redirectTo: 'searchprofile', pathMatch: 'full' }
//];

//export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './component/login/login.component'
import { StartComponent } from './component/start/start.component'

import { UserProfileComponent } from './component/content/user/profile/user.profile.component';
import { UserSearchComponent } from './component/content/user/search/user.search.component';
import { TestAddComponent } from './component/content/test/add/test.add.component';

const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: 'start', component: StartComponent,
        children: [
            { path: 'searchprofile', component: UserSearchComponent },
            { path: 'profile', component: UserProfileComponent },
            { path: 'test', component: TestAddComponent },
            { path: '**', redirectTo: 'searchprofile', pathMatch: 'full' }
        ]
    },
    { path: '**', redirectTo: 'start', pathMatch: 'full' }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);