import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FinderService } from 'src/app/services/finder.service';
import { SeekerService } from 'src/app/services/seeker.service';
import ApiResponse from 'src/models/ApiResponse.model';
import FinderResponseLogin from 'src/models/FinderResponseLogin.model';
import SeekerResponseLogin from 'src/models/SeekerResponseLogin.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm = this.formBuilder.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  });
  active: number = 1;
  message = ''
  constructor(private readonly formBuilder: FormBuilder, private seekerService: SeekerService, private finderService: FinderService) { }
  activeMap: Record<number, string> = {
    1: 'seeker',
    2: 'finder',
  }
  ngOnInit(): void {
  }

  async login() {
    console.log(this.loginForm.value, this.active);
    if (this.loginForm.valid) {
      let tk: ApiResponse<SeekerResponseLogin> | ApiResponse<FinderResponseLogin>;
      if (this.activeMap[this.active] === 'seeker') {
        tk = await this.seekerService.loginSeeker({
          email: this.loginForm.value.email!,
          password: this.loginForm.value.password!,
        })
      }
      else {
        tk = await this.finderService.loginFinder({
          email: this.loginForm.value.email!,
          password: this.loginForm.value.password!,
        })
      }
      if (tk.status !== 200) {
        this.message = tk.message;
        return;
      }
    }
    else {
      this.message = 'Please fill all the fields'
    }
  }

  setActive(active: number) {
    this.active = active;
  }
}
