using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;


public class ZweiTasten : MonoBehaviour
{
    private bool _ersteTaste = false; 
    public TMP_Text uiText; //UI Textausgabe Bildschirm
    public AudioSource hoherTon; 
    public AudioSource tieferTon;
    public Quaternion rechterStartRot; //Rotation rechter Arm
    public Quaternion linkerStartRot;
    public Transform rechterArm; //Bewegung rechter Arm
    public Transform linkerArm; 
    
    List<string> _hoheSilben = new List<string>() //welche Wörter werden HOCH ausgesprochen
    {
        "Hal", "mein", "me", "ist", "tin", "das", "ist", "ne", "Be"
    };

    List<string> _tiefeSilben = new List<string>()//welche Wörter werden TIEF ausgesprochen
    {
        "lo", "Na", "Jus", "und", "mei", "wer", "bung"
    };

    readonly string[] _wortGrenzen = { "lo", "mein", "me", "ist", "tin", "und", "das", "ist", "ne", "ung" };
    public int hoheIndex = 0;
    public int tiefeIndex = 0;

    private IEnumerator TrommelBewegung(Transform arm, float winkel) //wie werden die Arme bewegt
    {
        arm.Rotate(0, 0, winkel);
        yield return new WaitForSeconds(0.15f);
        arm.Rotate(0, 0, -winkel);
    }

    IEnumerator AnimatePopup() //Sprechblase
    {
        panelObject.transform.localScale = Vector3.zero;
        float duration = 0.3f;
        float time = 0f;
        while (time < duration)
        {
            float scale = Mathf.SmoothStep(-0.537f, 1f, time / duration);
            panelObject.transform.localScale = new Vector3(scale, scale, scale);
            time += Time.deltaTime;
            yield return null;
        }
        panelObject.transform.localScale = Vector3.one;
    }
    private IEnumerator SpieleRhythmus() //richtig getrommelt 
    {
        yield return new WaitForSeconds(1f);
        uiText.text = "";

        for (int i = 0; i < _satz.Length; i++)
        {
            string silbe = _satz[i];
            uiText.text += silbe;

            if (_hoheSilben.Contains(silbe))
            {
                hoherTon.Play();
                yield return StartCoroutine(TrommelBewegung(rechterArm, 27));
                if (_wortGrenzen.Contains(silbe))
                {
                    uiText.text += " ";
                }
            }
            else
            {
                tieferTon.Play();
                yield return StartCoroutine(TrommelBewegung(linkerArm, 26));
                if (_wortGrenzen.Contains(silbe))
                {
                    uiText.text += " ";
                }
            }

            float pause = 0.25f;

            if (silbe.Length <= 2) pause = 0.05f;
            else if (silbe.Length >= 3) pause = 0.1f;

            if (i == 1 || i == 2 || i == 4 || i == 5 || i == 7 || i == 8 || i == 9 || i == 10 || i == 12 || i == 15)
            {
                pause += 0.2f;
            }
            yield return new WaitForSeconds(pause);

        }
    }


    readonly string[] _satz =
        { "Hal", "lo", "mein", "Na", "me", "ist", "Jus", "tin", "und", "das", "ist", "mei", "ne", "Be", "wer", "bung" };


    List<string> _eingegebeneSilben = new List<string>();
    private bool _satzKomplett = false;

    void VerarbeiteEingabe(string silbe, bool istHoch) //was passiert bei der Eingabe 
    {
        _eingegebeneSilben.Add(silbe);
        uiText.text += silbe + " ";
        
        
        if (istHoch)
        {
            hoherTon.Play();
            StartCoroutine(TrommelBewegung(rechterArm, 27));
        }
        else
        {
            tieferTon.Play();
            StartCoroutine(TrommelBewegung(linkerArm, 26));
        }

        if (_eingegebeneSilben.Count == _satz.Length)
        {
            bool korrekt = true;
            for (int i = 0; i < _satz.Length; i++)
            {
                if (_eingegebeneSilben[i] != _satz[i])
                {
                    korrekt = false;
                    break;
                }
            }
            if (korrekt)
            {
                _eingegebeneSilben.Clear();
                StartCoroutine(SpieleRhythmus());
            }
        }
    }

    public GameObject panelObject;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rechterStartRot = rechterArm.localRotation;
        linkerStartRot = linkerArm.localRotation;
        panelObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!_ersteTaste && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)))
        {
            _ersteTaste = true;
            panelObject.SetActive(true);
            StartCoroutine(AnimatePopup());
        }
        if (Input.GetKeyDown(KeyCode.Q) && hoheIndex < _hoheSilben.Count)
        {
            string silbe = _hoheSilben[hoheIndex++];
            VerarbeiteEingabe(silbe, true);
        }

        if (Input.GetKeyDown(KeyCode.E) && tiefeIndex < _tiefeSilben.Count)
        {
            string silbe = _tiefeSilben[tiefeIndex++];
            VerarbeiteEingabe(silbe, false);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            hoheIndex = 0;
            tiefeIndex = 0;
            uiText.text = "";
            rechterArm.localRotation = rechterStartRot;
            linkerArm.localRotation = linkerStartRot;
            _satzKomplett = false;
            _ersteTaste = false;
            _eingegebeneSilben.Clear();
            panelObject.SetActive(false);
        }
    }
}