using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]


public class HelpAnimCon : MonoBehaviour
{
    [SerializeField] private Animator Helpanimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Helpanimator.SetBool("Start", true);
        }
    }
    public void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Helpanimator.SetBool("Start", false);
        }
    }
}
