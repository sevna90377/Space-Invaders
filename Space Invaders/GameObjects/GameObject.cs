using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects{
    public abstract class GameObject{
        private Vector2D _position;
        public Vector2D Position{
            get => _position;
            private set => _position = value;
        }

        public Vector2D Size { get; }
        public Color color { get; }
        public bool IsActive { get; set; }

        protected GameObject(Vector2D position, Vector2D size, Color color){
            _position = position;
            Size = size;
            Color = color;
            IsActive = true;
        }
    }
}