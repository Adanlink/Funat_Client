using EntityController.Entity.Interfaces;
using UnityEngine;

namespace EntityController.Entity
{
    public class EntityController : MonoBehaviour, IEntityController
    {
        public IEntity Entity { get; set; }

        private bool _remove;

        private void Update()
        {
            gameObject.transform.SetPosition(Entity.X, Entity.Y);
            
            if (_remove)
            {
                _remove = false;
                Destroy(gameObject);
            }
        }
        
        public void SetPosition(float x, float y)
        {
            Entity.X = x;
            Entity.Y = y;
        }

        public void Remove()
        {
            _remove = true;
        }
    }
}