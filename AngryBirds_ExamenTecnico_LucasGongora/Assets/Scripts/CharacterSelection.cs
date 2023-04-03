using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] charactersPrefabs;
    public int selectedCharacter;

    private void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        charactersPrefabs[selectedCharacter].SetActive(true);
    }

    public void NextCharacter()
    {
        charactersPrefabs[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % charactersPrefabs.Length;
        charactersPrefabs[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
