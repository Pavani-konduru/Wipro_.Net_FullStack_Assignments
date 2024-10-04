// src/app/models/employee.model.ts
export interface Employee {
    firstName: string;
    middleName?: string; // Optional
    lastName: string;
    dob: Date;
    country: string;
    age: number;
    email: string;
    phone: string;
    address: string;
    city: string;
    state?: string; // Optional
    zip: string;
    termsAccepted?: boolean; // Optional
    
}
