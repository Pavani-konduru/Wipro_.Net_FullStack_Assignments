// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';

const routes: Routes = [
    { path: 'employee-list', component: EmployeeListComponent },
    { path: 'edit-employee/:id', component: EditEmployeeComponent },
    { path: '', redirectTo: '/employee-list', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
