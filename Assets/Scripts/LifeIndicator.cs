using UnityEngine;

public class LifeIndicator : MonoBehaviour {

    public Destroyable Destroyable;

    public UnityEngine.UI.Text LifeText;
    public UnityEngine.UI.Slider LifeSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (LifeText != null) {
            LifeText.text = (Mathf.RoundToInt(Destroyable.Health * 100f)).ToString();
        }

        if (LifeSlider!=null) {
            LifeSlider.value = Destroyable.Health;
        }
        
    }
}
