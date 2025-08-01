import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginResponse } from '../models/login-response';
import { User } from '../models/user';
import { BehaviorSubject } from 'rxjs';
import { jwtDecode } from 'jwt-decode';
import { environment } from '../environments/environment';

interface JwtPayload{
  sub: string;
  name: string;
  lastname: string;
  role: string
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly baseUrl = `${environment.apiUrl}/auth`;
  private readonly TokenKey = 'AppToken';
  private readonly router = inject(Router);
  private readonly httpClient = inject(HttpClient);
  
  private isAuthentificateSubject = new BehaviorSubject<boolean>(false);
  private currentUserSubject = new BehaviorSubject<User|null>(null);

  isAuthenticated$ = this.isAuthentificateSubject.asObservable();
  currentUser$ = this.currentUserSubject.asObservable();

  get currentUser(): User|null{
    return this.currentUserSubject.value;
  }

  login(login: string, password: string) {
    return this.httpClient
      .post<LoginResponse>(`${this.baseUrl}/Login`, {
        "login": login,
        "password": password,
      })
      .subscribe((res) => {
        localStorage.setItem(this.TokenKey, res.token);
        this.router.navigate(['/']);
        this.isAuthentificateSubject.next(true);

      });
  }

  logout() {
    localStorage.removeItem(this.TokenKey);
    this.isAuthentificateSubject.next(false);
    this.router.navigate(['/']);
  }

  getAccessToken(): string | null {
    return localStorage.getItem(this.TokenKey);
  }

  isAuthenticated(): boolean {
    const token = this.getAccessToken();
    return !!token;
  }

  private decodeToken(token: string): User{
    try {
      const decoded = jwtDecode<JwtPayload>(token);
      return {
        id: Number(decoded.sub),
        name: decoded.name,
        lastname: decoded.lastname,
        role: decoded.role
      }
    } catch (error) {
      console.error('Invalid token', error);
      throw new Error('Invalid token');
    }
  }
}