using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : IFSMState
{
    protected string animName;
    protected Enemy enemy;
    public EnemyState(Enemy enemy, string animName)
    {
        this.enemy = enemy;
        this.animName = animName;
    }
    public virtual void Enter()
    {
        enemy.animator.CrossFadeInFixedTime(animName, 0.1f);
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicalUpdate()
    {

    }
}