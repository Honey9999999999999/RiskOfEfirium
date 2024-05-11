namespace Assets.Scripts.LabyrinthGenerator.Rooms
{
    public class Door
    {
        public Position path { get; }
        public bool isLeadSomeWhere { get; set; }

        public Door(Position path)
        {
            this.path = path;
            isLeadSomeWhere = false;
        }
    }
}
