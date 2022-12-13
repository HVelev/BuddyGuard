import { Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { AuthGuard } from "./guards/auth.guard";
import { NavbarComponent } from "./navbar/navbar.component";
import { AboutComponent } from "./pages/about/about.component";
import { AcceptRequestsComponent } from "./pages/accept-requests/accept-requests.component";
import { BuddiesComponent } from "./pages/buddies/buddies.component";
import { IndexComponent } from "./pages/index/index.component";
import { LoginComponent } from "./pages/login/login.component";
import { PriceComponent } from "./pages/price/price.component";
import { ProcessRequestComponent } from "./pages/process-request/process-request.component";
import { RegisterComponent } from "./pages/register/register.component";
import { RequestComponent } from "./pages/request/request.component";

export const appRoutes: Routes = [

  {
    path: 'index',
    component: IndexComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'process-request',
    component: ProcessRequestComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'accept-requests',
    component: AcceptRequestsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'about',
    component: AboutComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'request',
    component: RequestComponent,
    canActivate: [AuthGuard],
    
  },
  {
    path: 'price',
    component: PriceComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'buddies',
    component: BuddiesComponent,
    canActivate: [AuthGuard],
  },
  {
    path: '',
    component: IndexComponent,
  }

]
