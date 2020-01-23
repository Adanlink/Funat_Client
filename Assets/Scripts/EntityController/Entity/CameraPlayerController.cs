using Assets.Scripts.IoC;
using Autofac;
using UnityEngine;

public class CameraPlayerController : MonoBehaviour
{
    private void Update()
    {
        var player = UsefulContainer.Instance.Resolve<GameController>().EntitiesController.OwnPlayerController;

        if (player == null)
        {
            return;
        }

        player.OwnCamera = this;
    }
    public void UpdatePosition(float X, float Y)
    {
        transform.position = new Vector3(X, Y, -10);
    }
}
