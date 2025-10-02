using System;
using System.Collections.Generic;

namespace DailyOperationsDashboard.States
{
    // Context class: Maintains current state and delegates behavior
    public class Project
    {
        private IProjectState _currentState;
        public string Name { get; private set; }
        public List<Task> Tasks { get; private set; }

        public Project(string name)
        {
            Name = name;
            Tasks = new List<Task>();
            _currentState = new DraftState(); // Initial state
        }

        // Called by states to transition
        public void SetState(IProjectState newState)
        {
            _currentState = newState;
            Console.WriteLine($"  → {_currentState.GetStateName()}");
        }

        public void AddTask(Task task) => Tasks.Add(task);

        // Delegate all operations to current state
        public void Submit() => _currentState.Submit(this);
        public void Approve() => _currentState.Approve(this);
        public void Kickoff() => _currentState.Kickoff(this);
        public void MarkAtRisk() => _currentState.MarkAtRisk(this);
        public void PutOnHold() => _currentState.PutOnHold(this);
        public void Resume() => _currentState.Resume(this);
        public void Complete() => _currentState.Complete(this);
        public void Archive() => _currentState.Archive(this);
        public string GetCurrentState() => _currentState.GetStateName();
    }
}

