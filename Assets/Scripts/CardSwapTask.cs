using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSwapTask : MonoBehaviour
{
    private Player playerent;
    private Button usebutton;
    private Canvas CardUI;
    private Slider SliderUi;
    private bool Active = false;
    private bool pressed = false;
    private bool IsCompleted = false;

    private void Awake()
    {
        ProgressTasks.TaskSetup();
    }

    void Start()
    {
        playerent = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        usebutton = GameObject.FindWithTag("PlayerUI").GetComponentInChildren<Button>();
        CardUI = GetComponentInChildren<Canvas>();
        SliderUi = CardUI.GetComponentInChildren<Slider>();
    }

    void Update()
    {
        if (Active && IsCompleted == false && !pressed)
        {
            usebutton.onClick.AddListener((UnityEngine.Events.UnityAction)this.OnClick);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact();

            }
        }

        if (pressed)
        {
            usebutton.onClick.RemoveListener((UnityEngine.Events.UnityAction)this.OnClick);
            if (SliderUi.value == SliderUi.maxValue)
            {
                CardUI.enabled = false;
                playerent.enabled = true;
                IsCompleted = true;
                pressed = false;
                usebutton.interactable = false;
                ProgressTasks.SetProgress(ProgressTasks.GetProgress() + ProgressTasks.GetDistributedValue());
            }


        }

    }

    void interact()
    {
        usebutton.interactable = false;
        playerent.enabled = false;
        CardUI.enabled = true;
        pressed = true;
    }

    public void OnClick()
    {
        interact();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<Player>().Playert != Player.TypePlayer.Impostor)
        {
            Active = true;
            if (!IsCompleted)
                usebutton.interactable = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            usebutton.interactable = false;
            Active = false;
            usebutton.onClick.RemoveListener((UnityEngine.Events.UnityAction)this.OnClick);
        }
    }
}
