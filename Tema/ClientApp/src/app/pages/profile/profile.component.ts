import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import Finder from 'src/models/Finder.model';
import Seeker from 'src/models/Seeker.model';
import { JobService } from 'src/app/services/job.service';
import JobRequest from 'src/models/JobRequest.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  loggedAs = this.authService.whoLoggedIn();
  loggedUser = this.authService.loggedUser.user;
  postingJob = false;
  jobPostMessage = '';
  seeker = new Seeker()
  finder = new Finder()
  public jobForm = this.formBuilder.group({
    title: ['', Validators.required],
    description: ['', Validators.required],
    category: ['', Validators.required],
    location: ['', Validators.required],
    salary: ['', Validators.required],
  });

  constructor(private authService: AuthService, private router: Router, private formBuilder: FormBuilder, private jobService: JobService) {
    this.authService.init().then(() => {
      if (this.loggedAs === 'seeker') {
        this.seeker = this.loggedUser as Seeker;
      } else if (this.loggedAs === 'finder') {
        this.finder = this.loggedUser as Finder;
      }
    })
    
  }
  logout(){
    this.authService.logout();
    window.location.reload();
  }

  navigateToCompany(url: string) {
    this.router.navigate(['/company', url]);
  }

  navigateToJob(url: string) {
    this.router.navigate(['/job', url]);
  }

  setPostingJob() {
    this.postingJob = !this.postingJob;
  }

  async postJob() {
    if (this.jobForm.valid) {
      const toSend: JobRequest = {
        name: this.jobForm.value.title!,
        description: this.jobForm.value.description!,
        category: this.jobForm.value.category!,
        location: this.jobForm.value.location!,
        salary: this.jobForm.value.salary!,
        creatorEmail: this.loggedUser!.email,
      }
      const res = await this.jobService.createJob(toSend);
      if (res.status === 200) {
        this.jobPostMessage = 'Job posted successfully';
        window.location.reload();
      } else {
        this.jobPostMessage = res.message;
      }
    } else {
      this.jobPostMessage = 'Invalid information';
    }
  }

  
}
