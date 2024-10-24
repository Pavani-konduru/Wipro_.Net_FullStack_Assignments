import { Component, OnInit, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments';
import { Chart, LinearScale, CategoryScale, LineController, PointElement, LineElement } from 'chart.js';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {

  sessionToken: string | null = null;
  accountNumber: string | null = null;
  name: string | null = null;
  credit = 0;
  debit = 0;
  balance = 0;
  myChart: Chart | undefined;

  constructor(private http: HttpClient) {
    // Registering necessary components
    Chart.register(LineController, LinearScale, CategoryScale, PointElement, LineElement);
  }

  ngOnInit(): void {
    const sessionData = localStorage.getItem('sessionToken');

    if (sessionData) {
      const parsedData = JSON.parse(sessionData);
      this.sessionToken = parsedData.sessionToken;
      this.accountNumber = parsedData.accountNumber;
    }

    // Fetch user data
    this.http.get<any>(`${environment.apiUrl}/useraccount/get?TokenNo=${this.sessionToken}&AccountNo=${this.accountNumber}`).subscribe(response => {
      this.name = response.name; 
    }, error => {
      console.error('Error fetching user data', error);
    });

    // Fetch balance
    this.http.get<any>(`${environment.apiUrl}/transaction/balance?TokenNo=${this.sessionToken}&AccountNo=${this.accountNumber}`).subscribe(response => {
      this.balance = response.bal; 
    }, error => {
      console.error('Error fetching balance', error);
    });

    // Fetch credit sum
    this.http.get<any>(`${environment.apiUrl}/transaction/sumhistory?TokenNo=${this.sessionToken}&AccountNo=${this.accountNumber}&type=credit`).subscribe(response => {
      this.credit = response.totalAmount; 
    }, error => {
      console.error('Error fetching credit sum', error);
    });

    // Fetch debit sum
    this.http.get<any>(`${environment.apiUrl}/transaction/sumhistory?TokenNo=${this.sessionToken}&AccountNo=${this.accountNumber}&type=debit`).subscribe(response => {
      this.debit = response.totalAmount; 
    }, error => {
      console.error('Error fetching debit sum', error);
    });
  }

  ngAfterViewInit(): void {
    this.fetchDataAndCreateChart(); // Create chart after view initialization
  }

  fetchDataAndCreateChart() {
    this.http.get<any[]>(`${environment.apiUrl}/transaction/graph?AccountNo=${this.accountNumber}&TokenNo=${this.sessionToken}`)
      .subscribe(data => {
        this.createChart(data);
      }, error => {
        console.error('Error fetching transaction data', error);
      });
  }

  createChart(transactions: any[]) {
    const credits: { label: string; y: number }[] = [];
    const debits: { label: string; y: number }[] = [];

    transactions.forEach(transaction => {
        const date = new Date(transaction.date).toLocaleDateString(); // Format the date
        
        if (transaction.type === 'Credit' && transaction.amount > 0) {
            credits.push({ label: date, y: transaction.amount });
        } else if (transaction.type === 'Debit' && transaction.amount > 0) {
            debits.push({ label: date, y: transaction.amount });
        }
    });

    if (this.myChart) {
        this.myChart.destroy(); // Destroy the previous chart instance
    }

    const ctx = document.getElementById('myChart') as HTMLCanvasElement;
    if (!ctx) {
      console.error('Canvas element not found');
      return; // Exit if the canvas is not found
    }

    this.myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [...new Set([...credits.map(data => data.label), ...debits.map(data => data.label)])],
            datasets: [
                {
                    label: 'Credits',
                    data: credits.map(data => data.y),
                    borderColor: 'green',
                    backgroundColor: 'rgba(0, 255, 0, 0.3)',
                    fill: false,
                },
                {
                    label: 'Debits',
                    data: debits.map(data => data.y),
                    borderColor: 'red',
                    backgroundColor: 'rgba(255, 0, 0, 0.3)',
                    fill: false,
                }
            ]
        },
        options: {
            responsive: true,
            scales: {
                x: { // Category scale for x-axis
                    type: 'category',
                    title: {
                        display: true,
                        text: 'Date'
                    }
                },
                y: {
                    type: 'linear', // Linear scale for y-axis
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Amount (INR)'
                    }
                }
            }
        }
    });
  }
}
