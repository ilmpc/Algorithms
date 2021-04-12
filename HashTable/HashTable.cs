namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int size, int step)
        {
            this.size = size;
            this.step = step;
            slots = new string[size];
            for (var i = 0; i < size; i++)
            {
                slots[i] = null;
            }
        }

        public int HashFun(string value)
        {
            if (value == null) { return 0; }
            // Should be any prime number roughly equal to the number of different characters use
            int p = 31;
            int m = (int)(1e9 + 9);
            long power_of_p = 1;
            long hash = 0;

            // Using Polynomial rolling 
            foreach (char ch in value)
            {
                hash = (hash + (ch - 'a' + 1) * power_of_p) % m;
                power_of_p = (power_of_p * p) % m;
            }
            return (int)(hash % size);
        }

        public int SeekSlot(string value)
        {
            if (size == 0) { return -1; }
            
            var hash = HashFun(value);
            var potential = hash;
            do
            {
                if (slots[potential] == null) { return potential; }
                potential = (potential + step) % size;
            } while (potential != hash);

            return -1;
        }

        public int Put(string value)
        {
            var slot = SeekSlot(value);
            if (slot == -1) { return -1; }
            slots[slot] = value;
            return slot;
        }

        public int Find(string value)
        {
            if (size == 0) { return -1; }

            var hash = HashFun(value);
            var potential = hash;
            do
            {
                if (slots[potential] == value) { return potential; }
                potential = (potential + step) % size;
            } while (potential != hash);
            return -1;
        }
    }

}