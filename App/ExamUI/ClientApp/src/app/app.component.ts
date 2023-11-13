import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  isLoggedin = false
  ngOnInit(): void {
    if (localStorage.token != undefined) {
      this.isLoggedin = true;
    }
  }
  title = 'Puratech';


}
