using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers with the given tag.
 * using enemy counter to know if player won the lvl or we should reload same one
 */


public class DestroyOnTrigger : MonoBehaviour {

    
    [SerializeField] private TMPro.TextMeshPro winnerText;
    
    int count = 0;

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {   

            Destroy(other.gameObject.GetComponentInParent<Rigidbody>().gameObject);
            count++;
        }

        

    }
    public int getCount()
    {
        return this.count;
    }

   
}
