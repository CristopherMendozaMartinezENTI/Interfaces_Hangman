using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Controller : IDisposable
{
    protected List<IDisposable> _disposables = new List<IDisposable>();

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
