using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * This component restart in current tutorial whenever it triggers with the given tag.
 * other objects he destroying like enemys
 */


public class DestroyOnTriggerTutorial : MonoBehaviour
{

    [SerializeField] private Transform player;

    private Vector3 PlayerStartPos;

    public void Start()
    {
        PlayerStartPos = player.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == player.tag && enabled)
        {
            player.position = PlayerStartPos;
            TutorialManager.Instance.ReloadPrevTutorial();
        }
        else
        {
            Destroy(other.gameObject);
        }



    }

}
