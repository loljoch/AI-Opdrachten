namespace RHFreeRoboCodeBots
{
    public class Sequencer : BTNode
    {
        private BTNode[] inputNodes;
        public Sequencer(BlackBoard blackBoard, params BTNode[] input)
        {
            this.blackBoard = blackBoard;
            inputNodes = input;
        }

        public override BTNodeStatus Tick()
        {
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
