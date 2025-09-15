using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{   
    public static float damageAmount= 0;
    public float damagePoints;
    [SerializeField] float damageSpeed;
    [SerializeField] Text damageText;

    public static void ResetDamage()
    {
        damageAmount = 0;
    }

    // Start is called before the first frame update and destroys the damage number after 1.5 seconds
    private void Start()
    {
        damageAmount += damagePoints; // It accumulate the damage points
        Destroy(this.gameObject, 1.5f);
    }

    void Update()
    {
        damageText.text = damageAmount.ToString();
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y + (damageSpeed * Time.deltaTime),
            this.transform.position.z
        );

    }
}