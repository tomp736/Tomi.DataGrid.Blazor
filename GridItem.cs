namespace Tomi.DataGrid.Blazor
{
    public class GridItem<T>
    {
        public bool Selected { get; set; }
        public bool Editing { get; set; }
        public bool ForceTop { get; set; }
        public T Item { get; set; }

        public GridItem(T item)
        {
            Item = item;
        }

        public override string ToString()
        {
            return Item.ToString() + $"Editing: {Editing}";
        }
    }
}
