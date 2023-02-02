import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SeekerService } from 'src/app/services/seeker.service';
import { CompanyService } from 'src/app/services/company.service';
import SeekerRequestRegister from 'src/models/SeekerRequestRegister.model';

@Component({
  selector: 'app-sacc',
  templateUrl: './sacc.component.html',
  styleUrls: ['./sacc.component.css']
})
export class SAccComponent implements OnInit {
  allSuggestions: string[] = ['Company1', 'Company2', 'Company3'];
  joinedCompany: string = '';
  message = '';
  public registerForm = this.formBuilder.group({
    email: ['', Validators.email],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    password: ['', Validators.required],
    passwordConfirm: ['', Validators.required],
    picture: [''],
    url: ['', Validators.required],
  });
  public companyForm = this.formBuilder.group({
    companyName: ['', Validators.required],
    companyDescription: ['', Validators.required],
    companyLocation: ['', Validators.required],
    companyLogo: [''],
  });
  isCreator = false;
  visible = 1;
  @Output() close = new EventEmitter();
  constructor(private readonly formBuilder: FormBuilder, private seekerService: SeekerService, private companyService: CompanyService, private router: Router) { }

  async ngOnInit(): Promise<void> {
    const companies = await this.companyService.getAllCompanies();
    if (companies.data)
      this.allSuggestions = companies.data.map(company => company.name);
  }

  onChangeJoinedCompany(event: string) {
    this.joinedCompany = event;
    console.log(event);
  }

  setVisible(n: number) {
    this.visible = n;
    this.message = '';
  }

  cancel() {
    this.close.emit();
  }

  nextCreator() {
    this.isCreator = true;
    this.visible = 4;
  }
  nextJoiner() {
    this.isCreator = false;
    this.visible = 5;
  }

  async register() {
    console.log('Register!');
    if (this.registerForm.valid) {
      if (this.registerForm.value.password !== this.registerForm.value.passwordConfirm) {
        this.message = 'Passwords do not match';
        return;
      }
    }
    else {
      this.message = 'Invalid form';
      return;
    }
    const user = {
      email: this.registerForm.value.email!,
      firstName: this.registerForm.value.firstName!,
      lastName: this.registerForm.value.lastName!,
      password: this.registerForm.value.password!,
      profilePicture: this.registerForm.value.picture!,
      url: this.registerForm.value.url!,
    }
    if (this.isCreator) {
      if (!this.companyForm.valid) {
        this.message = 'Invalid form';
        return;
      }
      const toSend: SeekerRequestRegister = {
        ...user,
        companyDto: {
          name: this.companyForm.value.companyName!,
          description: this.companyForm.value.companyDescription!,
          location: this.companyForm.value.companyLocation!,
        },
        created: true
      }
      console.log(toSend);
      const res = await this.seekerService.registerSeeker(toSend);
      console.log(res);
      if (res.status !== 200) {
        this.message = res.message;
        return;
      }
    }
    else {
      if (!this.allSuggestions.includes(this.joinedCompany))
        this.message = 'Company does not exist!';

      console.log('valid');
      const toSend: SeekerRequestRegister = {
        ...user,
        companyDto: {
          name: this.joinedCompany,
          description: '',
          location: '',
        },
        created: false
      }
      console.log(toSend);
      const res = await this.seekerService.registerSeeker(toSend);
      if (res.status !== 200) {
        this.message = res.message;
        return;
      }
    }
    this.router.navigate(['/login']);
  }
}
