using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SharedData", menuName = "ScriptableObjects/SharedData", order = 1)]
public class SoldierLandingController : ScriptableObject
{
    public List<Info> info = new List<Info>();
    public bool stopInstantiate;
  

}

[System.Serializable]
public class Info
{
    public List<float> storePosition = new List<float>();
   
    public int dupCount;

    public Info(List<float> storePosition, int dupCount)
    {
        this.storePosition = storePosition;
        this.dupCount = dupCount;
    }
}
public class RealtimeInfo
{
    public List<Vector2> currentPosition = new List<Vector2>();
    public int dupCount;

    public RealtimeInfo(List<float> storePosition, int dupCount)
    {
        this.storePosition = storePosition;
        this.dupCount = dupCount;
    }
}