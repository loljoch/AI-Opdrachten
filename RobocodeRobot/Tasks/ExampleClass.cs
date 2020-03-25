namespace RHFreeRoboCodeBots
{
    public class ExampleClass : BTNode
    {
        private int exampleVar = 0;

        public ExampleClass(BlackBoard blackBoard, int exampleVar)
        {
            this.blackBoard = blackBoard;
            this.exampleVar = exampleVar;
        }

        public override BTNodeStatus Tick()
        {
            //Do something

            //if succesful return succesful
            //return BTNodeStatus.Succes;

            //if failed return failed
            //return BTNodeStatus.Failed;

            //else return running
            //return BTNodeStatus.Running;
            return BTNodeStatus.Failed;
        }
    }
}
