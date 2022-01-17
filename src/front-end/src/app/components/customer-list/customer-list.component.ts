import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css'],
})
export class CustomerListComponent implements OnInit {
  customers?: Customer[];
  currentCustomer: Customer = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    mobileNumber: '',
    address: {
      street: '',
      city: '',
      state: '',
      country: '',
      postCode: '',
    },
  };
  currentIndex = -1;
  title = '';

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService.getAllCustomers().subscribe(
      (data) => {
        this.customers = data;
        console.log(data);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  refreshCustomers(): void {
    this.getCustomers();
    this.currentCustomer = {
      id: 0,
      firstName: '',
      lastName: '',
      email: '',
      mobileNumber: '',
      address: {
        street: '',
        city: '',
        state: '',
        country: '',
        postCode: '',
      },
    };
    this.currentIndex = -1;
  }

  setActiveCustomer(customer: Customer, index: number): void {
    this.currentCustomer = customer;
    this.currentIndex = index;
  }
}
