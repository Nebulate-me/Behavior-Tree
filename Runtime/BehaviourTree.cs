namespace BehaviorTree
{
    public interface IBehaviorTree
    {
        void InitTree();
        Node CreateTree();
        void Evaluate();
    }
}
