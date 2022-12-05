using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float _healthReductionSpeed = 2;
    private float _target = 1;
    
    public void UpdateHealth(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
    }

    void Update()
    {
        _healthBar.fillAmount = Mathf.MoveTowards(_healthBar.fillAmount, _target, _healthReductionSpeed * Time.deltaTime);
    }
}
