using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void HideEggShowPlayer()
    {
        AudioManager.instance.PlayCrackEggClip();
        gameObject.SetActive(false);
        player.SetActive(true);
    }
}
