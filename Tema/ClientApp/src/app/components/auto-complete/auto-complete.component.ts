import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-auto-complete',
  templateUrl: './auto-complete.component.html',
  styleUrls: ['./auto-complete.component.css']
})
export class AutoCompleteComponent {
  query: string = '';
  suggestions: string[] = [];
  @Input() allSuggestions: string[] = [];
  @Output() textEmitter = new EventEmitter<string>();
  showList: boolean = false;

  constructor() { }

  ngOnInit(): void { }

  search(): void {
    this.suggestions = this.allSuggestions.filter(suggestion => suggestion.toLowerCase().includes(this.query.toLowerCase()));
    this.showList = true;
    this.textEmitter.emit(this.query);
  }

  setValue(suggestion: string): void {
    this.query = suggestion;
    this.showList = false;
  }

  
}
