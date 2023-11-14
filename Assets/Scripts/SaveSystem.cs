using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Singleton instance
    [SerializeField] private GameObject _player;

    void Awake()
    {

    }

    void Start()
    {
        LoadPlayerPosition();
    }

    public void SavePlayerPosition()
    {
        // Save the player position in PlayerPrefs
        PlayerPrefs.SetFloat("PlayerPosX", _player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", _player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", _player.transform.position.z);
        Debug.Log("Saved!");
        // Save PlayerPrefs to disk
        PlayerPrefs.Save();
    }

    public void LoadPlayerPosition()
    {
        // Check if the player position is saved
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            // Load the player position from PlayerPrefs
            float posX = PlayerPrefs.GetFloat("PlayerPosX");
            float posY = PlayerPrefs.GetFloat("PlayerPosY");
            float posZ = PlayerPrefs.GetFloat("PlayerPosZ");

            // Set the player position
            Debug.Log("Loaded!");
            _player.transform.position = new Vector3(posX, posY, posZ);
        }
    }
}
