using System;
using UnityEngine;

public class EventCenter : MonoBehaviour
{
    public static Action reelsStopped;
    public static Action<int> reelStop;
    public static Action linesStopped;
    public static Action endOfExpandingAnim;
    public static Action expandingReelStopped;
    public static Action spinFreeSpins;
}
