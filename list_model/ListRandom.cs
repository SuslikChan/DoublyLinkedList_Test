using System.Text;

namespace LIST_test.list_model
{
    internal class ListRandom
    {
        public ListNode? Head { get; private set; }
        public ListNode? Tail { get; private set; }
        public int Count { get; private set; }
        private readonly Random rnd = new();

        public ListRandom()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Append(String data, bool rerand = true)
        {
            ListNode node = new ListNode(data);
            if (Count == 0) { Head = node; }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
            if (rerand) Randomize();
        }

        public ListNode? GetNode(int i = 0) {
            ListNode? node = Head;
            if (0 <= i && i <= Count) { for (int j = 0; j < i; j++) node = node.Next; }
            else throw new IndexOutOfRangeException();
            return node;
        }

        public string GetText(int i = 0) { 
            return GetNode(i).Data;
        }

        public void Randomize(){
            ListNode? node = Head;
            while (node != null){
                node.Random = GetNode(rnd.Next(Count));
                node = node.Next;
            }
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public string List2Sting(string separator = ", ", string msg = "") {
            ListNode? node = Head;
            for (int i = 0; i < Count; i++) {
                msg += node.Data;
                if (i < Count - 1) msg += separator;
                node = node.Next;
            }
            return msg;
        }

        public void String2List(string data = "", string separator = ", ") {
            Clear();
            if (data.Length != 0) {
                string[] nodes = data.Split(separator);
                foreach (string node in nodes) Append(data: node, rerand: false);
            }
            Randomize();
        }
        public void Serialize(Stream s, string separator = ", ")
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(List2Sting(separator: separator));
                if (s.CanWrite) s.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e) { Console.WriteLine("Error:" + e); }
            finally { s.Close(); }
        }
        public void Deserialize(Stream s, string separator = ", ", int BufferSize = 1024)
        {
            try
            {
                byte[] buffer = new byte[BufferSize];
                StringBuilder data = new StringBuilder();
                {
                    int bytes;
                    while ((bytes = s.Read(buffer, 0, BufferSize)) > 0)
                    {
                        data.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
                    }
                    String2List(data.ToString(), separator: separator);
                }
            }
            catch (Exception e) { Console.WriteLine("Error:" + e); }
            finally { s.Close(); }
        }


    }
}
