using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;
    public GameObject Player;
    public UnityEngine.UI.Text CutsceneText;
    public UnityEngine.UI.Image CutsceneBackground;
    public UnityEngine.UI.Image CutsceneImage;
    public Cutscene CurrentCutscene;
    public UnityEngine.UI.Image Black;
    public bool FadeToBlack;
    private PlayerController _pc;

    private void Update()
    {
        if(CurrentCutscene.CutsceneData.Count > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            ProgressCutscene();
        }
        Fade();
    }

    private void Fade()
    {
        if (FadeToBlack && Black.color.a < 1.0f)
        {
            Black.color = new Color(0,0,0,Black.color.a + Time.deltaTime);
        }
        else if(Black.color.a > 0f)
        {
            Black.color = new Color(0, 0, 0, Black.color.a - Time.deltaTime);
        }
    }

    [System.Serializable]
    public struct CutsceneData
    {
        public Transform CameraPosition;
        public string Text;
        public Sprite ActorSprite;
        public GameObject Trigger;
        public bool noText;
    }

    [System.Serializable]
    public class Cutscene
    {
        public List<CutsceneData> CutsceneData = new List<CutsceneData>();
        public int index;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _pc = Player.GetComponent<PlayerController>();
    }

    public void OverridePlayerControls(Vector2? input)
    {
        _pc.OverrideControls = input;
    }

    public void InitiateCutscene(List<CutsceneData> cutsceneData)
    {
        CurrentCutscene = new Cutscene();
        CurrentCutscene.CutsceneData = cutsceneData;
        CurrentCutscene.index = 0;
        OverridePlayerControls(new Vector2(0, 0));
        CutsceneText.enabled = true;
        CutsceneBackground.enabled = true;
        ProgressCutscene();
    }

    public void ProgressCutscene()
    {
        if(CurrentCutscene.index >= CurrentCutscene.CutsceneData.Count)
        {
            CurrentCutscene = new Cutscene();
            OverridePlayerControls(null);
            Camera.main.transform.position = Player.transform.position - 10 * Vector3.forward;
            CutsceneText.enabled = false;
            CutsceneBackground.enabled = false;
            CutsceneImage.enabled = false;
            return;
        }
        CutsceneData cutsceneData = CurrentCutscene.CutsceneData[CurrentCutscene.index];
        if (cutsceneData.Trigger != null)
        {
            var component = cutsceneData.Trigger.GetComponent<ITriggerable>();
            if (component != null) { component.Trigger(); }
        }
        if (!cutsceneData.noText)
        {
            Camera.main.transform.position = cutsceneData.CameraPosition.position - 10 * Vector3.forward;
            CutsceneText.text = cutsceneData.Text;
            if (cutsceneData.ActorSprite != null)
            {
                CutsceneImage.enabled = true;
                CutsceneImage.sprite = cutsceneData.ActorSprite;
            }
            else { CutsceneImage.enabled = false; }
        }

        CurrentCutscene.index++;
        if (cutsceneData.noText) { ProgressCutscene(); }
    }
}
