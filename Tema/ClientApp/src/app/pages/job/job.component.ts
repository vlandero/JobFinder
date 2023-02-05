import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JobService } from 'src/app/services/job.service';
import JobResponse from 'src/models/JobResponse.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})
export class JobComponent implements OnInit {
  id: number = 0;
  job: JobResponse = new JobResponse();
  constructor(route: ActivatedRoute, private jobService: JobService, private router: Router) {
    this.id = route.snapshot.params['id'];
  }
  ngOnInit() {
    this.jobService.getJob(this.id).then((res) => {
      if(res.status !== 200) {
        this.router.navigate(['/error'])
        return;
      }
      this.job = res.data!;
      console.log(res.data);
    }).catch((err) => {
      console.log(err);
      this.router.navigate(['/error'])
    })
  }
}
