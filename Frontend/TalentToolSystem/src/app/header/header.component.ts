import { Component } from '@angular/core';
import { faHome, faSearch, faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  home = faHome;
  search = faSearch;
}
