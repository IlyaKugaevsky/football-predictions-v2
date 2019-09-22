namespace Domain.PointSystems
{
    public class FootballPointSystem: ISportPointSystem
    {
        public int LoseWeight => 0;
        public int DrawWeight => 1;
        public int WinWeight => 3;
    }
}