using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float damagePoints;
    [SerializeField] float damageSpeed;
    [SerializeField] Text damageText;

    // Start is called before the first frame update and destroys the damage number after 1.5 seconds
    private void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    void Update()
    {
        damageText.text = damagePoints.ToString();
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y + (damageSpeed * Time.deltaTime),
            this.transform.position.z
        );
    }
}