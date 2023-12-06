using System.Collections.Generic;
using Utilities.Monads;

namespace BehaviorTree
{
    public class Node : INode
    {
        protected NodeState State;

        protected readonly List<INode> Children = new();

        private readonly Dictionary<string, object> _dataContext = new();
        
        public IMaybe<INode> Parent { get; set; }

        public Node()
        {
            Parent = Maybe.Empty<INode>();
        }

        public Node(List<INode> children)
        {
            foreach (var child in children)
                Attach(child);
        }

        private void Attach(INode node)
        {
            node.Parent = this.ToMaybe<INode>();
            Children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.Failure;

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public IMaybe<object> GetData(string key)
        {
            return _dataContext
                .GetValueOrEmpty(key)
                .Match(
                    value => value.ToMaybe(),
                    GetDataFromParents(key));
        }

        /// <summary>
        /// Searches parent nodes for Data recursively until they are over or the data is found
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IMaybe<object> GetDataFromParents(string key)
        {
            return Parent.Match(
                parent => parent.GetData(key)
                    .Match(
                        data => data.ToMaybe(),
                        parent.GetDataFromParents(key)),
                Maybe.Empty<object>());
        }
        
        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            return ClearDataFromParents(key);
        }

        private bool ClearDataFromParents(string key)
        {
            return Parent.Match(parent => parent.ClearData(key), false);
        }
    }
}