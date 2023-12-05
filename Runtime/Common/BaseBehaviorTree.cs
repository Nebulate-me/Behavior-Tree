namespace BehaviorTree.Common
{
    public abstract class BaseBehaviorTree : IBehaviorTree
    {
        protected Node rootNode;

        public void InitTree()
        {
            rootNode = CreateTree();
        }

        public abstract Node CreateTree();

        public virtual void Evaluate()
        {
            rootNode.Evaluate();
        }
    }
}