namespace ItemContainer {
    public interface IItemContainer<in T> {
        void AddItem(T item);
        void RemoveItem(T item);
    }
}