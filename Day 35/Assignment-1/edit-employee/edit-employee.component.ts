import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee.model';

@Component({
    selector: 'app-edit-employee',
    templateUrl: './edit-employee.component.html',
    styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
    employee!: Employee; // Use definite assignment assertion
    index!: number; // Use definite assignment assertion

    constructor(
        private employeeService: EmployeeService,
        private route: ActivatedRoute,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.index = +this.route.snapshot.paramMap.get('id')!;
        this.employee = this.employeeService.getEmployee(this.index);
    }

    onSubmit(): void {
        if (this.index !== null) {
            this.employeeService.updateEmployee(this.index, this.employee);
        } else {
            this.employeeService.addEmployee(this.employee);
        }
        this.router.navigate(['/employee-list']);
    }
    
}
