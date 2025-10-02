namespace DailyOperationsDashboard.States
{
    // State interface: Defines operations for all task states
    public interface ITaskState
    {
        void Assign(Task context);
        void StartWork(Task context);
        void Complete(Task context);
        void Verify(Task context);
        string GetStateName();
    }
}

