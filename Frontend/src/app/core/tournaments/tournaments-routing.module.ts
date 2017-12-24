import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { TournamentScheduleComponent } from "./tournament-schedule/tournament-schedule.component";
import { TournamentListComponent } from "./tournament-list/tournament-list.component";

const routes: Routes = [
  { path: "tournaments/latest/schedule", component: TournamentScheduleComponent },
  { path: "tournaments", component: TournamentListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TournamentsRoutingModule {}
