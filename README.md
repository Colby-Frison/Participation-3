# State Pattern Skeleton - CS 4213 Participation 3

## Overview

Lightweight skeleton demonstrating the State Pattern for:
1. **Project Lifecycle**: Draft → Submitted → Approved → Active → AtRisk → OnHold → Completed → Archived
2. **Task Lifecycle**: Pending → Assigned → InProgress → Completed → Verified

## Structure

**State Pattern Components:**
1. **State Interfaces** (`IProjectState`, `ITaskState`) - Define operations
2. **Context Classes** (`Project`, `Task`) - Delegate to current state
3. **Concrete States** (8 project states, 5 task states) - Implement state-specific behavior

## Benefits Over Nested Switch Statements

### Reduced Complexity
- **Switch**: Deeply nested conditionals for 8 states × multiple operations
- **State Pattern**: Each state is a focused class

### Improved Maintainability  
- Each state isolated in its own class
- Changes don't ripple through unrelated states
- Follows Single Responsibility Principle

### Better Scalability
- Add new states by creating new classes (Open/Closed Principle)
- Compiler enforces implementation of all operations
- No modification of existing code needed

## How to Run

```bash
dotnet build
dotnet run
```

## Output Example
```
=== State Pattern Demo ===

Project Lifecycle:
State: Draft

  → Submitted
  → Approved
  → Active
  → Completed
  → Archived

Final: Archived
```

---

**Note:** This is a lightweight skeleton demonstrating structure, not a full implementation.

