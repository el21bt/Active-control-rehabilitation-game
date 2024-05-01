using UnityEngine;
using UnityEngine.UI;

public class Slidey : MonoBehaviour
{
    [Header("Slides between -1 and 1")]

    public bool moveOnXAxis;
    private float x;
    [SerializeField] private Image img;
    [SerializeField] private RectTransform[] leftAndRight;

    public float pos
    {
        get => x;
        set => SetSlide(value);
    }

    private void SetSlide(float val)
    {
        x = val;
        var position = img.transform.localPosition;

        position = new Vector3(Mathf.Lerp(leftAndRight[0].rect.xMin + leftAndRight[0].transform.localPosition.x, leftAndRight[1].rect.xMax + leftAndRight[1].transform.localPosition.x, (x + 1) / 2), 0, position.z);

        img.transform.localPosition = position;
    }
}
