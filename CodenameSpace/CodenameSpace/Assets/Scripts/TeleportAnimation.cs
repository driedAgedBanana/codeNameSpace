using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAnimation : MonoBehaviour
{
    Animator Portal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Portal.SetBool("isOpen", true);
        Portal.SetBool("PlayerInRange", true);
        Debug.Log("Open Up!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Portal.SetBool("isOpen", false);
        Portal.SetBool("PlayerInRange", false);
        Debug.Log("Close!");
    }
    // Start is called before the first frame update
    void Start()
    {
        Portal = GetComponent<Animator>();
    }
}
