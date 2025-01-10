using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelHandler : MonoBehaviour
{
    public int lvlIndex;
    public GameObject lvlLock;
    public Button lvlBtn;
    private void OnEnable()
    {

        if(PlayerPrefs.GetInt("lvlLocked") >= lvlIndex)
        {
            lvlLock.SetActive(false);
            lvlBtn.interactable = true;
        }
        else
        {
            lvlLock.SetActive(true);
            lvlBtn.interactable = false;
        }
    }

    public void OnLevelClick()
    {
        PlayerPrefs.SetInt("CurrentLvl", lvlIndex);
    }

}
