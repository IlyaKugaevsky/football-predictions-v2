import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";

import { TournamentsRoutingModule } from "./tournaments-routing.module";
import { TournamentService } from "./tournament.service";

import { TournamentListComponent } from "./tournament-list/tournament-list.component";
import { TournamentScheduleComponent } from "./tournament-schedule/tournament-schedule.component";
import { TournamentInfoComponent } from "./tournament-info/tournament-info.component";
import { TourInfoComponent } from "../tours/tour-info/tour-info.component";
import { TourScheduleComponent } from "../tours/tour-schedule/tour-schedule.component";
import { MatchTableComponent } from "../matches/match-table/match-table.component";
import { MatchInfoComponent } from "../matches/match-info/match-info.component";

@NgModule({
  declarations: [
    TournamentListComponent,
    TournamentScheduleComponent,
    TournamentInfoComponent,
    TourScheduleComponent,
    TourInfoComponent,
    MatchTableComponent,
    MatchInfoComponent
  ],
  imports: [CommonModule, HttpClientModule, TournamentsRoutingModule],
  providers: [TournamentService]
})
export class TournamentsModule {}
