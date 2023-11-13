import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs'
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatPaginatorModule } from '@angular/material/paginator'
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'
import { MatSortModule } from "@angular/material/sort";
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { DestinationMasterComponent } from './segment-currency-setup/destination-master/destination-master.component';
import { DestinationMasterGeneralInformationComponent } from './segment-currency-setup/destination-master-general-information/destination-master-general-information.component';
import { DestinationMasterDestinationImagesComponent } from './segment-currency-setup/destination-master-destination-images/destination-master-destination-images.component';
import { DestinationMasterDestinationAirportComponent } from './segment-currency-setup/destination-master-destination-airport/destination-master-destination-airport.component';
import { SideMenuComponent } from './navigation/side-menu/side-menu.component';
import { HeaderComponent } from './navigation/header/header.component';
import { FooterComponent } from './navigation/footer/footer.component';
import { DestinationMasterViewAllComponent } from './segment-currency-setup/destination-master-view-all/destination-master-view-all.component';
import { AppRoutingModule } from './app-routing.module';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { JwtInterceptor } from './Shared/Jwt.interceptor';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    DestinationMasterComponent,
    DestinationMasterGeneralInformationComponent,
    DestinationMasterDestinationImagesComponent,
    DestinationMasterDestinationAirportComponent,
    SideMenuComponent,
    HeaderComponent,
    FooterComponent,
    DestinationMasterViewAllComponent,
    ConfirmDialogComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatTableModule,
    MatTabsModule,
    MatSelectModule,
    MatRadioModule,
    MatButtonModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatCheckboxModule,
    MatDialogModule,
    FlexLayoutModule,
    BrowserAnimationsModule,
    RouterModule,
    AppRoutingModule
  ],
  exports: [
    MatButtonModule,
    MatInputModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
