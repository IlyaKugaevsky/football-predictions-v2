import { TournamentInfo } from "../tournament-info/tournament-info.model";
import { TourSchedule } from "../../tours/tour-schedule/tour-schedule.model";

export class TournamentSchedule {
  tournamentInfo: TournamentInfo;
  tourSchedules: TourSchedule[];
}
