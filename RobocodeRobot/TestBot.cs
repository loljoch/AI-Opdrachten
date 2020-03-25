using System;
using Robocode;
using Robocode.Util;

namespace RHFreeRoboCodeBots
{
    public class TestBot : AdvancedRobot
    {
        public BTNode BehaviourTree;
        public BlackBoard blackBoard = new BlackBoard();

        public override void Run()
        {
            blackBoard.robot = this;
            blackBoard.mapSize = (BattleFieldHeight + BattleFieldWidth) / 2;

            //Create behaviours
            //BTNode scanBehaviour = new Interrupter(blackBoard,
            //    () => { return (blackBoard.lastScannedRobotEvent.Time < Time - 0.1f); },
            //    new TurnRadarToEnemy(blackBoard),
            //    new ScanRobot(blackBoard, double.PositiveInfinity)
            //);
            BTNode findEnemyBehaviour = new Sequencer(blackBoard,
                 new ScanRobot(blackBoard, 6.28319f)
            );

            BTNode backAndForthBehaviour = new PongActions(blackBoard,
                new MoveAhead(blackBoard, 60),
                new MoveAhead(blackBoard, -60)
                );


            BTNode findPositionBehaviour = new Sequencer(blackBoard,
                new MoveToDistance(blackBoard, 300)
                );

            BTNode shootBehaviour = new Sequencer(blackBoard,
                new TurnGunToEnemy(blackBoard, 15),
                new Shoot(blackBoard, 2)              
                );

            BTNode dodgeBehaviour = new IfSequencer(blackBoard,
                () => { return blackBoard.lastHitByBulletEvent != null; },

                new TurnPerpendicularToLastBullet(blackBoard),
                backAndForthBehaviour
            );

            BehaviourTree = new Sequencer(blackBoard,

                new Sequencer(blackBoard,
                    new Sequencer(blackBoard,
                        findEnemyBehaviour,
                        shootBehaviour),
                    dodgeBehaviour),

                findPositionBehaviour

            );

            IsAdjustGunForRobotTurn = true;
            IsAdjustRadarForGunTurn = true;

            while (true)
            {
                BehaviourTree.Tick();
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            blackBoard.lastScannedRobotEvent = evnt;
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            blackBoard.lastHitByBulletEvent = evnt;
        }

        public override void OnWin(WinEvent evnt)
        {
            blackBoard.winEvent = evnt;
            new Dance(blackBoard).Tick();
        }


    }
}
