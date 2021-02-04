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

    [SerializeField] bool walk = false;

    int index = 0;

    private void Start()
    {
        StartCoroutine(HandleIdle());
    }

    void Update()
    {
        if(walk)
        {
            front.mainTexture = walkMaterialsFront[index];
            back.mainTexture = walkMaterialsFront[index];
        }
        else
        {
            Debug.Log(index);
            back.mainTexture = idleMaterialsBack[index];
            front.mainTexture = idleMaterialsFront[index];
        }
    }

    IEnumerator HandleIdle()
    {
        index = 0;
        while(!walk)
        {
            yield return new WaitForSeconds(idleAnimSpeed);
            index++;
            if (index >= idleMaterialsFront.Length)
            {
                index = 0;
            }
        }
    }
}
