import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
import { MenuComponent } from './components/menu/menu.component';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    AgroListComponent,
    AgroDetailComponent,
    BoxListComponent,
    BoxDetailComponent,
    CreateFormAgroComponent,
    CreateFormBoxComponent,
    UpdateFormAgroComponent,
    UpdateFormBoxComponent,
    BuyFormAgroComponent,
    BuyFormBoxComponent,
    MenuComponent,
    HomeComponent,
    FooterComponent,
    LogInComponent,
    SignInComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
