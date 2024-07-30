import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError,  tap } from 'rxjs/operators';

interface LoginDto {
  email: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthserviceService {
  private apiUrl = "http://localhost:5228/api/User/login";                                                                              
  constructor(private http: HttpClient) { }

  login(loginDto: LoginDto): Observable<any> {
    return this.http.post<any>(this.apiUrl, loginDto).pipe(
      tap(response => {
        // Handle successful response here
        console.log('Login successful:', response);
        // Optionally, save the token or user data
        // localStorage.setItem('token', response.token);
      }),
      catchError(this.handleError('login'))
    );
  }

  private handleError(operation = 'operation') {
    return (error: any) => {
      console.error(`${operation} failed: ${error.message}`); // Log to console
      return throwError(() => new Error(`Error occurred during ${operation}`)); // Use throwError for error handling
    };
  }
}
