import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth';
import { LoginDto } from '../../../core/models/auth.dto';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class LoginComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  credentials: LoginDto = {
    username: '',
    password: ''
  };

  errorMessage = '';

  onLogin() {
    this.errorMessage = '';

    this.authService.login(this.credentials).subscribe({
      next: (response) => {
        console.log('Login exitoso:', response);
        this.router.navigate(['/chat']);
      },
      error: (err) => {
        console.error('Error al loguear:', err);
        this.errorMessage = 'Usuario o contraseña incorrectos.';
      }
    });
  }
}
