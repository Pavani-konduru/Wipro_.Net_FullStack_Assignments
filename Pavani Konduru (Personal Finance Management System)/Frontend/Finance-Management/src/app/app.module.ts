import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FilenotfoundComponent } from './filenotfound/filenotfound.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LogoutComponent } from './logout/logout.component';
import { AccountComponent } from './account/account.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { PayComponent } from './pay/pay.component';
import { WalletComponent } from './wallet/wallet.component';
import { SuccessComponent } from './success/success.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    FilenotfoundComponent,
    LogoutComponent,
    AccountComponent,
    TransactionsComponent,
    PayComponent,
    WalletComponent,
    SuccessComponent,
   

  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    BrowserModule, AppRoutingModule, ReactiveFormsModule, HttpClientModule
  ],
  providers: [ 
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
