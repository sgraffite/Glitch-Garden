using UnityEngine.UI;
using UnityEngine;

public class FadeInScript : MonoBehaviour {

    public float fadeInTimeSeconds;

    private Image fadePanel;
    private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
        fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeInTimeSeconds)
        {
            var alphaChange = Time.deltaTime / fadeInTimeSeconds;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
            return;
        }

        gameObject.SetActive(false);
	}
}
