using System;

public interface IInstruction
{
    bool IsExecuting { get; }
    bool IsPaused { get; }

    Instruction Execute();
    void Pause();
    void Resume();
    void Terminate();

    event Action<Instruction> Started;
    event Action<Instruction> Paused;
    event Action<Instruction> Cancelled;
    event Action<Instruction> Done;
}