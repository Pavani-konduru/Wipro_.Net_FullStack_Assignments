import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../environments';

@Component({
  selector: 'app-wallet',
  templateUrl: './wallet.component.html',
})
export class WalletComponent {
  sessionToken: string | null = null;
  accountNumber: string | null = null;
  name: string | null = null;
  email: string | null = null;
  status: string | null = null;
  RegisterForm: FormGroup;
  isLoading = false;
  balance = 0;
  errorMessage: string | null = null; // <-- Add this to store the error message


  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute
  ) {
    // Initializing the form with validators
    this.RegisterForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      email: ['', [Validators.required, Validators.email]],
      amount: ['', [Validators.required, Validators.min(1)]],
      payment: ['', [Validators.required]], // Corrected formControlName
    });

    // Fetching session data from local storage
    const sessionData = localStorage.getItem('sessionToken');
    if (sessionData) {
      const parsedData = JSON.parse(sessionData);
      this.sessionToken = parsedData.sessionToken;
      this.accountNumber = parsedData.accountNumber;
    }

    // Fetching user data
    this.fetchUserData();
  }

  fetchUserData() {
    this.http.get<any>(`${environment.apiUrl}/useraccount/get?TokenNo=${this.sessionToken}&AccountNo=${this.accountNumber}`)
      .subscribe({
        next: (response) => {
          this.name = response.name;
          this.email = response.email;
          this.RegisterForm.patchValue({
            name: response.name,
            email: response.email,
          });
        },
        error: (error) => {
          console.error('Error fetching user data', error);
        }
      });

      this.http.get<any>(`${environment.apiUrl}/transaction/balance?TokenNo=${this.sessionToken}&AccountNo=${this.accountNumber}`).subscribe(response => {
        this.balance = response.bal; 
      }, error => {
        console.error('Error fetching balance', error);
      });

     
        this.route.queryParams.subscribe(params => {
          this.status = params['sts'];
          if(this.status === "success")
          {
            this.errorMessage = `<div><i class="ri-checkbox-circle-fill"></i> Amount successfully added to wallet!.</div>`;
          }
          
        });
    
  }

  onSubmit() {
    if (this.RegisterForm.valid) {
      this.isLoading = true;
      
      var amount = this.RegisterForm.get('amount')?.value;
  
      window.location.href = `https://rajsoft.org.in/testapi/?tocken=${this.sessionToken}&account=${this.accountNumber}&amount=${amount}&return=${window.location.href}&callback=${environment.apiUrl}/transaction/credit`;
      
      this.isLoading = false;
    }
  }
 
}
  