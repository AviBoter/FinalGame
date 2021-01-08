using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This component attached to each enemy and count them
 */
public class EnemyCounter : MonoBehaviour
{
    static object Lock = new object();
    private static int count = 0;
    public void Awake()
    {
        count++;
    }

    public static void EnemyDie()
    {
        lock (Lock)
        {
            count--;
            Debug.Log(EnemyCounter.getCount());

        }
    }

    public static int getCount() {
        return count;
    }

    public static void setCount(int newCount)
    {

        lock (Lock)
        {
            count = newCount;
        }
    }


}
