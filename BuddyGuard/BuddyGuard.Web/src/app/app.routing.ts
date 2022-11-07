import { Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { AboutComponent } from "./pages/about/about.component";
import { IndexComponent } from "./pages/index/index.component";
import { RequestComponent } from "./pages/request/request.component";

export const appRoutes: Routes = [

  {
    path: 'index',
    component: IndexComponent
  },
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: 'request',
    component: RequestComponent
  },
  {
    path: '',
    component: IndexComponent
  }

]
