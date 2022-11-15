namespace EF006.DbContextLifeTime.Entities
{
    public class Wallet
    {
        public virtual int Id { get; set; }
        public virtual string Holder { get; set; } = null!;
        public virtual decimal Balance { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Holder} ({Balance:C})";
        }
    }
}
