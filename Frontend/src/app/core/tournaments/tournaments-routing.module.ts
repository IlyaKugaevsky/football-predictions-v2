import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { TournamentScheduleComponent } from "./tournament-schedule/tournament-schedule.component";

const routes: Routes = [
  { path: "tournaments/latest/schedule", component: TournamentScheduleComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TournamentsRoutingModule {}
