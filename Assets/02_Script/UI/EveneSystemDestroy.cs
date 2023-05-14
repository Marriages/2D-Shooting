using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EveneSystemDestroy : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        // 다른 씬으로 전환되면서 "Title" 씬이 언로드될 때 실행됨
        if (scene.name != "Title")
        {
            // EventSystem 파괴
            GameObject eventSystem = GameObject.FindWithTag("EventSystem");
            if (eventSystem != null)
            {
                Destroy(eventSystem);
            }

            // Scene 언로드 이벤트 핸들러 제거
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
    }
}
