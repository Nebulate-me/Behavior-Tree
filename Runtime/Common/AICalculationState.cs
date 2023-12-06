namespace BehaviorTree.Common
{
    public abstract class AICalculationState<T> : IAICalculationState<T> where T : IAICalculationResultType
    {
        private readonly T _resultType;

        protected AICalculationState(T resultType)
        {
            _resultType = resultType;
            Result = resultType.Default;
        }

        public string Result { get; private set; }

        public virtual bool SetResult(string newResult)
        {
            if (!_resultType.IsValid(newResult)) 
                return false;
            
            Result = newResult;
            return true;

        }

        public virtual void Clear()
        {
            Result = _resultType.Default;
        }
    }
}