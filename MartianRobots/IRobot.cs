public interface IRobot
{
    void Execute(string instructions);
    void MoveForward();
    void TurnLeft();
    void TurnRight();
}