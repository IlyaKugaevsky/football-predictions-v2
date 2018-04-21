namespace Domain.PointSystems
{
    public class ThreePointSystem: IPointSystem
    {
        public int OutcomeWeight => 1;
        public int DifferenceWeight => 2;
        public int ScoreWeight => 3;
    }
}
