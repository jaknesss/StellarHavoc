using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUsername : MonoBehaviour {
    // Start is called before the first frame update
    
    public UserProfile profile;
    public TextMeshProUGUI usernameText;

    public void SetUsernametext() {
        usernameText.text = profile.GetUserName();
    }


}
