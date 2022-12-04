import { Component, OnInit } from '@angular/core';

declare var Dropbox: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public button?: any;

  options = {
    success: function (files: any) {

    },
    cancel: function () {

    }
  }

  constructor(public document: Document) {
  }

  ngOnInit() {
    var button = Dropbox.createChooseButton(this.options);
    debugger;
  }

  title = 'Buddyguard.Web';
}
