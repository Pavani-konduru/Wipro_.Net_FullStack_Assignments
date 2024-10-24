import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  template: ''
})
export class LogoutComponent {

  constructor(private  routes: Router) {
    localStorage.removeItem('sessionToken');
    
    this.routes.navigate(['/login']); 
  }

  

 
}
