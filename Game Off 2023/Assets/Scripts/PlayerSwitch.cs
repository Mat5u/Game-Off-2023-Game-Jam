using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerSwitch : MonoBehaviour
{
    int raise = 0;
    int counter = 0;
    int over1kCounter = 0;

    [SerializeField] public TextMeshProUGUI counterText;

    [SerializeField] private GameObject zephyrFirst;
    [SerializeField] private GameObject flareFirst;
    [SerializeField] private GameObject terraFirst;
    [SerializeField] private GameObject aquaFirst;

    [SerializeField] private GameObject zephyrSecond;
    [SerializeField] private GameObject flareSecond;
    [SerializeField] private GameObject terraSecond;
    [SerializeField] private GameObject aquaSecond;

    [SerializeField] private GameObject zephyrThird;
    [SerializeField] private GameObject flareThird;
    [SerializeField] private GameObject terraThird;
    [SerializeField] private GameObject aquaThird;

    [SerializeField] private GameObject zephyrFourth;
    [SerializeField] private GameObject flareFourth;
    [SerializeField] private GameObject terraFourth;
    [SerializeField] private GameObject aquaFourth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerIsZephyr", 1);
        PlayerPrefs.SetInt("PlayerIsFlare", 0);
        PlayerPrefs.SetInt("PlayerIsTerra", 0);
        PlayerPrefs.SetInt("PlayerIsAqua", 0);
        PlayerPrefs.SetInt("PlayerSwitchCounter", 0);

        zephyrFirst.gameObject.SetActive(true);
        flareFirst.gameObject.SetActive(false);
        terraFirst.gameObject.SetActive(false);
        aquaFirst.gameObject.SetActive(false);

        zephyrSecond.gameObject.SetActive(false);
        flareSecond.gameObject.SetActive(true);
        terraSecond.gameObject.SetActive(false);
        aquaSecond.gameObject.SetActive(false);

        zephyrThird.gameObject.SetActive(false);
        flareThird.gameObject.SetActive(false);
        terraThird.gameObject.SetActive(true);
        aquaThird.gameObject.SetActive(false);

        zephyrFourth.gameObject.SetActive(false);
        flareFourth.gameObject.SetActive(false);
        terraFourth.gameObject.SetActive(false);
        aquaFourth.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            switchPlayer();
            counter++;
        }
        counterText.text = counter.ToString();

        if (counter > 999)
        {
            counter = 0;
            over1kCounter++;
        }
    }

    public void switchPlayer()
    {
        raise = PlayerPrefs.GetInt("PlayerSwitchCounter");
        raise++;
        PlayerPrefs.SetInt("PlayerSwitchCounter", raise);
        if (PlayerPrefs.GetInt("PlayerSwitchCounter") == 1)
        {
            PlayerPrefs.SetInt("PlayerIsZephyr", 0);
            PlayerPrefs.SetInt("PlayerIsFlare", 1);
            PlayerPrefs.SetInt("PlayerIsTerra", 0);
            PlayerPrefs.SetInt("PlayerIsAqua", 0);
            Debug.Log("Player is now Flare");

            zephyrFirst.gameObject.SetActive(false);
            flareFirst.gameObject.SetActive(true);
            terraFirst.gameObject.SetActive(false);
            aquaFirst.gameObject.SetActive(false);

            zephyrSecond.gameObject.SetActive(false);
            flareSecond.gameObject.SetActive(false);
            terraSecond.gameObject.SetActive(true);
            aquaSecond.gameObject.SetActive(false);

            zephyrThird.gameObject.SetActive(false);
            flareThird.gameObject.SetActive(false);
            terraThird.gameObject.SetActive(false);
            aquaThird.gameObject.SetActive(true);

            zephyrFourth.gameObject.SetActive(true);
            flareFourth.gameObject.SetActive(false);
            terraFourth.gameObject.SetActive(false);
            aquaFourth.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt("PlayerSwitchCounter") == 2)
        {
            PlayerPrefs.SetInt("PlayerIsZephyr", 0);
            PlayerPrefs.SetInt("PlayerIsFlare", 0);
            PlayerPrefs.SetInt("PlayerIsTerra", 1);
            PlayerPrefs.SetInt("PlayerIsAqua", 0);
            Debug.Log("Player is now Terra");

            zephyrFirst.gameObject.SetActive(false);
            flareFirst.gameObject.SetActive(false);
            terraFirst.gameObject.SetActive(true);
            aquaFirst.gameObject.SetActive(false);

            zephyrSecond.gameObject.SetActive(false);
            flareSecond.gameObject.SetActive(false);
            terraSecond.gameObject.SetActive(false);
            aquaSecond.gameObject.SetActive(true);

            zephyrThird.gameObject.SetActive(true);
            flareThird.gameObject.SetActive(false);
            terraThird.gameObject.SetActive(false);
            aquaThird.gameObject.SetActive(false);

            zephyrFourth.gameObject.SetActive(false);
            flareFourth.gameObject.SetActive(true);
            terraFourth.gameObject.SetActive(false);
            aquaFourth.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt("PlayerSwitchCounter") == 3)
        {
            PlayerPrefs.SetInt("PlayerIsZephyr", 0);
            PlayerPrefs.SetInt("PlayerIsFlare", 0);
            PlayerPrefs.SetInt("PlayerIsTerra", 0);
            PlayerPrefs.SetInt("PlayerIsAqua", 1);
            Debug.Log("Player is now Aqua");

            zephyrFirst.gameObject.SetActive(false);
            flareFirst.gameObject.SetActive(false);
            terraFirst.gameObject.SetActive(false);
            aquaFirst.gameObject.SetActive(true);

            zephyrSecond.gameObject.SetActive(true);
            flareSecond.gameObject.SetActive(false);
            terraSecond.gameObject.SetActive(false);
            aquaSecond.gameObject.SetActive(false);

            zephyrThird.gameObject.SetActive(false);
            flareThird.gameObject.SetActive(true);
            terraThird.gameObject.SetActive(false);
            aquaThird.gameObject.SetActive(false);

            zephyrFourth.gameObject.SetActive(false);
            flareFourth.gameObject.SetActive(false);
            terraFourth.gameObject.SetActive(true);
            aquaFourth.gameObject.SetActive(false);
        }

        else 
        {
            PlayerPrefs.SetInt("PlayerIsZephyr", 1);
            PlayerPrefs.SetInt("PlayerIsFlare", 0);
            PlayerPrefs.SetInt("PlayerIsTerra", 0);
            PlayerPrefs.SetInt("PlayerIsAqua", 0);
            PlayerPrefs.SetInt("PlayerSwitchCounter", 0);
            Debug.Log("Player is now Zephyr");

            zephyrFirst.gameObject.SetActive(true);
            flareFirst.gameObject.SetActive(false);
            terraFirst.gameObject.SetActive(false);
            aquaFirst.gameObject.SetActive(false);

            zephyrSecond.gameObject.SetActive(false);
            flareSecond.gameObject.SetActive(true);
            terraSecond.gameObject.SetActive(false);
            aquaSecond.gameObject.SetActive(false);

            zephyrThird.gameObject.SetActive(false);
            flareThird.gameObject.SetActive(false);
            terraThird.gameObject.SetActive(true);
            aquaThird.gameObject.SetActive(false);

            zephyrFourth.gameObject.SetActive(false);
            flareFourth.gameObject.SetActive(false);
            terraFourth.gameObject.SetActive(false);
            aquaFourth.gameObject.SetActive(true);
        }
    }
}
