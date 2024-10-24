import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  
})
export class PayComponent {
  sessionToken: string | null = null;
  accountNumber: string | null = null;
  loginForm: FormGroup;
  isLoading = false;
  errorMessage: string | null = null; 

  constructor(
    private formBuilder: FormBuilder, 
    private http: HttpClient, 
    private rout: Router
 
  ) {
    this.loginForm = this.formBuilder.group({
      number: ['', [Validators.required, Validators.minLength(3)]],
      amount: ['', [Validators.required, Validators.min(1)]]
    });

    const sessionData = localStorage.getItem('sessionToken');

    if (sessionData) {
      const parsedData = JSON.parse(sessionData);
      this.sessionToken = parsedData.sessionToken;
      this.accountNumber = parsedData.accountNumber;
    }
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const formData = this.loginForm.value;
      const confirmation = prompt("Please confirm your account number to proceed:");
  
      // Check if the entered account number matches the form's account number
      if (confirmation === "paynow") {
        this.isLoading = true;
        this.errorMessage = null;
  
        this.http.get(`${environment.apiUrl}/transaction/send?FromAccountNo=${this.accountNumber}&TokenNo=${this.sessionToken}&toAccount=${formData.number}&amount=${formData.amount}`).subscribe({
          next: (response: any) => {
            console.error(response);
  
            if (response.message === "Transaction successful!") {
              setTimeout(() => {
                this.rout.navigate(["/success"]);
              }, 5000);
            }
          },
          error: (error) => {
            this.isLoading = false;
            this.errorMessage = error.error.message;
            console.error(error);
          }
        });
      } else {
        alert("Account number confirmation failed. Please try again.");
      }
    }
  }
  
}
