using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUIController : MonoBehaviour
{
    public GameObject heartContainer;

    private float fillValue;

    // Update is called once per frame
    void Update()
    {
        fillValue = (float)GameController.Lives;

        fillValue = fillValue / GameController.MaxLives;

        heartContainer.GetComponent<Image>().fillAmount = fillValue;
    }
}
