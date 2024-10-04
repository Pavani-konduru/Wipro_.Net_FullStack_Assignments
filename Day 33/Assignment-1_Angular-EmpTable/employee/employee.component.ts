import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html', // Check this path
  styleUrls: ['./employee.component.css']   // Check this path
})

export class EmployeeComponent {
  @Input() employee: any;
  showDetails = false;

  toggleDetails() {
    this.showDetails = !this.showDetails;
  }
}
