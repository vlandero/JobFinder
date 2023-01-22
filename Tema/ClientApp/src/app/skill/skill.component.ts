import { Component, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent {
  @Input() skill: string = '';

  @Output() delete = new EventEmitter();

  constructor() { }

  deleteSkill() {
    this.delete.emit(this.skill);
  }
}
