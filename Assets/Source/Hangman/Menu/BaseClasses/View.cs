using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class View : MonoBehaviour
{
    protected List<IDisposable> _disposables = new List<IDisposable>();
    public abstract void SetViewModel(ViewModel model);
    protected virtual void OnDestroy() {
        foreach (var disposable in _disposables)
        {
            if (disposable != null)
                disposable.Dispose();
        }
    }
}
