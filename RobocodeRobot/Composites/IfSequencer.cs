namespace RHFreeRoboCodeBots
{
    public class IfSequencer : BTNode
    {
        private System.Func<bool> ifThisIsTrue;
        private BTNode[] inputNodes;

        public IfSequencer(BlackBoard blackBoard, System.Func<bool> ifThisIsTrue,params BTNode[] input)
        {
            this.blackBoard = blackBoard;
            inputNodes = input;
            this.ifThisIsTrue = ifThisIsTrue;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.Out.WriteLine("Checked func<bool>");
            if (!ifThisIsTrue.Invoke()) return BTNodeStatus.Failed;

            foreach (BTNode node in inputNodes)
            {
                BTNodeStatus result = node.Tick();
                switch (result)
                {
                    case BTNodeStatus.Failed:
                    case BTNodeStatus.Running:
                        return result;
                    case BTNodeStatus.Succes:
                        continue;
                }
            }

            return BTNodeStatus.Succes;
        }
    }
}
