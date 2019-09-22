namespace Domain.PointSystems
{
    public interface ISportPointSystem
    {
        int WinWeight { get; }
        int DrawWeight { get; }
        int LoseWeight { get; }
    }
}