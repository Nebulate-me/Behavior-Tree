using Utilities.Monads;

namespace BehaviorTree
{
    public interface INode
    {
        IMaybe<INode> Parent { get; set; }
        NodeState Evaluate() => NodeState.Failure;
        void SetData(string key, object value);
        IMaybe<object> GetData(string key);
        IMaybe<object> GetDataFromParents(string key);
        bool ClearData(string key);
    }
}