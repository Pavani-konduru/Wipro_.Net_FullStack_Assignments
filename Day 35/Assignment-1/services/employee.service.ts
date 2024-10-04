// src/app/services/employee.service.ts
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    private employees: Employee[] = [
        { firstName: 'John', middleName: 'A.', lastName: 'Doe', dob: new Date('15-01-1990'), country: 'USA', age: 34, email: 'john.doe@example.com', phone: '123-456-7890', address: '123 Main St', city: 'New York', state: 'NY', zip: '10001' },
        { firstName: 'Jane', middleName: 'B.', lastName: 'Smith', dob: new Date('16-02-1991'), country: 'USA', age: 39, email: 'jane.smith@example.com', phone: '234-567-8901', address: '456 Elm St', city: 'Los Angeles', state: 'CA', zip: '90001' },
        { firstName: 'Michael', middleName: 'C.', lastName: 'Johnson', dob: new Date('17-03-1993'), country: 'USA', age: 32, email: 'michael.johnson@example.com', phone: '345-678-9012', address: '789 Oak St', city: 'Chicago', state: 'IL', zip: '60601' },
        { firstName: 'Emily', middleName: 'D.', lastName: 'Davis', dob: new Date('18-04-1994'), country: 'USA', age: 36, email: 'emily.davis@example.com', phone: '456-789-0123', address: '321 Pine St', city: 'Houston', state: 'TX', zip: '77001' },
        { firstName: 'Chris', middleName: 'E.', lastName: 'Wilson', dob: new Date('19-06-1995'), country: 'USA', age: 28, email: 'chris.wilson@example.com', phone: '567-890-1234', address: '654 Maple St', city: 'Phoenix', state: 'AZ', zip: '85001' },
        { firstName: 'Sarah', middleName: 'F.', lastName: 'Garcia', dob: new Date('20-07-1891'), country: 'USA', age: 33, email: 'sarah.garcia@example.com', phone: '678-901-2345', address: '987 Cedar St', city: 'San Antonio', state: 'TX', zip: '78201' },
        { firstName: 'David', middleName: 'G.', lastName: 'Martinez', dob: new Date('21-09-1986'), country: 'USA', age: 38, email: 'david.martinez@example.com', phone: '789-012-3456', address: '135 Spruce St', city: 'San Diego', state: 'CA', zip: '92101' },
        { firstName: 'Laura', middleName: 'H.', lastName: 'Rodriguez', dob: new Date('07-08-1983'), country: 'USA', age: 40, email: 'laura.rodriguez@example.com', phone: '890-123-4567', address: '246 Fir St', city: 'Dallas', state: 'TX', zip: '75201' },
        { firstName: 'Daniel', middleName: 'I.', lastName: 'Martinez', dob: new Date('19-05-1994'), country: 'USA', age: 29, email: 'daniel.martinez@example.com', phone: '901-234-5678', address: '357 Birch St', city: 'Austin', state: 'TX', zip: '73301' },
        { firstName: 'Jessica', middleName: 'J.', lastName: 'Hernandez', dob: new Date('19-04-2000'), country: 'USA', age: 28, email: 'jessica.hernandez@example.com', phone: '012-345-6789', address: '468 Chestnut St', city: 'San Jose', state: 'CA', zip: '95101' }
    ];

    getEmployees(): Employee[] {
        return this.employees;
    }

    getEmployee(index: number): Employee {
        return this.employees[index];
    }

    addEmployee(employee: Employee): void {
        this.employees.push(employee);
    }

    updateEmployee(index: number, employee: Employee): void {
        this.employees[index] = employee;
    }
}
