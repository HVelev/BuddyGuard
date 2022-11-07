import { Component, OnInit } from '@angular/core';
import instagram from '@iconify/icons-mdi/instagram';
import facebook from '@iconify/icons-mdi/facebook-box';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  public instaIcon = instagram;
  public fbIcon = facebook;

  constructor() { }

  ngOnInit(): void {
  }

}
