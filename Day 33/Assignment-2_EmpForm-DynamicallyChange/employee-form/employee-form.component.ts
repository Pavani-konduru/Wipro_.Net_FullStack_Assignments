import { Component } from '@angular/core';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent {
  employee = {
    firstName: '',
    middleName: '',
    lastName: '',
    dob: '',
    country: '',
    age: null,
    department: '',
    email: '',
  };
}
