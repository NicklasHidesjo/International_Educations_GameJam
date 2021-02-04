using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Texture[] idleMaterialsFront = new Texture[0];
    [SerializeField] Texture[] idleMaterialsBack = new Texture[0];
    [SerializeField] Texture[] walkMaterialsFront = new Texture[0];
    [SerializeField] Texture[] walkMaterialsBack = new Texture[0];

    [SerializeField] float idleAnimSpeed = 0.15f;
    [SerializeField] float walkAnimSpeed = 0.15f;

    [SerializeField] Material front = null;
    [SerializeField] Material back = null;

    bool idling = false;
    bool walking = false;
    public bool Walking
    {
        set
        {
            walking = value;
            if (walking) { StartCoroutine(HandleWalk()); };
            idling = !value;
            if (idling) { StartCoroutine(HandleIdle()); };
        }
    }

    int index = 0;

    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(walking)
        {
            Debug.Log("walking");
            front.mainTexture = walkMaterialsFront[index];
            back.mainTexture = walkMaterialsBack[index];
        }
        else
        {
            Debug.Log("idling");
            back.mainTexture = idleMaterialsBack[index];
            front.mainTexture = idleMaterialsFront[index];
        }
    }

    IEnumerator HandleIdle()
    {
        index = 0;
        while(idling)
        {
            yield return new WaitForSeconds(idleAnimSpeed);
            if (!idling) break;
            index++;
            if (index >= idleMaterialsFront.Length)
            {
                index = 0;
            }
        }
    }

    IEnumerator HandleWalk()
    {
        index = 0;
        while (walking)
        {
            yield return new WaitForSeconds(idleAnimSpeed);
            if (!walking) break;
            index++;
            if (index >= idleMaterialsFront.Length)
            {
                index = 0;
            }
        }
    }
}
