
using UnityEngine;

public class levelchanger : MonoBehaviour
{
   public Animator animator;




    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            fadeToLevel(2);
        }


    }
    public void fadeToLevel (int levelIndex)
    {
        animator.SetTrigger("fadeOut");
    }
}
