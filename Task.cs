using System;

namespace DailyOperationsDashboard.States
{
    // Context class: Maintains current state and delegates behavior
    public class Task
    {
        private ITaskState _currentState;
        public string Name { get; private set; }
        public string? AssignedTo { get; set; }

        public Task(string name)
        {
            Name = name;
            _currentState = new PendingState(); // Initial state
        }

        // Called by states to transition
        public void SetState(ITaskState newState)
        {
            _currentState = newState;
            Console.WriteLine($"  → {_currentState.GetStateName()}");
        }

        // Delegate all operations to current state
        public void Assign(string assignee)
        {
            AssignedTo = assignee;
            _currentState.Assign(this);
        }

        public void StartWork() => _currentState.StartWork(this);
        public void Complete() => _currentState.Complete(this);
        public void Verify() => _currentState.Verify(this);
        public string GetCurrentState() => _currentState.GetStateName();
    }
}

