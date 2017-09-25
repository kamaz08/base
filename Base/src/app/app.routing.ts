import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserProfileComponent } from './component/content/user/profile/user.profile.component';
import { UserSearchComponent } from './component/content/user/search/user.search.component';
import { TestAddComponent } from './component/content/test/add/test.add.component';

const appRoutes: Routes = [
    { path: '', component: UserSearchComponent },
    { path: 'searchprofile', component: UserSearchComponent },
    { path: 'profile', component: UserProfileComponent },
    { path: 'test', component: TestAddComponent },
    //{ path: 'user', component: null },
    //{ path: 'getwork', component: null },
    //{ path: 'addwork', component: null },
    //{ path: 'search', component: null },
    { path: '**', redirectTo: 'searchprofile', pathMatch: 'full' }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);