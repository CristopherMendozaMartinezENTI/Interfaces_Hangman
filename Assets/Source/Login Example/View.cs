using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class View : MonoBehaviour
{
    protected List<IDisposable> _disposables = new List<IDisposable>();

    protected virtual void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
