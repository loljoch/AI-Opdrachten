namespace RHFreeRoboCodeBots
{
    public class TurnBody : BTNode
    {
        private float degrees = 0;

        public TurnBody(BlackBoard blackBoard, float degrees)
        {
            this.blackBoard = blackBoard;
            this.degrees = degrees;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.TurnLeft(degrees);
            return BTNodeStatus.Succes;
        }
    }
}
