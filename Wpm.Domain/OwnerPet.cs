namespace Wpm.Domain
{
    public class OwnerPet
    {
        public int Id { get; set; }
        public Pet Pets { get; set; }
        public int PetsId { get; set; }
        public Owner Owners { get; set; }
        public int OwnersId { get; set; }        
    }
}
