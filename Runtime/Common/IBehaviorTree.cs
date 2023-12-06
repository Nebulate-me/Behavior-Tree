namespace BehaviorTree.Common
{
    public interface IBehaviorTree
    {
        void InitTree();
        Node CreateTree();
        void Evaluate();
    }
}
