using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Sprite SecuritySprite;
    private Sprite usesprite;
    private Player Jogador;
    private Button botao;
    private Canvas DownloadUI;
    private bool Ativo = false;
    private bool pressed = false;


    void Start()
    {
        Jogador = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        botao = GameObject.FindWithTag("PlayerUI").GetComponentInChildren<Button>();
        DownloadUI = GetComponentInChildren<Canvas>();
        usesprite = botao.gameObject.GetComponent<Image>().sprite;
    }

    void Update()
    {
        if (Ativo)
        {

            botao.onClick.AddListener((UnityEngine.Events.UnityAction)this.OnClick);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Jogador.enabled = false;
                DownloadUI.enabled = true;
                pressed = true;



            }

        }

        if (pressed)
        {
            botao.onClick.AddListener((UnityEngine.Events.UnityAction)this.LeaveCameras);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DownloadUI.enabled = false;
                Jogador.enabled = true;
                pressed = false;

            }
        }

    }

    public void OnClick()
    {
        Jogador.enabled = false;
        DownloadUI.enabled = true;
        pressed = true;
    }

    public void LeaveCameras()
    {
        DownloadUI.enabled = false;
        Jogador.enabled = true;
        pressed = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            botao.gameObject.GetComponent<Image>().sprite = SecuritySprite;
            botao.interactable = true;
            Ativo = true;
       

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            botao.gameObject.GetComponent<Image>().sprite = usesprite;
            pressed = false;
            botao.interactable = false;    
            Ativo = false;
            botao.onClick.AddListener((UnityEngine.Events.UnityAction)this.LeaveCameras);
            botao.onClick.RemoveListener((UnityEngine.Events.UnityAction)this.OnClick);

        }
    }
}

