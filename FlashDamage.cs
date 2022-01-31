using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlashDamage : MonoBehaviour
{
    public KeyCode activationKey;
    public Color targetColor;
    public float duration;
    private GameObject flashView;

    void Start()
    {

        // Create Flash Panel
        flashView = new GameObject();
        flashView.name = "FlashCanvas";
        flashView.AddComponent<Canvas>();
        Canvas myCanvas = flashView.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        flashView.AddComponent<CanvasScaler>();
        flashView.AddComponent<GraphicRaycaster>();
        flashView.transform.SetParent(transform);
        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        panel.AddComponent<Image>();
        RectTransform rt = panel.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(2000, 2000);
        panel.transform.SetParent(myCanvas.transform, false);
        flashView.SetActive(false);
    }

    IEnumerator PlayAnimation()
    {
        //Debug.Log("Show Flash Damage Animation");

        if (!flashView.activeSelf)
        {
            flashView.SetActive(true);
        }
        Image img = flashView.GetComponentInChildren<Image>();
        LeanTween.value(flashView, 1.0f, 0.0f, duration)
            .setOnUpdate((float val) =>
            {
                if (img != null)
                {
                    img.color = new Color(targetColor.r, targetColor.g, targetColor.b, val);
                }
            })
            .setOnComplete(() =>
            {
                flashView.SetActive(false);
            });
        return null;
    }

    void Update()
    {

        if (Input.GetKeyUp(activationKey))
        {
            StartCoroutine("PlayAnimation");
        }
    }

    public void FlashFlash()
    {
        StartCoroutine("PlayAnimation");
       // Debug.Log("Flashing");
    }
}
