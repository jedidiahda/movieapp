import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login-bar',
  templateUrl: './login-bar.component.html',
  styleUrls: ['./login-bar.component.css']
})
export class LoginBarComponent implements OnInit {

  constructor(private router: Router, public authService:AuthenticationService) { }

  ngOnInit(): void {
    console.log(this.authService.name)
  }

  onLogin(){
    this.router.navigate(['/login']);
  }

  onLogout(){
    this.authService.logout();
    this.router.navigate(['/']);

  }
}
