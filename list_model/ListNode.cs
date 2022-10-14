
namespace LIST_test.list_model
{
    internal class ListNode
    {
        public ListNode? Previous;
        public ListNode? Next;
        public ListNode? Random; 
        public string Data;

        public ListNode(string data, ListNode? pre = null, ListNode? next = null, ListNode? random = null)
        {
            if (data != null) Data = data; else throw new ArgumentException(null, nameof(data));
            Previous = pre;
            Next = next;
            Random = random;
        }
    }
}
