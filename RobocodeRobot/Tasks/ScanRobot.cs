namespace RHFreeRoboCodeBots
{
    public class ScanRobot : BTNode
    {
        private double angle = 0;

        public ScanRobot(BlackBoard blackBoard, double angle)
        {
            this.blackBoard = blackBoard;
            this.angle = angle;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.BodyColor = System.Drawing.Color.Red;

            blackBoard.robot.TurnRadarRightRadians(angle);
            return BTNodeStatus.Succes;
        }
    }
}
