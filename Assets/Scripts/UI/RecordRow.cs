using UnityEngine;
using TMPro;

public class RecordRow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _placeText;
    [SerializeField] private TextMeshProUGUI _dateTimeText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Initialize(int place, RecordData recordData)
    {
        _placeText.text = place.ToString();
        _dateTimeText.text = recordData.DateTime.ToString("dd/MM/yy hh:mm");
        _scoreText.text = recordData.Score.ToString();
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
}
