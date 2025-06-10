using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSwapTask : InteractableObject
{
    private Canvas CardUI;
    private Slider SliderUi;
    private bool IsFinished = false;


    private void Awake()
    {
        ProgressTasks.TaskSetup();
    }

    public override void Interact()
    {
        base.Interact();
        CardUI.enabled = true;
    }

    public override void ExitAction()
    {
        base.ExitAction();
        CardUI.enabled = false;
        SliderUi.value = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        CardUI = GetComponentInChildren<Canvas>();
        SliderUi = CardUI.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        base.CheckInteractionInput();

        if (Using)
        {
            if (SliderUi.value == SliderUi.maxValue)
            {
                IsFinished = true;
                ExitAction();
                SetCanInteract(false);
                ProgressTasks.SetProgress(ProgressTasks.GetProgress() + ProgressTasks.GetDistributedValue());
            }


        }

    }
}
