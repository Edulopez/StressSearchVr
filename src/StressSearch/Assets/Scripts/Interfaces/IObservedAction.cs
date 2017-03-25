using UnityEngine;
using System.Collections;

public interface IObservedAction
{
    void Idle();

    void BeingObserved();

    void StopedBeingObserved();

    bool isObservable { get;  }
}
