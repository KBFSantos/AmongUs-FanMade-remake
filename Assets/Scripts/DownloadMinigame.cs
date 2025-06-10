using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadMinigame : InteractableObject
{
    public float Download_Speed = 0.065f;
    private Canvas DownloadUI;
    private Slider SliderUi;
    private bool IsFinished = false;

    private void Awake()
    {
        ProgressTasks.TaskSetup();
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        DownloadUI = GetComponentInChildren<Canvas>();
        SliderUi = DownloadUI.GetComponentInChildren<Slider>();
    }

    public override void ExitAction()
    {
        base.ExitAction();
        DownloadUI.enabled = false;
        SliderUi.value = 0f;
    }

    public override void Interact()
    {
        base.Interact();
        DownloadUI.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        base.CheckInteractionInput();


        if (Using)
        {
            if (SliderUi.value < SliderUi.maxValue)
            {
                SliderUi.value += Download_Speed * Time.deltaTime;
            }
            else
            {
                IsFinished = true;
                ExitAction();
                SetCanInteract(false);
                ProgressTasks.SetProgress(ProgressTasks.GetProgress() + ProgressTasks.GetDistributedValue());
            }


        }
    }
}
