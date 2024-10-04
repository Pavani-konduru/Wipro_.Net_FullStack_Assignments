import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'http://localhost:5180/api/Employee'; // Ensure this URL is correct

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/list`); // Adjust according to your API documentation
  }
}
