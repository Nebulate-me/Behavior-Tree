using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Common
{
    public class EnemyAICalculationState : IAICalculationState
    {
        public Transform Transform;
        public EnemyAIResultType Result = EnemyAIResultType.None;
        public List<Vector2> MoveSequence = new();
        public List<Vector2> AttackPoints = new();

        public void Clear()
        {
            Result = EnemyAIResultType.None;
            MoveSequence.Clear();
            AttackPoints.Clear();
        }
    }
}