import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'

})
export class AppComponent {
  showNavbar: boolean = true;

  constructor(private router: Router) {
    this.router.events.subscribe(() => {
      this.showNavbar = !(this.router.url.includes('/login') || this.router.url.includes('/register'));

    });
  }
}
