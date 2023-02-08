import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from 'src/app/services/company.service';
import CompanyResponse from 'src/models/CompanyResponse.model';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {

  name: string = '';
  constructor(route: ActivatedRoute, private companyService: CompanyService, private router: Router) {
    this.name = route.snapshot.params['name'];
  }
  company: CompanyResponse = new CompanyResponse();
  ngOnInit() {
    this.companyService.getCompany(this.name).then((res) => {
      if (res.status !== 200) {
        this.router.navigate(['/error'])
        return;
      }
      this.company = res.data!;
      console.log(res.data);
    }).catch((err) => {
      console.log(err);
      this.router.navigate(['/error'])
    })
  }
}
