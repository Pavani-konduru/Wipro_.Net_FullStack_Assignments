import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from '../../environments';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',

})

export class RegisterComponent {

  RegisterForm: FormGroup;
  isLoading = false;
  errorMessage: string | null = null; // <-- Add this to store the error message
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
      address: ['', [Validators.required,  Validators.minLength(10)]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  } 

  onSubmit() {
    if (this.RegisterForm.valid) {
      this.isLoading = true;
      this.errorMessage = null; // Reset the error message when submitting
      this.succMessage = null; 
      const formData = this.RegisterForm.value;
      
      this.http.post(environment.apiUrl + '/useraccount/create', formData).subscribe({
        next: (response: any) => {
          this.isLoading = false;
          this.succMessage = response.message;
          this.router.navigate(['/login']); 
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

