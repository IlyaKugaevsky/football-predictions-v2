import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";

import { TournamentsRoutingModule } from "./tournaments-routing.module";
import { TournamentScheduleComponent } from "./tournament-schedule/tournament-schedule.component";
import { TournamentInfoComponent } from "./tournament-info/tournament-info.component";
import { TourInfoComponent } from "../tours/tour-info/tour-info.component";
import { TourScheduleComponent } from "../tours/tour-schedule/tour-schedule.component";
import { TournamentService } from "./tournament.service";

@NgModule({
  declarations: [
    TournamentScheduleComponent,
    TournamentInfoComponent,
    TourScheduleComponent,
    TourInfoComponent
  ],
  imports: [CommonModule, HttpClientModule, TournamentsRoutingModule],
  providers: [TournamentService]
})
export class TournamentsModule {}
