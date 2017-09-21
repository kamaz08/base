import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
    //{ path: '', component: null },
    //{ path: 'user', component: null },
    //{ path: 'getwork', component: null },
    //{ path: 'addwork', component: null },
    //{ path: 'search', component: null },
    //{ path: '**', component: null }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);