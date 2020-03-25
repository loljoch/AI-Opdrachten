using System;

namespace RHFreeRoboCodeBots
{
    public class Interrupter : BTNode
    {
        private BTNode[] inputNodes;
        private Func<bool> interruptWhen;
        private BTNode interruptBehaviour;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blackBoard">Blackboard</param>
        /// <param name="interruptWhen">Interrupt the sequence when this function is true</param>
        /// <param name="interruptBehaviour">Interrupt the sequence with this behaviour</param>
        /// <param name="input">Behaviour which will be looped</param>
        public Interrupter(BlackBoard blackBoard, Func<bool> interruptWhen, BTNode interruptBehaviour,params BTNode[] input)
        {
            this.blackBoard = blackBoard;
            inputNodes = input;
            this.interruptWhen = interruptWhen;
            this.interruptBehaviour = interruptBehaviour;
        }

        public override BTNodeStatus Tick()
        {
            foreach (BTNode node in inputNodes)
            {
                BTNodeStatus result = (interruptWhen.Invoke())? interruptBehaviour.Tick() : node.Tick();
                
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
