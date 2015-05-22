namespace Model.Persistence
{
    using MongoDB.Bson;

    public class Team
    {
        // ReSharper disable once InconsistentNaming
        public int _id { get; set; }

        public string Name { get; set; } 
    }
}