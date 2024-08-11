using UnityEngine;

public class MenuSM : MonoBehaviour
{
    public GameObject objSetting;

    void OnClickGameStart()
    {
        GameManager.LoadScene(SceneType.Game);
    }

    void OnClickSetting()
    {
        objSetting.SetActive(true);
    }
}
