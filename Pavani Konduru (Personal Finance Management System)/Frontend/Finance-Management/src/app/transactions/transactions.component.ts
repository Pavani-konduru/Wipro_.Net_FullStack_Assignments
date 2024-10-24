import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { environment } from '../../environments';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html'
})
export class TransactionsComponent {
  transactions: any[] = [];  
  filterForm: FormGroup;   
  isLoading = false;       
  errorMessage: string | null = null; 
  accountNumber = '1332';    
  sessionToken = 'fe62974da9724b519b9e2f023f0c4d70'; 

  constructor(private http: HttpClient, private formBuilder: FormBuilder) {
  
    const today = new Date();
    const tenDaysAgo = new Date();
    tenDaysAgo.setDate(today.getDate() - 10);

    this.filterForm = this.formBuilder.group({
      startdate: [formatDate(tenDaysAgo, 'yyyy-MM-dd', 'en')],
      enddate: [formatDate(today, 'yyyy-MM-dd', 'en')],
      type: ['all'],
    });
  }

  ngOnInit(): void {
    this.fetchTransactions();
  }

  fetchTransactions() {
    const formData = this.filterForm.value;
    const startDate = `${formData.startdate}T00:00:00`;
    const endDate = `${formData.enddate}T23:59:59`;
    const type = formData.type; 

    this.isLoading = true;
    this.errorMessage = null;

    const apiUrl = `${environment.apiUrl}/transaction/history?AccountNo=${this.accountNumber}&TokenNo=${this.sessionToken}&type=${type}&startdate=${startDate}&enddate=${endDate}`;

    this.http.get<any[]>(apiUrl).subscribe({
      next: (response) => {
        this.transactions = response; 
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Error fetching transaction history.';
        this.isLoading = false;
        console.error(error);
      },
    });
  }

  onFilter() {
    this.fetchTransactions(); 
  }
}
