using Robocode.Util;

namespace RHFreeRoboCodeBots
{
    public class TurnRadarToEnemy : BTNode
    {
        public TurnRadarToEnemy(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            if (blackBoard.lastScannedRobotEvent == null) return BTNodeStatus.Failed;

            double radarTurn = blackBoard.robot.HeadingRadians + blackBoard.lastScannedRobotEvent.BearingRadians - blackBoard.robot.RadarHeadingRadians;
            blackBoard.robot.TurnRadarRightRadians(Utils.NormalRelativeAngle(radarTurn));

            return BTNodeStatus.Succes;
        }
    }
}
