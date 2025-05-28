using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TastenSilbenAusgabe : MonoBehaviour
{
    public class Tasteneingabe
    {
        public KeyCode taste;
        public string silbe;
    }
        public List<Tasteneingabe> silbenListe = new List<Tasteneingabe>();
        public TextMeshProUGUI textAnzeigen;
        public TMP_Text uiText;
        public AudioSource hoherTon;
        public AudioSource tieferTon;
        public Transform rechterArm;
        public Transform linkerArm;
        public Quaternion rechterArmStartRot;
        public Quaternion linkerArmStartRot;
        public List<string> silbenPuffer = new List<string>();
        
        private HashSet<string> _rechterArmSilben = new HashSet<string>(){ "Hal", "Na", "ist", "tin", "das", "ne", "Be"};
        private HashSet<string> _linkerArmSilben = new HashSet<string>(){ "lo", "mein", "me", "und", "Jus", "mei", "wer", "bung" };
        private HashSet<KeyCode> _gedrückteTasten = new HashSet<KeyCode>();
        private HashSet<string> _wortEnden = new HashSet<string>{"lo","mein", "me", "ist", "tin", "und", "das", "ne", "bung"};
        private int wortIndex = 0;
        private List<Tasteneingabe> eingegebeneSilben = new List<Tasteneingabe>();
        private bool spieltRhythmus = false;
        readonly string[] wortGrenzen =
            { "Hallo", "mein", "Name", "ist", "Justin", "und", "das", "ist", "meine", "Bewerbung" };
         string aktuellesWort = "";
         Dictionary<KeyCode, string>
             _tastenZuSilben = new Dictionary<KeyCode, string>()
             {
                 { KeyCode.Q, "Hal" },
                 { KeyCode.U, "lo" },
                 { KeyCode.I, "mein" },
                 { KeyCode.W, "Na" },
                 { KeyCode.O, "me" },
                 { KeyCode.E, "ist" },
                 { KeyCode.P, "Jus" },
                 { KeyCode.R, "tin" },
                 { KeyCode.H, "und" },
                 { KeyCode.A, "das" },
                 { KeyCode.S, "ist" },
                 { KeyCode.J, "mei" },
                 { KeyCode.D, "ne" },
                 { KeyCode.F, "Be" },
                 { KeyCode.K, "wer" },
                 { KeyCode.L, "bung" },
             };
         
     
         
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
