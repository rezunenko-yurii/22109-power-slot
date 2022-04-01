using UnityEngine;
using System;

using IEnumerator = System.Collections.IEnumerator;

public abstract class Instruction : IEnumerator, IInstruction
{
    private Instruction _current;
    object IEnumerator.Current => _current;

    private object _routine;
    public MonoBehaviour Parent { get; private set; }

    public bool IsExecuting { get; private set; }
    public bool IsPaused { get; private set; }

    private bool IsStopped { get; set; }

    public event Action<Instruction> Started;
    public event Action<Instruction> Paused;
    public event Action<Instruction> Cancelled;
    public event Action<Instruction> Terminated;
    public event Action<Instruction> Done;

    void IEnumerator.Reset()
    {
        IsPaused = false;
        IsStopped = false;

        _routine = null;
    }

    bool IEnumerator.MoveNext()
    {
        if (IsStopped)
        {
            (this as IEnumerator).Reset();
            return false;
        }

        if (!IsExecuting)
        {
            IsExecuting = true;
            _routine = new object();

            OnStarted();
            Started?.Invoke(this);
        }

        if (_current != null)
            return true;

        if (IsPaused)
            return true;

        if (!Update())
        {
            Debug.Log("Instruction is Done");
            OnDone();
            Done?.Invoke(this);

            IsStopped = true;
            return false;
        }

        return true;
    }

    protected Instruction(MonoBehaviour parent) => Parent = parent;

    public void Pause()
    {
        if (IsExecuting && !IsPaused)
        {
            IsPaused = true;

            OnPaused();
            Paused?.Invoke(this);
        }
    }

    public void Resume()
    {
        IsPaused = false;
        OnResumed();
    }

    public void Terminate()
    {
        if (Stop())
        {
            OnTerminated();
            Terminated?.Invoke(this);
        }
    }

    private bool Stop()
    {
        if (IsExecuting)
        {
            if (_routine is Coroutine)
                Parent.StopCoroutine(_routine as Coroutine);

            (this as IEnumerator).Reset();

            return IsStopped = true;
        }

        return false;
    }

    public Instruction Execute()
    {
        if (_current != null)
        {
            Debug.LogWarning($"Instruction { GetType().Name} is currently waiting for another one and can't be stared right now.");
            return this;
        }

        if (!IsExecuting)
        {
            IsExecuting = true;
            _routine = Parent.StartCoroutine(this);

            return this;
        }

        Debug.LogWarning($"Instruction { GetType().Name} is already executing.");
        return this;
    }

    public Instruction Execute(MonoBehaviour parent)
    {
        if (_current != null)
        {
            Debug.LogWarning($"Instruction { GetType().Name} is currently waiting for another one and can't be stared right now.");
            return this;
        }

        if (!IsExecuting)
        {
            IsExecuting = true;
            _routine = (Parent = parent).StartCoroutine(this);

            return this;
        }

        Debug.LogWarning($"Instruction { GetType().Name} is already executing.");
        return this;
    }

    public void Reset()
    {
        Terminate();

        Started = null;
        Paused = null;
        Terminated = null;
        Done = null;
    }

    protected virtual void OnStarted() { }
    protected virtual void OnPaused() { }
    protected virtual void OnResumed() { }
    protected virtual void OnTerminated() { }
    protected virtual void OnDone() { }

    protected abstract bool Update();
}