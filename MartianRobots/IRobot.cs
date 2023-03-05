public interface IRobot
{
    (int x, int y, string orientation) Execute(string instructions);
    void MoveForward();
    void TurnLeft();
    void TurnRight();
}