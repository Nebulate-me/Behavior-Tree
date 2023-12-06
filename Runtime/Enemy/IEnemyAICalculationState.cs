using System.Collections.Generic;
using BehaviorTree.Common;
using UnityEngine;

namespace BehaviorTree.Enemy
{
    public interface IEnemyAICalculationState : IAICalculationState<EnemyAICalculationResultType>
    {
        public Transform Transform { get; set; }
        public List<Vector2> MoveSequence { get; }
        public List<Vector2> AttackPoints { get; }
    }
}