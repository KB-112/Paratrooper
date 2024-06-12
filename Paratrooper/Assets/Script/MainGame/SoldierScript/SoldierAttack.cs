using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData", order = 2)]
public class SoldierAttack : ScriptableObject
{
    public GetMaxEnemy getMaxEnemy;
    public AttackRulesInfo attackRulesInfo;
    public SoldierLandingController soldierLandingController;

    void AttackInProccess()
    {
        //if (!soldierLandingController.gameOver)
        {
            if (getMaxEnemy.left.Count > getMaxEnemy.right.Count)
            {
                attackRulesInfo.left = true;
            }
            else
            {
                attackRulesInfo.left = false;
            }
        }
    //    SortNearestElement(attackRulesInfo.left);
       
    }

   
    
    //List<int>SortNearestElement(bool left)
    //{
    //    List<int> nearestPlace = new List<int>();
    //    if (left)
    //    {
    //        nearestPlace = getMaxEnemy.left;
    //    }
    //    else

    //    {
    //        nearestPlace = getMaxEnemy.right;
    //    }
       
    //    int i , j ,temp;
    //    bool swapped;
    //    for (i = 0; i < nearestPlace.Count - 1; i++)
    //    {
    //        swapped = false;
    //        for (j = 0; j < nearestPlace.Count - i - 1; j++)
    //        {
    //            if (nearestPlace[j] > nearestPlace[j + 1])
    //            {
                    
    //                temp = nearestPlace[j];
    //                nearestPlace[j] = nearestPlace[j + 1];
    //                nearestPlace[j + 1] = temp;
    //                swapped = true;
    //            }
               
    //        }

           
    //        if (swapped == false)
    //            break;
    //    }
    //    return nearestPlace;

    //}


}
public class AttackRulesInfo
{
    public bool left;
    public int nearestPos;
    

}
[System.Serializable]
public class GetMaxEnemy {

    public List<Vector2> left;
    public List<int> leftId;
    public List<Vector2> right;
    public List<int> rightId;

    
}



