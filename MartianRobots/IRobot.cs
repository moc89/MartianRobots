public interface IRobot
{
    Tuple<int, int, string> Execute(string instructions);
    void MoveForward();
    void TurnLeft();
    void TurnRight();
}