using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVSystem : InteractableObject
{
    public Canvas CameraUI;



    public override void Interact()
    {
        base.Interact();
        CameraUI.enabled = true;
    }

    public override void ExitAction()
    {
        base.ExitAction();
        CameraUI.enabled = false;
    }


}
