// src/app/employee-list/employee-list.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee.model';

@Component({
    selector: 'app-employee-list',
    templateUrl: './employee-list.component.html',
    styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {
    employees: Employee[];

    constructor(private employeeService: EmployeeService, private router: Router) {
        this.employees = this.employeeService.getEmployees();
    }

    editEmployee(index: number): void {
        this.router.navigate(['/edit-employee', index]);
    }
}
