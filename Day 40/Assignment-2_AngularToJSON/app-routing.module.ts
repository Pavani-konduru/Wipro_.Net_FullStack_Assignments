import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component'; // Import the EmployeeListComponent

// Define the routes
const routes: Routes = [
  { path: '', redirectTo: '/employees', pathMatch: 'full' }, // Default route redirects to EmployeeList
  { path: 'employees', component: EmployeeListComponent }     // Route for EmployeeListComponent
  // Add more routes here as you add more components
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // Register the routes
  exports: [RouterModule]
})
export class AppRoutingModule { }
