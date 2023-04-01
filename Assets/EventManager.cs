using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action SpeedRegulation;
    public static Action GameOverControl;
    public static Action<Vector3> CannonPosition;
}