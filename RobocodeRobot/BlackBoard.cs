using Robocode;

namespace RHFreeRoboCodeBots
{
    public class BlackBoard
    {
        public AdvancedRobot robot;
        public ScannedRobotEvent lastScannedRobotEvent = null;
        public HitByBulletEvent lastHitByBulletEvent = null;
        public Bullet bullet = null;
        public double mapSize;
        public WinEvent winEvent;
    }
}