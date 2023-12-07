import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AgroListComponent } from './components/agros/agro-list/agro-list.component';
import { AgroDetailComponent } from './components/agros/agro-detail/agro-detail.component';
import { BoxListComponent } from './components/boxes/box-list/box-list.component';
import { BoxDetailComponent } from './components/boxes/box-detail/box-detail.component';
import { CreateFormAgroComponent } from './components/forms/create-form-agro/create-form-agro.component';
import { CreateFormBoxComponent } from './components/forms/create-form-box/create-form-box.component';
import { UpdateFormAgroComponent } from './components/forms/update-form-agro/update-form-agro.component';
import { UpdateFormBoxComponent } from './components/forms/update-form-box/update-form-box.component';
import { BuyFormAgroComponent } from './components/forms/buy-form-agro/buy-form-agro.component';
import { BuyFormBoxComponent } from './components/forms/buy-form-box/buy-form-box.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { SignInComponent } from './components/sign-in/sign-in.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/home' },
  { path: "home", component: HomeComponent },
  { path:"agros", component: AgroListComponent },
  { path:"agros/:idagro", component: AgroDetailComponent },
  { path:"boxes", component: BoxListComponent },
  { path:"boxes/:idbox", component: BoxDetailComponent },
  { path:"newagro", component: CreateFormAgroComponent },
  { path:"newbox", component: CreateFormBoxComponent },
  { path:"agros/:idagro/updateagro", component: UpdateFormAgroComponent },
  { path:"boxes/:idbox/updatebox", component: UpdateFormBoxComponent },
  { path:"agros/:idagro/buyagro", component: BuyFormAgroComponent },
  { path:"boxes/:idbox/buybox", component: BuyFormBoxComponent },
  { path:"logIn", component: LogInComponent },
  { path:"signIn", component: SignInComponent },
  { path: '**', redirectTo: '/home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
