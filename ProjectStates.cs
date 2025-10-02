using System;

namespace DailyOperationsDashboard.States
{
    // Concrete State: Draft - Initial state
    public class DraftState : IProjectState
    {
        public void Submit(Project context) => context.SetState(new SubmittedState());
        public void Approve(Project context) { /* Invalid from Draft */ }
        public void Kickoff(Project context) { /* Invalid from Draft */ }
        public void MarkAtRisk(Project context) { /* Invalid from Draft */ }
        public void PutOnHold(Project context) { /* Invalid from Draft */ }
        public void Resume(Project context) { /* Invalid from Draft */ }
        public void Complete(Project context) { /* Invalid from Draft */ }
        public void Archive(Project context) { /* Invalid from Draft */ }
        public string GetStateName() => "Draft";
    }

    // Concrete State: Submitted - Awaiting approval
    public class SubmittedState : IProjectState
    {
        public void Submit(Project context) { /* Already submitted */ }
        public void Approve(Project context) => context.SetState(new ApprovedState());
        public void Kickoff(Project context) { /* Need approval first */ }
        public void MarkAtRisk(Project context) { /* Invalid */ }
        public void PutOnHold(Project context) { /* Invalid */ }
        public void Resume(Project context) { /* Invalid */ }
        public void Complete(Project context) { /* Invalid */ }
        public void Archive(Project context) { /* Invalid */ }
        public string GetStateName() => "Submitted";
    }

    // Concrete State: Approved - Ready to start
    public class ApprovedState : IProjectState
    {
        public void Submit(Project context) { /* Already approved */ }
        public void Approve(Project context) { /* Already approved */ }
        public void Kickoff(Project context) => context.SetState(new ActiveState());
        public void MarkAtRisk(Project context) { /* Not active yet */ }
        public void PutOnHold(Project context) => context.SetState(new OnHoldState());
        public void Resume(Project context) { /* Not on hold */ }
        public void Complete(Project context) { /* Not started */ }
        public void Archive(Project context) { /* Not completed */ }
        public string GetStateName() => "Approved";
    }

    // Concrete State: Active - Work in progress
    public class ActiveState : IProjectState
    {
        public void Submit(Project context) { /* Already active */ }
        public void Approve(Project context) { /* Already active */ }
        public void Kickoff(Project context) { /* Already active */ }
        public void MarkAtRisk(Project context) => context.SetState(new AtRiskState());
        public void PutOnHold(Project context) => context.SetState(new OnHoldState());
        public void Resume(Project context) { /* Already active */ }
        public void Complete(Project context) => context.SetState(new CompletedState());
        public void Archive(Project context) { /* Must complete first */ }
        public string GetStateName() => "Active";
    }

    // Concrete State: AtRisk - Needs attention
    public class AtRiskState : IProjectState
    {
        public void Submit(Project context) { /* Invalid */ }
        public void Approve(Project context) { /* Invalid */ }
        public void Kickoff(Project context) { /* Invalid */ }
        public void MarkAtRisk(Project context) { /* Already at risk */ }
        public void PutOnHold(Project context) => context.SetState(new OnHoldState());
        public void Resume(Project context) => context.SetState(new ActiveState());
        public void Complete(Project context) => context.SetState(new CompletedState());
        public void Archive(Project context) { /* Must complete first */ }
        public string GetStateName() => "AtRisk";
    }

    // Concrete State: OnHold - Temporarily paused
    public class OnHoldState : IProjectState
    {
        public void Submit(Project context) { /* Invalid */ }
        public void Approve(Project context) { /* Invalid */ }
        public void Kickoff(Project context) { /* Invalid */ }
        public void MarkAtRisk(Project context) { /* Invalid */ }
        public void PutOnHold(Project context) { /* Already on hold */ }
        public void Resume(Project context) => context.SetState(new ActiveState());
        public void Complete(Project context) { /* Must resume first */ }
        public void Archive(Project context) { /* Invalid */ }
        public string GetStateName() => "OnHold";
    }

    // Concrete State: Completed - Work finished
    public class CompletedState : IProjectState
    {
        public void Submit(Project context) { /* Invalid */ }
        public void Approve(Project context) { /* Invalid */ }
        public void Kickoff(Project context) { /* Invalid */ }
        public void MarkAtRisk(Project context) { /* Invalid */ }
        public void PutOnHold(Project context) { /* Invalid */ }
        public void Resume(Project context) { /* Invalid */ }
        public void Complete(Project context) { /* Already completed */ }
        public void Archive(Project context) => context.SetState(new ArchivedState());
        public string GetStateName() => "Completed";
    }

    // Concrete State: Archived - Final state
    public class ArchivedState : IProjectState
    {
        public void Submit(Project context) { /* Invalid */ }
        public void Approve(Project context) { /* Invalid */ }
        public void Kickoff(Project context) { /* Invalid */ }
        public void MarkAtRisk(Project context) { /* Invalid */ }
        public void PutOnHold(Project context) { /* Invalid */ }
        public void Resume(Project context) { /* Invalid */ }
        public void Complete(Project context) { /* Invalid */ }
        public void Archive(Project context) { /* Already archived */ }
        public string GetStateName() => "Archived";
    }
}

