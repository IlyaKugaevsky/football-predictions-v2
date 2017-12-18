import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { AppRoutingModule } from "./app-routing.module";
import { TournamentsModule } from "./tournaments/tournaments.module";
import { AppComponent } from "./app.component";
import { HomePageComponent } from "./home/home-page.component";

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    TournamentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }