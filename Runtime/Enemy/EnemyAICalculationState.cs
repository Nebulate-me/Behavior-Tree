using System.Collections.Generic;
using BehaviorTree.Common;
using UnityEngine;

namespace BehaviorTree.Enemy
{
    /// <summary>
    /// Sample class for enemy state calculation 
    /// </summary>
    public class EnemyAICalculationState : AICalculationState<EnemyAICalculationResultType>, IEnemyAICalculationState
    {
        public Transform Transform { get; set; }
        public List<Vector2> MoveSequence { get; } = new();
        public List<Vector2> AttackPoints { get; } = new();

        public EnemyAICalculationState(EnemyAICalculationResultType resultType) : base(resultType)
        {
        }

        public override void Clear()
        {
            base.Clear();
            MoveSequence.Clear();
            AttackPoints.Clear();
        }
    }
}