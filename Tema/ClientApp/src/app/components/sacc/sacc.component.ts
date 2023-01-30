import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SeekerService } from 'src/app/services/seeker.service';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-sacc',
  templateUrl: './sacc.component.html',
  styleUrls: ['./sacc.component.css']
})
export class SAccComponent implements OnInit {
  allSuggestions: string[] = ['Company1', 'Company2', 'Company3'];
  joinedCompany: string = '';
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
    if(companies.data)
      this.allSuggestions = companies.data.map(company => company.name);
  }

  onChangeJoinedCompany(event: string) {
    this.joinedCompany = event;
    console.log(event);
  }

  setVisible(n: number) {
    this.visible = n;
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
    this.visible = 4;
  }

  register(){
    console.log('Register!');
    this.router.navigate(['/login']);
  }

}
