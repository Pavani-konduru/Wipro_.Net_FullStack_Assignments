import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // Import HttpClientModule
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee-list/employee-list.component'; // Import the component
import { AppRoutingModule } from './app-routing.module'; // Import AppRoutingModule if you have routing

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent // Add the component to declarations
  ],
  imports: [
    BrowserModule,
    HttpClientModule, // Add HttpClientModule to imports
    AppRoutingModule // Add AppRoutingModule to imports if you have routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
