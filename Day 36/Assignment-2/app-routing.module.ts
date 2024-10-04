// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';
import { CreateEmployeeComponent } from './create-employee/create-employee.component';

const routes: Routes = [
    // Route for employee list
    { path: 'employee-list', component: EmployeeListComponent },
    
    // Route for editing an employee with a dynamic ID
    { path: 'edit-employee', component: EditEmployeeComponent },
    
    // Route for creating a new employee
    { path: 'create-employee', component: CreateEmployeeComponent },
    
    // Redirect route to employee list as default
    { path: '', redirectTo: '/employee-list', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
