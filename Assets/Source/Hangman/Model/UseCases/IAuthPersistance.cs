using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAuthPersistance : IDisposable
{
    public void SetAuthenticationPersistance();
}
