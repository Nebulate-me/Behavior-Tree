using System.Collections.Generic;

namespace BehaviorTree
{
    public class Node : INode
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new();

        private Dictionary<string, object> _dataContext = new();

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (var child in children)
                _Attach(child);
        }

        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.Failure;

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;

            if (_dataContext.TryGetValue(key, out value))
                return value;

            Node node = parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                    return value;
                node = node.parent;
            }

            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);

                if (cleared)
                    return true;

                node = node.parent;
            }

            return false;
        }
    }

    public interface INode
    {
        NodeState Evaluate() => NodeState.Failure;
        void SetData(string key, object value);
        object GetData(string key);
        bool ClearData(string key);
    }
}
