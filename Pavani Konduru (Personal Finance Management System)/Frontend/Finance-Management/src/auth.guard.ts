import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, @Inject(PLATFORM_ID) private platformId: Object) {}

  canActivate(): boolean {
    const isLoggedIn = this.checkSession(); 

    if (!isLoggedIn) {
      this.router.navigate(['/login']); 
    }
    return isLoggedIn;
  }

  private checkSession(): boolean {
    // Check if we're in the browser
    if (!isPlatformBrowser(this.platformId)) {
      return false; // Not in browser, return false
    }

    const storedData = localStorage.getItem('sessionToken');

    if (storedData) {
      try {
        const parsedData = JSON.parse(storedData);
        return !!(parsedData && parsedData.sessionToken && parsedData.accountNumber);
      } catch (error) {
        console.error("Error parsing session token", error);
        return false;
      }
    } else {
      return false;
    }
  }
}
