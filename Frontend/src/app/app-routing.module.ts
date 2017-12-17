import { NgModule }      from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TournamentScheduleComponent } from "./tournaments/tournament-schedule.component";

const routes: Routes = [
  // { path: "tournaments", component: TournamentScheduleComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}