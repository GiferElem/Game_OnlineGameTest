using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T> where T : IFSMState
{
    protected T curState;

    public Dictionary<Type,T> stateDict { get; protected set; }
    public FSM()
    {
        stateDict = new();
    }

    //Ìí¼Ó
    public void AddState(T state)
    {
        stateDict.Add(state.GetType(), state);
    }
    //±ä»»
    public void ChangeState(Type newState)
    {
        curState.Exit();
        curState = stateDict[newState];
        curState.Enter();
    }
    //Ñ­»·Âß¼­
    public void OnUpdate()
    {
        curState.LogicalUpdate();
    }
    public void SwitchOn(Type startState)
    {
        curState = stateDict[startState];
        curState.Enter();
    }
}