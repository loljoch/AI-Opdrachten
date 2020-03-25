namespace RHFreeRoboCodeBots
{
    public class MoveToDistance : BTNode
    {
        private float dist = 0;

        public MoveToDistance(BlackBoard blackBoard, float dist)
        {
            this.blackBoard = blackBoard;
            this.dist = dist;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.BodyColor = System.Drawing.Color.AliceBlue;

            if (blackBoard.lastScannedRobotEvent == null || blackBoard.lastHitByBulletEvent == null)
            {
                return BTNodeStatus.Failed;
            }

            if (blackBoard.lastScannedRobotEvent.Distance < dist)
            {
                blackBoard.robot.TurnLeft(blackBoard.lastHitByBulletEvent.Bearing);
                blackBoard.robot.Ahead(-(System.Math.Abs(blackBoard.lastScannedRobotEvent.Distance) - System.Math.Abs(dist)));
            }

            return BTNodeStatus.Succes;

        }
    }
}
