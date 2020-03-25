using Robocode.Util;

namespace RHFreeRoboCodeBots
{
    public class TurnGunToEnemy : BTNode
    {
        private int turnsAhead;

        public TurnGunToEnemy(BlackBoard blackBoard, int turnsAhead)
        {
            this.blackBoard = blackBoard;
            this.turnsAhead = turnsAhead;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.BodyColor = System.Drawing.Color.White;

            if (blackBoard.lastScannedRobotEvent == null) return BTNodeStatus.Failed;
            if (blackBoard.lastScannedRobotEvent.Time <= blackBoard.robot.Time - turnsAhead) return BTNodeStatus.Failed;

            double absoluteBearing = blackBoard.robot.HeadingRadians + blackBoard.lastScannedRobotEvent.BearingRadians;
            blackBoard.robot.TurnGunRightRadians(
                Utils.NormalRelativeAngle(absoluteBearing - blackBoard.robot.GunHeadingRadians + 
                (blackBoard.lastScannedRobotEvent.Velocity *  System.Math.Sin(blackBoard.lastScannedRobotEvent.HeadingRadians - absoluteBearing) / 13.0)));

            return BTNodeStatus.Succes;
        }
    }
}
