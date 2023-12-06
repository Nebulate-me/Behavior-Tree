using BehaviorTree.Common;
using UnityEngine;

namespace BehaviorTree.Enemy
{
    public interface IEnemyBehaviorTree : IBehaviorTree
    {
        void SetData(Transform characterTransform);
        IEnemyAICalculationState AIState { get; }
    }
}