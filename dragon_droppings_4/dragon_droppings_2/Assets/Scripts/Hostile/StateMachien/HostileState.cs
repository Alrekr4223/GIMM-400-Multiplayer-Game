using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileState{

    protected HostileController hostileController;

    public abstract void CheckTransition();
    public abstract void Act();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public HostileState(HostileController f_hostileController)
    {
        this.hostileController = f_hostileController;
    }
}
