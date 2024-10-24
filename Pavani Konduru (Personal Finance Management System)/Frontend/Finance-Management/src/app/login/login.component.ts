import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router'; 
import { environment } from '../../environments';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  loginForm: FormGroup;
  isLoading = false;
  errorMessage: string | null = null; // <-- Add this to store the error message

  constructor(
    private formBuilder: FormBuilder, 
    private http: HttpClient, 
 
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.isLoading = true;
      this.errorMessage = null; // Reset the error message when submitting

      const formData = this.loginForm.value;
      
      this.http.post(environment.apiUrl + '/useraccount/login', formData).subscribe({
        next: (response: any) => {
          this.isLoading = false;
        
          const sessionData = {
            sessionToken: response.authcode,
            accountNumber: response.accountno
        };
        
        localStorage.setItem('sessionToken', JSON.stringify(sessionData));
   
        window.location.href = '/home'; 
        },
        error: (error) => {
          this.isLoading = false; 
          this.errorMessage = error.error.message;
          console.error(error);
        }
      });
    } else {
      this.loginForm.markAllAsTouched();
    }
  }
}
