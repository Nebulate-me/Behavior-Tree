namespace BehaviorTree.Common
{
    public abstract class BaseBehaviorTree : IBehaviorTree
    {
        protected Node RootNode;

        public void InitTree()
        {
            RootNode = CreateTree();
        }

        public abstract Node CreateTree();

        public virtual void Evaluate()
        {
            RootNode.Evaluate();
        }
    }
}