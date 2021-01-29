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
        if (Active && IsCompleted == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Jogador.enabled = false;
                DownloadUI.enabled = true;
                pressed = true;



            }

        }

        if (pressed)
        {
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

        }
    }
}
