import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css'],
})
export class CustomerDetailsComponent implements OnInit {
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
  message = '';

  constructor(
    private customerService: CustomerService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.message = '';
    this.getCustomer(this.route.snapshot.params['id']);
  }

  getCustomer(id: number): void {
    this.customerService.getCustomer(id).subscribe(
      (data) => {
        this.currentCustomer = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
