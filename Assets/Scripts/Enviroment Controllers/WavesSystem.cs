using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WavesSystem : MonoBehaviour
{
    public PlayerAttributes playerAttributes;
    public PlayerMovements playerMovements;

    public GameObject gameHUD;
    public GameObject bulletBarrier;

    public GameObject victoryPanel;
    public AudioSource backgroundMusic;
    public AudioSource victoryMusic;
    public bool victoryFlag = false;
    public bool victoryMusicFlag = false;


    public GameObject[] wavesList;
    public List<GameObject> currentWave = new List<GameObject>();

    public int wavesCounter = 0;
    public bool waveIncoming = false;
    public bool globalWaveIsFinished = GlobalVariables.waveIsFinished;

    // Update is called once per frame
    void Update()
    {
        if (wavesCounter < wavesList.Length)
        {
            if (currentWave.Count == 0 && wavesList.Length > wavesCounter)
            {
                GlobalVariables.waveIsFinished = false;
                currentWave.Add(wavesList[wavesCounter]);
            }

            if (currentWave.Count == 1 && waveIncoming == false)
            {
                waveIncoming = true;
                Debug.Log("A Wave Has Started!");
                Instantiate(wavesList[wavesCounter]);
            }

            if (GlobalVariables.waveIsFinished == true)
            {
                Debug.Log("Wave Finished!");
                currentWave.RemoveAt(currentWave.Count - 1);
                wavesCounter++;
                waveIncoming = false;
            }
        }
        else
        {
            StartCoroutine(VictoryProcess());
        }

        if (victoryFlag == true && victoryMusicFlag == false)
        {
            victoryMusicFlag = true;
            victoryMusic.Play(); 
            victoryPanel.SetActive(true);
        }
    }

    IEnumerator VictoryProcess()
    {
        gameHUD.SetActive(false);
        bulletBarrier.SetActive(false);

        backgroundMusic.Pause();   

        playerMovements.StartFlag = false;
        yield return new WaitForSeconds(4);
        playerAttributes.Speed = 0;
        victoryFlag = true;
    }
}