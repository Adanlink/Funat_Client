using UnityEngine;

namespace EntityController.Entity.Interfaces
{
    public interface IOwnPlayerController : IGenericEntityController
    {
        IOwnPlayer OwnPlayer { get; set; }

        CameraPlayerController OwnCamera { get; set; }

        Transform Transform { get; }
    }
}