using System.Collections;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    private int _lastScore = 0;
    public ShipMove _ship;

    IEnumerator Start()
    {
        var txt = GetComponent<TMPro.TextMeshProUGUI>();

        while (true)
        {
            if (_lastScore != _ship._score)
            {
                _lastScore = _ship._score;
                txt.text = $"{_lastScore:000000}";
            }

            yield return null;
        }
    }
}
