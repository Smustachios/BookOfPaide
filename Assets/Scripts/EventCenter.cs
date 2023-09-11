using System;
using UnityEngine;

public class EventCenter : MonoBehaviour
{
    public static Action reelsStopped;
    public static Action<int> reelStop;
    public static Action linesStopped;
}
