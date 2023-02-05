import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FinderService } from 'src/app/services/finder.service';
import Finder from 'src/models/Finder.model';

@Component({
  selector: 'app-finder',
  templateUrl: './finder.component.html',
  styleUrls: ['./finder.component.css']
})
export class FinderComponent implements OnInit {
  public url: string;
  finder: Finder = new Finder();
  constructor(route: ActivatedRoute, private finderService: FinderService, private router: Router) {
    this.url = route.snapshot.params['url'];
  }

  ngOnInit(): void {
    this.finderService.getFinderByUrl(this.url).then((res) => {
      if (res.status !== 200) {
        this.router.navigate(['/error'])
        return;
      }
      this.finder = res.data!;
      console.log(res.data);
    }).catch((err) => {
      console.log(err);
      this.router.navigate(['/error'])
    })
  }
}
