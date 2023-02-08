import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { FinderService } from 'src/app/services/finder.service';
import { JobService } from 'src/app/services/job.service';
import { SeekerService } from 'src/app/services/seeker.service';
import Finder from 'src/models/Finder.model';
import JobResponse from 'src/models/JobResponse.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})
export class JobComponent implements OnInit {
  id: number = 0;
  job: JobResponse = new JobResponse();
  companyName: string = '';
  constructor(route: ActivatedRoute, private jobService: JobService, private router: Router, private seekerService: SeekerService, private authService: AuthService, private finderService: FinderService) {
    this.id = parseInt(route.snapshot.params['id']);
  }
  whologgedIn = this.authService.whoLoggedIn();
  userLoggedIn = this.authService.loggedUser.user as Finder;
  ngOnInit() {

    this.jobService.getJob(this.id).then((res) => {
      if(res.status !== 200) {
        this.router.navigate(['/error'])
        return;
      }
      this.job = res.data!;
      console.log(res.data);
      this.seekerService.getSeekerByEmail(this.job.creatorEmail).then((res) => {
        if(res.status !== 200) {
          this.router.navigate(['/error'])
          return;
        }
        this.companyName = res.data!.company.name; // se putea imbunatati aici, dar nu am mai avut rabdare pe final sa schimb dto urile sa bag si compania aici :)
      });
    }).catch((err) => {
      console.log(err);
      this.router.navigate(['/error'])
    })
  }

  async apply() {
    const res = await this.finderService.applyToJob({ //aici mai trebuie verificat daca deja a aplicat sau nu, poate fi facuta si in serviciu
      finderEmail: this.userLoggedIn.email,
      postId: this.job.postId,
    });
    if(res.status === 200) {
      alert('Applied successfully');
      this.router.navigate(['/profile']);
    }
    else{
      alert(res.message); 
    }

  }
}
