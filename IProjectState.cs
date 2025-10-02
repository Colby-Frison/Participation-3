namespace DailyOperationsDashboard.States
{
    // State interface: Defines operations for all project states
    public interface IProjectState
    {
        void Submit(Project context);
        void Approve(Project context);
        void Kickoff(Project context);
        void MarkAtRisk(Project context);
        void PutOnHold(Project context);
        void Resume(Project context);
        void Complete(Project context);
        void Archive(Project context);
        string GetStateName();
    }
}

