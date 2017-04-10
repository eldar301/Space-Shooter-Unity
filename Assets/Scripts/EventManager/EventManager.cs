using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager {

	public class UnityEventExtended<T> : UnityEvent<T> {}

	public static UnityEvent<GameObject> onAirCraftCrashed = new UnityEventExtended<GameObject> ();
	public static UnityEvent onGamePaused = new UnityEvent();
	public static UnityEvent onGameResumed = new UnityEvent();
}
