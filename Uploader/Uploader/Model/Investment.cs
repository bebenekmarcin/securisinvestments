namespace Uploader.Model
{
    public class Investment
    {
        public string Fund { get; set; }
        public long Value { get; set; }
        public long Collateral { get; set; }
        public long Net => Value - Collateral;
    }
}