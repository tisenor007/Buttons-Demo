using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject volumeObj;
    private Text volumeTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        volumeObj = GameObject.Find("VolumeTxt");
        if (volumeObj != null) { volumeTxt = volumeObj.GetComponent<Text>(); }
        if (volumeTxt != null) { volumeTxt.text = "Volume: " + (int)(PlayerPrefs.GetFloat("volume") * 100); }
    }
    public void SpawnNewEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(0, 0.57f, 0), Quaternion.identity);
    }

    public void GoToGamePlayScene()
    {
        SceneManager.LoadScene("GamePlayScene", LoadSceneMode.Single);
    }

    public void GoToOptionsScene()
    {
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Single);
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void AdjustVolume(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
    }
}
