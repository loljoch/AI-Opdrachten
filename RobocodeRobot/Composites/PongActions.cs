namespace RHFreeRoboCodeBots
{
    public class PongActions : BTNode
    {
        private BTNode[] inputNodes;

        private int currentAction = 0;
        private bool goingUp = false;

        public PongActions(BlackBoard blackBoard, params BTNode[] input)
        {
            this.blackBoard = blackBoard;
            inputNodes = input;
        }

        public override BTNodeStatus Tick()
        {
            BTNodeStatus result = inputNodes[currentAction].Tick();
            if (currentAction == inputNodes.Length - 1 || currentAction == 0)
            {
                goingUp = !goingUp;
            }
            currentAction += (goingUp)? 1 : -1;

            return result;
        }
    }
}
