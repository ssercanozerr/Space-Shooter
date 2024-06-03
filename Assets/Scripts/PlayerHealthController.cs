using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] Image _healthBarImage;
    [SerializeField] float _maxHealth;

    float _health;
    
    void Awake()
    {
        _health = _maxHealth;
        _healthBarImage.fillAmount = _health / _maxHealth;
    }
    
    public void DecreaseHealth(float damage)
    {
        AdjustHealth(-damage);

        if (_health <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(LoadScene());
        }
    }

    public void IncreaseHealth(float heal)
    {
        AdjustHealth(heal);
    }

    public bool OnHealthBarMax()
    {
        return _healthBarImage.fillAmount == 1;
    }
    
    private void AdjustHealth(float amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        _healthBarImage.fillAmount = _health / _maxHealth;
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync(2);
    }
}
