namespace RHFreeRoboCodeBots
{
    /// <summary>
    /// The Selector runs all input nodes and return succes if an input nodes returns succesful
    /// </summary>
    public class Selector : BTNode
    {
        private BTNode[] inputNodes;
        public Selector(BlackBoard blackBoard, params BTNode[] input)
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
                        continue;
                    case BTNodeStatus.Running:
                    case BTNodeStatus.Succes:
                        return result;
                        
                }
            }

            return BTNodeStatus.Failed;
        }
    }
}
