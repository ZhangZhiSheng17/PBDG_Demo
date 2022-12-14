using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameEventSubject
{
    private List<IGameEventObserver> m_Observers = new List<IGameEventObserver>();//观察者
    private System.Object m_Param = null; //发生事件时附加的参数

    //加入
    public void Attach(IGameEventObserver theObserver)
    {
        m_Observers.Add(theObserver);
    }

    //取消
    public void Detach(IGameEventObserver theObserver)
    {
        m_Observers.Remove(theObserver);
    }

    //通知
    public void Notify()
    {
        foreach (IGameEventObserver theObserver in m_Observers)
        {
            theObserver.Update();
        }
    }

    public virtual void SetParam(System.Object Param)
    {
        m_Param = Param;
    }
}
