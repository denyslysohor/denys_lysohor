
using MyRefList;
namespace RefList
{
    public interface IRefList
    {
        void Add(int value);
        void AddToEnd(int value);
        void DeleteByValue(int value);
        void DeleteByIndex(int index, Node current);
        void IndexOf(int value);
        int this[int index] { get; set; }
        int Length{ get; set; }

    }
}