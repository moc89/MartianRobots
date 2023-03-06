public interface IRobot
{
    (int x, int y, string orientation, bool isRobotLost) Execute(string instructions);
    bool MoveForward();
    void TurnLeft();
    void TurnRight();
}