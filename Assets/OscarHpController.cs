using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OscarHpController : MonoBehaviour
{
    public OscarController OscarController;
    
    private Image _image;
    
    // Start is called before the first frame update. Yo starfullah
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = OscarController.HealthPoints;
        
        if(_image.fillAmount < 0.2f)
        {
            _image.color = Color.red;
        }
        else if(_image.fillAmount < 0.4f)
        {
            _image.color = Color.yellow;
        }
        else
        {
            _image.color = Color.green;
        }
    }
}
