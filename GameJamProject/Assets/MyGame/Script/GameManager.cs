using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isActive;

    public GameObject titleScreen;
    public TextMeshProUGUI contItensText;
    public GameObject gameOverScreen;

    private AudioSource audioPlayer;

    private int contItens;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void StartGame()
    {
        isActive = true;
        titleScreen.gameObject.SetActive(false);
        contItensText.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        if (contItens == 4)
        {
            gameOverScreen.gameObject.SetActive(true);
            contItensText.gameObject.SetActive(false);
            audioPlayer.Stop();
            StartCoroutine(ChangeScene());
        }
    }

    public void UpdateColection(int coletados)
    {
        contItens += coletados;
        contItensText.text = "ITENS COLETADOS : " + contItens + "/4";
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("GameOverScene");
    }
}
