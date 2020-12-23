namespace Logic.Helpers
{
    public class CupNode
    {
        public int Value { get; set; }

        public CupNode Next { get; set; }

        public CupNode(int value)
        {
            Value = value;
        }
    }
}
