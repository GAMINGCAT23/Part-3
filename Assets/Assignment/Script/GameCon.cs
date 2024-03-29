using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCon : MonoBehaviour
{
    public static Vector3 playerPosition {  get; private set; }
    public static int MonsterNumber { get; private set; }
    public static void SetMonsterNum(int n) 
    { 
        MonsterNumber = n;
    }

    public static void SetPosition(Vector3 p)
    {
        playerPosition = p;
    }
}
