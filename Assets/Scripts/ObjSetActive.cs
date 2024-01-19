using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSetActive : MonoBehaviour
{
    public GameObject targetObject;
    //public GameObject targetObject2;
    //public GameObject targetObject3;
    //public GameObject targetObject4;
    //public GameObject targetObject5;
    private bool hasCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasCollided)
        {
            targetObject.SetActive(true);
            hasCollided = true;

            //Animator animator = targetObject.GetComponent<Animator>();

            /*if (animator != null)
            {
                animator.SetTrigger("PlayAnimation");

                float animationLength = GetAnimationLength(animator);
                Invoke("DeleteObject", animationLength);
            }
            else
            {
                Debug.LogError("Animator component not found on the target object.");
            }
            */
        }
    }

    /*
    private float GetAnimationLength(Animator animator)
    {
        float length = 0f;
   
        AnimatorClipInfo[] clips = animator.GetCurrentAnimatorClipInfo(0);

        if (clips.Length > 0)
        {
            length = clips[0].clip.length;
        }

        return length;
    }
    

    private void DeleteObject()
    {
        Destroy(targetObject);
    }
    */
}