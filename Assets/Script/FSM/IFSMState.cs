using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFSMState {
    void Enter();
    void LogicalUpdate();
    void Exit();
}