import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { NavComponent } from './components/nav/nav.component';
import { SAccComponent } from './components/sacc/sacc.component';
import { FAccComponent } from './components/facc/facc.component';
import { LoginComponent } from './pages/login/login.component';
import { ModalComponent } from './components/modal/modal.component';
import { SkillComponent } from './components/skill/skill.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AutoCompleteComponent } from './components/auto-complete/auto-complete.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { SearchComponent } from './pages/search/search.component';
import { AuthGuard } from './guards/auth.guard';
import { FinderComponent } from './pages/finder/finder.component';
import { SeekerComponent } from './pages/seeker/seeker.component';
import { ErrorComponent } from './pages/error/error.component';
import { CompanyComponent } from './pages/company/company.component';
import { JobComponent } from './pages/job/job.component';

@NgModule({
  entryComponents: [FAccComponent],
  declarations: [
    AppComponent,
    HomepageComponent,
    NavComponent,
    SAccComponent,
    FAccComponent,
    LoginComponent,
    ModalComponent,
    SkillComponent,
    AutoCompleteComponent,
    ProfileComponent,
    SearchComponent,
    FinderComponent,
    SeekerComponent,
    ErrorComponent,
    CompanyComponent,
    JobComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomepageComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'search', component: SearchComponent },
      { path: 'seeker/:url', component: SeekerComponent },
      { path: 'finder/:url', component: FinderComponent },
      { path: 'company/:name', component: CompanyComponent },
      { path: 'job/:id', component: JobComponent },
      { path: 'error', component: ErrorComponent },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
