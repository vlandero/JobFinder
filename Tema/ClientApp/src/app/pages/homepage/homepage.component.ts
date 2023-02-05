import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  showSeekerModal = false;
  showFinderModal = false;

  constructor() { }

  ngOnInit(): void {
  }

  openFinder() {
    this.showFinderModal = true;
  }

  openSeeker() {
    this.showSeekerModal = true;
  }

  onFinderClose(){
    this.showFinderModal = false;
  }

  onSeekerClose(){
    this.showSeekerModal = false;
  }
}
