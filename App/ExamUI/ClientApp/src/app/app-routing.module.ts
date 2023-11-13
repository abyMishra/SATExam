import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DestinationMasterComponent } from './segment-currency-setup/destination-master/destination-master.component';
import { DestinationMasterViewAllComponent } from './segment-currency-setup/destination-master-view-all/destination-master-view-all.component';
import { AuthGuard } from './Shared/auth.guard';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'destination-master', component: DestinationMasterComponent, canActivate: [AuthGuard] },
  { path: 'destination-master-view', component: DestinationMasterViewAllComponent, canActivate: [AuthGuard] },
];

@NgModule({
  declarations: [],
  imports: [ RouterModule.forRoot(routes) ],
})
export class AppRoutingModule {


 }
