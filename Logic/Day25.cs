namespace Logic
{
    public class Day25
    {
        private int subjectNum = 7;

        public long Part1(int pubKey1, int pubKey2)
        {
            var loopSize1 = GetLoopSize(pubKey1);
            var loopSize2 = GetLoopSize(pubKey2);

            var enc1 = GetEncryptionKey(pubKey1, loopSize2);
            var enc2 = GetEncryptionKey(pubKey2, loopSize1);

            return enc1;
        }

        private int GetLoopSize(long key)
        {
            long value = 1;
            int loopSize = 0;

            while(value != key)
            {
                loopSize++;
                value *= subjectNum;
                var remainder = value % 20201227;
                value = remainder;
            }

            // return loopsize
            return loopSize;
        }

        private long GetEncryptionKey(long key, int loopSize)
        {
            long value = 1;
           
            for (int i = 1; i <= loopSize; i++)
            {
                value *= key;
                var remainder = value % 20201227;
                value = remainder;
            }

            return value;
        }
    }
}
