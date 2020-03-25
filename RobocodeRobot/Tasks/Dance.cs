namespace RHFreeRoboCodeBots
{
    public class Dance : BTNode
    {
        public Dance(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            if (blackBoard.winEvent == null) return BTNodeStatus.Failed;

            while (true)
            {
                for (int i = 0; i < 7; i++)
                {
                    blackBoard.robot.TurnLeft(20);
                    blackBoard.robot.TurnGunRight(20);

                    System.Drawing.Color c;

                    switch (i)
                    {
                        case 1:
                            c = System.Drawing.Color.Orange;
                            break;
                        case 2:
                            c = System.Drawing.Color.Yellow;
                            break;
                        case 3:
                            c = System.Drawing.Color.Green;
                            break;
                        case 4:
                            c = System.Drawing.Color.Blue;
                            break;
                        case 5:
                            c = System.Drawing.Color.Indigo;
                            break;
                        case 6:
                            c = System.Drawing.Color.Violet;
                            break;
                        default:
                            c = System.Drawing.Color.Red;
                        break;
                    }
                    blackBoard.robot.BodyColor = c;
                    blackBoard.robot.RadarColor = c;
                    blackBoard.robot.GunColor = c;
                }
            }

            return BTNodeStatus.Succes;
        }
    }
}
