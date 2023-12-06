namespace BehaviorTree.Common
{
    public interface IAICalculationResultType
    {
        string Default { get; }
        bool IsValid(string value);
    }
}