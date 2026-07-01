using UnityEngine;

/// <summary>
/// Tool for scanning flora, fauna, minerals. Feeds into Research and Documentation.
/// Strategy pattern for different scan types.
/// </summary>
public class Scanner : MonoBehaviour
{
    public float scanRange = 50f;
    public LayerMask scanMask;

    public void Scan()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, scanRange, scanMask))
        {
            IScannable target = hit.collider.GetComponent<IScannable>();
            if (target != null)
            {
                DiscoveryData data = target.Scan();
                EventSystem.TriggerDiscovery("Scan", data);
                // Award Research Points / Credits
            }
        }
    }
}

public interface IScannable
{
    DiscoveryData Scan();
}

public class DiscoveryData
{
    public string Type { get; set; }
    public string Name { get; set; }
    public float ScientificValue { get; set; }
    // DNA, images, audio, etc.
}