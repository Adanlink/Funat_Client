using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : ISceneController
{
    private bool _loadScene;

    private string _scene;

    private AsyncOperation _loadingScene;

    public void Update()
    {
        if (_loadingScene != null)
        {
            if (!_loadingScene.isDone)
            {
                //TODO Loading %
                return;
            }

            _loadingScene = null;
        }
        
        if (!_loadScene)
        {
            return;
        }

        _loadScene = false;
        
        _loadingScene = SceneManager.LoadSceneAsync(_scene);
    }
    
    public void LoadScene(string scene)
    {
        _scene = scene;
        _loadScene = true;
    }
}