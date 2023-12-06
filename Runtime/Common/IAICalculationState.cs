namespace BehaviorTree.Common
{
    public interface IAICalculationState<T> where T : IAICalculationResultType
    {
        string Result { get; }
        bool SetResult(string newResult);
        void Clear();
    }
}