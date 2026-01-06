import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth';
import { RegisterDto } from '../../../core/models/auth.dto';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.scss'
})
export class RegisterComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  data: RegisterDto = {
    username: '',
    password: ''
  };

  errorMessage = '';
  isLoading = false;

  onRegister() {
    this.isLoading = true;
    this.errorMessage = '';

    this.authService.register(this.data).subscribe({
      next: (response) => {
        console.log('Registro exitoso', response);
        alert('¡Cuenta creada con éxito! Ahora puedes iniciar sesión.');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error(err);
        this.isLoading = false;
        if (err.status === 400) {
            this.errorMessage = err.error.error || 'Error al registrar. Verifica los datos.';
        } else {
            this.errorMessage = 'Ocurrió un error inesperado.';
        }
      }
    });
  }
}
