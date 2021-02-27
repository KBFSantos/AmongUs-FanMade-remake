using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DownloadMinigame : MonoBehaviour
{
    public float Upload_Speed = 0.065f;
    private Player Jogador;
    private Button botao;
    private Canvas DownloadUI;
    private Slider SliderUi;
    private bool Active = false;
    private bool pressed = false;
    private bool IsCompleted = false;


    void Start()
    {
        Jogador = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        botao = GameObject.FindWithTag("PlayerUI").GetComponentInChildren<Button>();
        DownloadUI = GetComponentInChildren<Canvas>();
        SliderUi = DownloadUI.GetComponentInChildren<Slider>();
    }

    void Update()
    {
        if (Active && IsCompleted == false && !pressed)
        {
            botao.onClick.AddListener((UnityEngine.Events.UnityAction) this.OnClick);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact();

            }

        }

        if (pressed)
        {
            botao.onClick.RemoveListener((UnityEngine.Events.UnityAction)this.OnClick);
            if (SliderUi.value < SliderUi.maxValue)
            {
                SliderUi.value += Upload_Speed * Time.deltaTime;
            }
            else
            {
                SliderUi.value = 0f;
                DownloadUI.enabled = false;
                Jogador.enabled = true;
                IsCompleted = true;
                pressed = false;
                botao.interactable = false;
            }


        }

    }

    void interact()
    {
        botao.interactable = false;
        Jogador.enabled = false;
        DownloadUI.enabled = true;
        pressed = true;
    }

    public void OnClick()
    {
        interact();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       if ( collision.CompareTag("Player"))
        {
            Active = true;
            if(!IsCompleted)
            botao.interactable = true;
            
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            botao.interactable = false;
            Active = false;
            botao.onClick.RemoveListener((UnityEngine.Events.UnityAction) this.OnClick);
        }
    }
}
