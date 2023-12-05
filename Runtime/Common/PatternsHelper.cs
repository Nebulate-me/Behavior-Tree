using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Common
{
    public static class PatternsHelper
    {
        public static List<Vector2> RotatePattern(List<Vector2> pattern, PatternRotation targetRotation)
        {
            var rotatedPattern = new List<Vector2>();

            foreach (var offset in pattern)
            {
                if (targetRotation == PatternRotation.Up)
                {
                    rotatedPattern.Add(new Vector2(offset.x, -offset.y));
                }
                else if (targetRotation == PatternRotation.Right)
                {
                    rotatedPattern.Add(new Vector2(-offset.y, offset.x));
                }
                else if (targetRotation == PatternRotation.Left)
                {
                    rotatedPattern.Add(new Vector2(offset.y, offset.x));
                }
                else
                {
                    rotatedPattern.Add(offset);
                }
            }

            return rotatedPattern;
        }

        private static void TestRotatePattern()
        {
            
        }
    }
}