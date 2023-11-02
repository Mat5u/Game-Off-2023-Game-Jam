using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camera zoom
    private Camera cam;
    private float targetZoom;
    [SerializeField] private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10;
    [SerializeField] private float minZoom = 4.5f;
    [SerializeField] private float maxZoom = 8f;

    public GameObject flare;
    public GameObject zephyr;
    public GameObject terra;
    public GameObject aqua;

    //Camera movement
    public static CameraController Instance;
    //public GameObject Target;
    public int Smoothvalue = 2;
    public float PosY = 1;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        changePlayer();
    }


    void Zoom()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }

    void changePlayer()
    {
        if (PlayerPrefs.GetInt("PlayerIsZephyr") == 1)
        {
            Vector3 Targetpos = new Vector3(zephyr.transform.position.x, zephyr.transform.position.y + PosY, -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);
        }
        else if (PlayerPrefs.GetInt("PlayerIsFlare") == 1)
        {
            Vector3 Targetpos = new Vector3(flare.transform.position.x, flare.transform.position.y + PosY, -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);
        }
        else if (PlayerPrefs.GetInt("PlayerIsTerra") == 1)
        {
            Vector3 Targetpos = new Vector3(terra.transform.position.x, terra.transform.position.y + PosY, -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);
        }

        else if (PlayerPrefs.GetInt("PlayerIsAqua") == 1)
        {
            Vector3 Targetpos = new Vector3(aqua.transform.position.x, aqua.transform.position.y + PosY, -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);
        }
    }
}
