namespace RHFreeRoboCodeBots
{
    public class Shoot : BTNode
    {
        private float power = 0;

        public Shoot(BlackBoard blackBoard, float power)
        {
            this.blackBoard = blackBoard;
            this.power = power;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.BodyColor = System.Drawing.Color.Green;

            Robocode.Bullet bullet = null;

            if (blackBoard.robot.GunHeat == 0)
            {
                bullet = blackBoard.robot.FireBullet(power / (blackBoard.lastScannedRobotEvent.Distance / blackBoard.mapSize));
                blackBoard.robot.Out.WriteLine($"power = {power / (blackBoard.lastScannedRobotEvent.Distance / blackBoard.mapSize)}");

            }

            if(bullet == null)
            {
                return BTNodeStatus.Running;
            } else
            {
                blackBoard.bullet = bullet;
                return BTNodeStatus.Succes;
            }
        }
    }
}
