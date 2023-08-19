import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ErrorInterceptor } from './helpers/ErrorInterceptor';
import { JwtModule } from '@auth0/angular-jwt';
import { JwtInterceptor } from './helpers/JwtInterceptor';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SubscriptionComponent } from './components/subscription/subscription.component';
import { SubscriptionFormComponent } from './components/subscription-form/subscription-form.component';
import { DvdCatalogComponent } from './components/dvd-catalog/dvd-catalog.component';
import { PageErrorComponent } from './components/page-error/page-error.component';
import { DvdCatalogFormComponent } from './components/dvd-catalog-form/dvd-catalog-form.component';
import { DvdCopyComponent } from './components/dvd-copy/dvd-copy.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { LoginBarComponent } from './components/login-bar/login-bar.component';
import { RegisterComponent } from './components/register/register.component';
import { WatchlistComponent } from './components/watchlist/watchlist.component';
import { DvdStatusComponent } from './components/dvd-status/dvd-status.component';
import { PaymentComponent } from './components/payment/payment.component';
import { CustomerDeliveryComponent } from './components/customer-delivery/customer-delivery.component';
import { RequestDVDComponent } from './components/request-dvd/request-dvd.component';
import { CustomerReturnComponent } from './components/customer-return/customer-return.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    FooterComponent,
    HomeComponent,
    SubscriptionComponent,
    SubscriptionFormComponent,
    DvdCatalogComponent,
    PageErrorComponent,
    DvdCatalogFormComponent,
    DvdCopyComponent,
    LandingPageComponent,
    LoginFormComponent,
    LoginBarComponent,
    RegisterComponent,
    WatchlistComponent,
    DvdStatusComponent,
    PaymentComponent,
    CustomerDeliveryComponent,
    RequestDVDComponent,
    CustomerReturnComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    JwtModule.forRoot({
      config:{
      }
    }),
    HttpClientModule,
    RouterModule.forRoot([
      {path:'',component:LandingPageComponent},
      {path:'home',component:HomeComponent},
      {path:'subscription',component:SubscriptionComponent},
      {path:'subscription/add', component:SubscriptionFormComponent},
      {path:'subscription/:subscriptionId', component:SubscriptionFormComponent},
      {path:'delivery', component:CustomerDeliveryComponent},
      {path:'payment',component:PaymentComponent},
      {path:'request',component:RequestDVDComponent},
      {path:'return',component:CustomerReturnComponent},

      {path:'dvdcatalog',component:DvdCatalogComponent},
      {path:'dvdcatalog/add',component:DvdCatalogFormComponent},
      {path:'dvdcatalog/:dvdCatalogId',component:DvdCatalogFormComponent},
      {path:'dvdcatalog/:dvdCatalogId/dvdcopy',component:DvdCopyComponent},

      {path:'watchlist',component:WatchlistComponent},
      {path:'dvdstatus',component:DvdStatusComponent},

      {path:'register',component:RegisterComponent},
      {path:'login',component:LoginFormComponent},
      
      //{path:'**',component:PageErrorComponent}
    ])
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor,multi:true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
