using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ViewModel : IDisposable
{
    protected List<IDisposable> _disposables = new List<IDisposable>();
    
    public void Dispose()
    {
        foreach (IDisposable disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
