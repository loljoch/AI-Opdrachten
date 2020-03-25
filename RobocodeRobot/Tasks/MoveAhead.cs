namespace RHFreeRoboCodeBots
{
    public class MoveAhead : BTNode
    {
        private int moveDistance = 0;

        public MoveAhead(BlackBoard blackBoard, int moveDistance)
        {
            this.blackBoard = blackBoard;
            this.moveDistance = moveDistance;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.Ahead(moveDistance);
            return BTNodeStatus.Succes;
        }
    }
}
