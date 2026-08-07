using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : FSM<EnemyState>
{
    public EnemyState CurState => curState;
}