import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from '../auth.guard';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FilenotfoundComponent } from './filenotfound/filenotfound.component';
import { LogoutComponent } from './logout/logout.component';
import { AccountComponent } from './account/account.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { PayComponent } from './pay/pay.component';
import { WalletComponent } from './wallet/wallet.component';
import { SuccessComponent } from './success/success.component';


const routes: Routes = [
  
  {path:"", component: HomeComponent, canActivate: [AuthGuard]},
{ path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
{path:"login", component: LoginComponent},
{path:"register", component: RegisterComponent},
{path:"account", component: AccountComponent},
{path:"logout", component: LogoutComponent},
{path:"pay", component: PayComponent},
{path:"wallet", component: WalletComponent},
{path:"success", component: SuccessComponent},
{path:"transactions", component: TransactionsComponent},
{path:"**", component: FilenotfoundComponent}
];
 
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
