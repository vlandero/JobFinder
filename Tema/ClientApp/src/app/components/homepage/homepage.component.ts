import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor(private api: ApiService) { }

  ngOnInit(): void {
  }

  public async getData() {
    const data = await this.api.request('get', 'api/Companies/test/asa');
    console.log(data.data);
  }

}
