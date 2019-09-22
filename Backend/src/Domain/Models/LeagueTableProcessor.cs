using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.PointSystems;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Models
{
    public class LeagueTableProcessor
    {

        private readonly Dictionary<string, LeagueTableLine> _table = new Dictionary<string, LeagueTableLine>();
        private readonly ISportPointSystem _pointSystem;
        
        private void AddWin(string teamTitle)
        {
            if (!_table.ContainsKey(teamTitle))
            {
                _table[teamTitle] = new LeagueTableLine();
            }
            
            _table[teamTitle].Games++;
            _table[teamTitle].Wins++;
            _table[teamTitle].Points += _pointSystem.WinWeight;
        }

        private void AddDraw(string homeTeamTitle, string awayTeamTitle)
        {
            if (!_table.ContainsKey(homeTeamTitle))
            {
                _table[homeTeamTitle] = new LeagueTableLine();
            }
            if (!_table.ContainsKey(awayTeamTitle))
            {
                _table[awayTeamTitle] = new LeagueTableLine();
            }
            
            _table[homeTeamTitle].Games++;
            _table[homeTeamTitle].Draws++;
            _table[homeTeamTitle].Points += _pointSystem.DrawWeight;
            
            _table[awayTeamTitle].Games++;
            _table[awayTeamTitle].Draws++;
            _table[awayTeamTitle].Points += _pointSystem.DrawWeight;
        }

        private void AddLose(string teamTitle)
        {
            
            if (!_table.ContainsKey(teamTitle))
            {
                _table[teamTitle] = new LeagueTableLine();
            }
            
            _table[teamTitle].Games++;
            _table[teamTitle].Loses++;
            _table[teamTitle].Points += _pointSystem.LoseWeight;
        }

        private void AddGoals(string homeTeamTitle, int homeGoals, string awayTeamTitle, int awayGoals)
        {
            _table[homeTeamTitle].ScoredGoals += homeGoals;
            _table[homeTeamTitle].ConcededGoals += awayGoals;

            _table[awayTeamTitle].ScoredGoals += awayGoals;
            _table[awayTeamTitle].ConcededGoals += homeGoals;
        }
        public LeagueTableProcessor(string tournamentTitle)
        {
            TournamentTitle = tournamentTitle;
            _pointSystem = new FootballPointSystem();
        }
        
        public LeagueTableProcessor(string tournamentTitle, ISportPointSystem pointSystem)
        {
            TournamentTitle = tournamentTitle;
            _pointSystem = pointSystem;
        }
        
        public string TournamentTitle { get; set; }

        public IReadOnlyDictionary<string, LeagueTableLine> Table => _table;

        public void HandleMatch(string homeTeamTitle, int homeGoals,  string awayTeamTitle, int awayGoals)
        {
            if (homeGoals > awayGoals)
            {
                AddWin(homeTeamTitle);
                AddLose(awayTeamTitle);
                AddGoals(homeTeamTitle, homeGoals, awayTeamTitle, awayGoals);
            }
            else if (homeGoals < awayGoals)
            {
                AddWin(awayTeamTitle);
                AddLose(homeTeamTitle);
                AddGoals(homeTeamTitle, homeGoals, awayTeamTitle, awayGoals);
            }
            else
            {
                AddDraw(homeTeamTitle, awayTeamTitle);
                AddGoals(homeTeamTitle, homeGoals, awayTeamTitle, awayGoals);
            }
        }



        public IReadOnlyDictionary<string, LeagueTableLine> Lines;
    }
}