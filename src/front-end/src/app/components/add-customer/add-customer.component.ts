import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css'],
})
export class AddCustomerComponent implements OnInit {
  customer: Customer = {
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
  submitted = false;

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {}

  saveCustomer(form: any): void {
    const data = {
      firstName: this.customer.firstName,
      lastName: this.customer.lastName,
      email: this.customer.email,
      mobileNumber: this.customer.mobileNumber,
      address: this.customer.address,
    };

    this.customerService.createCustomer(data).subscribe(
      (response) => {
        this.submitted = true;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  handleAddressChange(address: any) {
    this.customer.address = {
      street: this.getAddressComponent(address, 'route', false),
      city: this.getAddressComponent(address, 'locality', false),
      state: this.getAddressComponent(
        address,
        'administrative_area_level_1',
        false
      ),
      country: this.getAddressComponent(address, 'country', false),
      postCode: this.getAddressComponent(address, 'postal_code', false),
    };
  }

  getAddressComponent(address: any, property: string, shortName: boolean) {
    var addressComponents = address.address_components;
    for (var componentIndex in addressComponents) {
      var component = addressComponents[componentIndex];
      var types = component.types;
      if (types.length > 0) {
        for (var typeIndex in types) {
          var type = types[typeIndex];
          if (type === property) {
            return shortName ? component.short_name : component.long_name;
          }
        }
      }
    }
    return null;
  }

  newCustomer(): void {
    this.submitted = false;
    this.customer = {
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
  }
}
