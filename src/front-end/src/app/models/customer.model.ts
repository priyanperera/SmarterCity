export class Customer {
  id: number = 0;
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  mobileNumber: string = '';
  address: {
    street: string;
    city: string;
    state: string;
    country: string;
    postCode: string;
  } = {
    street: '',
    city: '',
    state: '',
    country: '',
    postCode: '',
  };
}
