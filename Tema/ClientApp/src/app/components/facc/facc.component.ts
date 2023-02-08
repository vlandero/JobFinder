//finder account creation component

import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FinderService } from 'src/app/services/finder.service';
import FinderRequestRegister from 'src/models/FinderRequestRegister.model';
@Component({
  selector: 'app-facc',
  templateUrl: './facc.component.html',
  styleUrls: ['./facc.component.css']
})
export class FAccComponent implements OnInit {
  public registerForm = this.formBuilder.group({
    email: ['', Validators.email],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    password: ['', Validators.required],
    passwordConfirm: ['', Validators.required],
    about: [''],
    url: ['', Validators.required],
    profilePicture: [''],
  });
  currentSkill = '';
  message = '';
  skills: string[] = [];
  visible = 1;
  @Output() close = new EventEmitter();

  constructor(private readonly formBuilder: FormBuilder, private finderService: FinderService, private router: Router) { }


  ngOnInit(): void {
  }

  setVisible(n: number) {
    this.visible = n;
  }

  async register() {
    if(this.registerForm.valid){
      if(this.registerForm.value.password !== this.registerForm.value.passwordConfirm){
        this.message = 'Passwords do not match';
        return;
      }
      console.log('valid');
      const toSend: FinderRequestRegister = {
        email: this.registerForm.value.email!,
        firstName: this.registerForm.value.firstName!,
        lastName: this.registerForm.value.lastName!,
        password: this.registerForm.value.password!,
        about: this.registerForm.value.about!,
        url: this.registerForm.value.url!,
        skills: this.skills,
        profilePicture: this.registerForm.value.profilePicture!
      }
      const res = await this.finderService.registerFinder(toSend);
      if(res.status === 200)
        this.router.navigate(['/login']);
      else
        this.message = res.message;
      console.log(res);
      console.log(toSend);
    }
    else{
      this.message = 'Invalid information';
    }
  }

  addSkill(skill: string) {
    const skillExists = this.skills.find(s => s === skill);
    if (!skillExists) {
      this.skills.push(skill);
    }
    this.currentSkill = '';
  }

  onChangeSkill(skill: string) {
    if(skill !== '')
      this.currentSkill = skill;
  }

  cancel() {
    this.close.emit();
  }

  deleteSkill(skill: string) {
    this.skills = this.skills.filter(s => s !== skill);
  }

}
