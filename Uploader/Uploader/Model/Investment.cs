namespace Uploader.Model
{
    public struct Investment
    {
        public string Fund { get; set; }
        public long Value { get; set; }
        public long Collateral { get; set; }
        public long Net { get; set; }
    }
}