import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { LOCALE_ID } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { TournamentsModule } from "./core/tournaments/tournaments.module";
import { AppComponent } from "./app.component";
import { HomePageComponent } from "./core/home/home-page.component";
import { HeaderComponent } from "./core/shared/header.component";

import { registerLocaleData } from "@angular/common";
import localeRu from "@angular/common/locales/ru";

registerLocaleData(localeRu, "ru");

@NgModule({
  declarations: [AppComponent, HomePageComponent, HeaderComponent],
  imports: [BrowserModule, RouterModule, AppRoutingModule, TournamentsModule],
  providers: [{ provide: LOCALE_ID, useValue: "ru" }],
  bootstrap: [AppComponent]
})
export class AppModule {}
