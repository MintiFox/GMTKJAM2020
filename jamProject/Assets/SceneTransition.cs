using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{

    public GameObject transitionObject;
    public float transitionTime;
    public ChangeScene st;
    public void transitionScene(int sceneToLoad)
    {

        StartCoroutine(trans(sceneToLoad));

    }


    IEnumerator trans(int scene)
    {
        transitionObject.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        st.LoadScene(scene);
    
    
    }

}
