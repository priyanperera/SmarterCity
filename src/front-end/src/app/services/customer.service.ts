import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import { Customer } from '../models/customer.model';

const baseUrl = 'http://localhost:5083/api/Customers';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(private http: HttpClient) {}

  getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(baseUrl);
  }

  getCustomer(id?: number): Observable<Customer> {
    return this.http.get<Customer>(`baseUrl/${id}`);
  }

  createCustomer(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }
}
