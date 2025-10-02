using System;

namespace DailyOperationsDashboard.States
{
    // Concrete State: Pending - Not yet assigned
    public class PendingState : ITaskState
    {
        public void Assign(Task context) => context.SetState(new AssignedState());
        public void StartWork(Task context) { /* Must assign first */ }
        public void Complete(Task context) { /* Invalid */ }
        public void Verify(Task context) { /* Invalid */ }
        public string GetStateName() => "Pending";
    }

    // Concrete State: Assigned - Assigned to someone
    public class AssignedState : ITaskState
    {
        public void Assign(Task context) { /* Already assigned */ }
        public void StartWork(Task context) => context.SetState(new InProgressState());
        public void Complete(Task context) { /* Must start first */ }
        public void Verify(Task context) { /* Invalid */ }
        public string GetStateName() => "Assigned";
    }

    // Concrete State: InProgress - Being worked on
    public class InProgressState : ITaskState
    {
        public void Assign(Task context) { /* Already in progress */ }
        public void StartWork(Task context) { /* Already in progress */ }
        public void Complete(Task context) => context.SetState(new TaskCompletedState());
        public void Verify(Task context) { /* Must complete first */ }
        public string GetStateName() => "InProgress";
    }

    // Concrete State: Completed - Done, awaiting verification
    public class TaskCompletedState : ITaskState
    {
        public void Assign(Task context) { /* Invalid */ }
        public void StartWork(Task context) { /* Invalid */ }
        public void Complete(Task context) { /* Already completed */ }
        public void Verify(Task context) => context.SetState(new VerifiedState());
        public string GetStateName() => "Completed";
    }

    // Concrete State: Verified - Fully complete
    public class VerifiedState : ITaskState
    {
        public void Assign(Task context) { /* Invalid */ }
        public void StartWork(Task context) { /* Invalid */ }
        public void Complete(Task context) { /* Invalid */ }
        public void Verify(Task context) { /* Already verified */ }
        public string GetStateName() => "Verified";
    }
}

