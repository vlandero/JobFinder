import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SeekerService } from 'src/app/services/seeker.service';
import Seeker from 'src/models/Seeker.model';

@Component({
  selector: 'app-seeker',
  templateUrl: './seeker.component.html',
  styleUrls: ['./seeker.component.css']
})
export class SeekerComponent implements OnInit {
  public url: string;
  constructor(route: ActivatedRoute, private seekerService: SeekerService, private router: Router) {
    this.url = route.snapshot.params['url'];
  }
  seeker: Seeker = new Seeker();
  ngOnInit() {
    this.seekerService.getSeekerByUrl(this.url).then((res) => {
      if(res.status !== 200) {
        this.router.navigate(['/error'])
        return;
      }
      this.seeker = res.data!;
      console.log(res.data);
    }).catch((err) => {
      console.log(err);
      this.router.navigate(['/error'])
    })
  }
  navigateToCompany(url: string) {
    this.router.navigate(['/company', url]);
  }

  navigateToJob(url: string) {
    this.router.navigate(['/job', url]);
  }
  
}
