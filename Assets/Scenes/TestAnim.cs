using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAnim : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private RectTransform[] _position;

    private void Start()
    {
        _image.Fade(1, 0.5f, () =>
        {

            StartCoroutine(Delay());
        });
    }

    private IEnumerator Delay()
	{
        var temp = 0;
        for (int i = 0; i < 20; i++)
        {

            bool tempBool = false;
            if (i == 4 || i == 7 || i == 8 || i == 15) temp = Random.Range(0, _position.Length - 1);
            _image.GetComponent<RectTransform>().Move(_position[temp].anchoredPosition, 4f, () =>
            {
                Debug.LogError("Анимации закончены!");
                tempBool = true;
            });
            while (tempBool == false) { yield return null; }
            temp++;
            if (temp == _position.Length) temp = 0;
        }
    }
}
