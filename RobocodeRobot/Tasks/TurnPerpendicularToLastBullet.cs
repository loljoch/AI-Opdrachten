namespace RHFreeRoboCodeBots
{
    public class TurnPerpendicularToLastBullet : BTNode
    {
        public TurnPerpendicularToLastBullet(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            if (blackBoard.lastHitByBulletEvent == null) return BTNodeStatus.Failed;

            //if (blackBoard.robot.Heading < 70 - blackBoard.lastHitByBulletEvent.Bearing || blackBoard.robot.Heading > 110 - blackBoard.lastHitByBulletEvent.Bearing) return BTNodeStatus.Succes;

            blackBoard.robot.TurnLeft(90 - blackBoard.lastHitByBulletEvent.Bearing);
            return BTNodeStatus.Succes;
        }
    }
}
