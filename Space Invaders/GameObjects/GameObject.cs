using SpaceInvaders.Utils;
using Raylib_cs;

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
            this.color = color;
            IsActive = true;
        }

        public void Move(Vector2D delta){
            _position += delta;
        }

        public void SetPosition(Vector2D position){
            _position = position;
        }

        public abstract void Update();

        public void Draw(){
            Raylib.DrawRectangle((int)(Position.X - Size.X / 2), (int)(Position.Y - Size.Y / 2), (int) Size.X, (int) Size.Y, color);
        }

        public bool CollidesWith(GameObject other){
            // sprawdzamy czy się nie zderzają
            // i zwracamy tego odwrotność (!)

            // warunek_A lub warunek_B lub warunek_C lub warunek_D -- prawda gdy się nie zderzają
            // dlatego to negujemy, wówczas metoda zwraca prawdę przy zderzeniu
            return !(
                Position.X + Size.X / 2 < other.Position.X - other.Size.X / 2 ||       //zderzenie prawej ściany z czymś
                Position.X - Size.X / 2 > other.Position.X + other.Size.X / 2 ||       //zderzenie lewej ściany z czymś
                Position.Y - Size.Y / 2 > other.Position.Y + other.Size.Y / 2 ||       //zderzenie górnej krawędzi
                Position.Y + Size.Y / 2 < other.Position.Y - other.Size.Y / 2);        //zderzenie dolnej krawędzi
        }
    }
}