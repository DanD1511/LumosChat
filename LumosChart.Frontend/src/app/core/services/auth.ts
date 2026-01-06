import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { env } from '../../env/env';
import { LoginDto, RegisterDto } from '../models/auth.dto';
import { LoginResponse, User} from '../models/user.model'
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);
  private apiUrl = `${env.apiUrl}/Auth`;

  get token(): string | null {
    return localStorage.getItem('token');
  }

  currentUser = signal<User | null>(null);

  login(credentials: LoginDto){
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap(
        response => {
          localStorage.setItem('token', response.token);
          this.currentUser.set({
            id: 'default',
            username: credentials.username,
            avatarUrl: '',
            token: response.token
          })
        }
      )
    )
  }

  register(data: RegisterDto) {
    return this.http.post<User>(`${this.apiUrl}/register`, data);
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUser.set(null);
  }

  isLoggedIn(): Boolean {
    return !!localStorage.getItem('token');
  }
}
