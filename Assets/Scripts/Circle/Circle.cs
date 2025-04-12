using UnityEngine;

public class Circle : MonoBehaviour
{
    public LineRenderer circleRenderer;

    void Start()
    {
        DrawCircle(100, 5f);
    }

    void DrawCircle(int steps, float radius)
    {
        circleRenderer.positionCount = steps;

        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = currentStep / steps;

            float currentRadian = circumferenceProgress * Mathf.PI * 2;

            float xScaled = Mathf.Cos(currentRadian) * radius;
            float yScaled = Mathf.Sin(currentRadian) * radius;

            float x = yScaled * radius;
            float y = xScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);

            circleRenderer.SetPosition(currentStep, currentPosition);
        }
    }
}
