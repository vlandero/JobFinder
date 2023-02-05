import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { FinderService } from 'src/app/services/finder.service';
import { SeekerService } from 'src/app/services/seeker.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private authService: AuthService, private seekerService: SeekerService, private finderService: FinderService) { }

  extra: string = '';
  loggedIn: boolean = false;

  ngOnInit(): void {
    const fetchExtra = async () => {
      const whoLoggedIn = this.authService.whoLoggedIn();
      if (whoLoggedIn === 'seeker') {
        const res = await this.seekerService.getLoggedIn();
        if (res.status === 200) {
          this.extra = res.data!.firstName;
          this.loggedIn = true;
        }
      }else if (whoLoggedIn === 'finder') {
        const res = await this.finderService.getLoggedIn();
        if (res.status === 200) {
          this.extra = res.data!.firstName;
          this.loggedIn = true;
        }
      }
    }
    fetchExtra();

  }

}
