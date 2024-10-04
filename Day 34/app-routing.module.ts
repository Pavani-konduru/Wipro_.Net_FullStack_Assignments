import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './emp-list/employee-list.component';
import { EmployeeComponent } from './employee/employee.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: 'emp-list', component: EmployeeListComponent },
  { path: 'employee/:id', component: EmployeeComponent },
  { path: '', redirectTo: '/emp-list', pathMatch: 'full' }, // Default route
  { path: '**', component: NotFoundComponent } // Wildcard route for 404
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
