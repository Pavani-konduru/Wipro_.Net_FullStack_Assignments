import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from '../../environments';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
})
export class AccountComponent {
  sessionToken: string | null = null;
  accountNumber: string | null = null;
  name: string | null = null;
  phone: string | null = null;
  email: string | null = null;
  address: string | null = null;
  RegisterForm: FormGroup;
  isLoading = false;
  errorMessage: string | null = null;
  succMessage: string | null = null;

  constructor(
    private formBuilder: FormBuilder, 
    private http: HttpClient, 
    private router: Router 
  ) {
    
    this.RegisterForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]],
      address: ['', [Validators.required, Validators.minLength(10)]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });

    const sessionData = localStorage.getItem('sessionToken');

    if (sessionData) {
      const parsedData = JSON.parse(sessionData);
      this.sessionToken = parsedData.sessionToken;
      this.accountNumber = parsedData.accountNumber;
    }

   
    this.fetchUserData();
  }

  
  fetchUserData() {
    this.http.get<any>(`${environment.apiUrl}/useraccount/get?TokenNo=${this.sessionToken}&AccountNo=${this.accountNumber}`)
      .subscribe({
        next: (response) => {

          this.name = response.name;
          this.email = response.email;
          this.phone = response.phone;
          this.address = response.address;
         
          this.RegisterForm.patchValue({
            name: response.name,
            email: response.email,
            phone: response.phone,
            address: response.address,
          });
        },
        error: (error) => {
          console.error('Error fetching user data', error);
        }
      });
  }

  
 
  onSubmit() {
    if (this.RegisterForm.valid) {
      this.isLoading = true;
      this.errorMessage = null;
      this.succMessage = null;

      
      const formData = this.RegisterForm.value;
      const payload = {
        tokenNo: this.sessionToken,              
        accountNo: this.accountNumber,           
        name: formData.name,                   
        email: formData.email,                  
        phone: formData.phone,                
        address: formData.address,              
        password: formData.password            
      };
    
     
      this.http.post<any>(`${environment.apiUrl}/useraccount/update`, payload)
        .subscribe({
          next: (response) => {
            this.isLoading = false;
            this.succMessage = response.message;
          
          },
          error: (error) => {
            this.isLoading = false;
            this.errorMessage = error.error.message;
          }
        });
    } else {
      this.RegisterForm.markAllAsTouched(); 
    }
  }
}
