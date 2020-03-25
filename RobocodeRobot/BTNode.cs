namespace RHFreeRoboCodeBots
{
    public enum BTNodeStatus
    {
        Failed,
        Running,
        Succes
    }

    public abstract class BTNode
    {
        protected BlackBoard blackBoard;
        public abstract BTNodeStatus Tick();
    }
}
