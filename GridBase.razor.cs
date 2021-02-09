using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tomi.DataGrid.Blazor
{
    public class GridBase<TableItem, Item> : ComponentBase, IDisposable
        where TableItem : GridItem<Item>
    {
        [Parameter]
        public string GridTitle { get; set; }

        [Parameter]
        public RenderFragment GridHeader { get; set; }

        [Parameter]
        public RenderFragment<TableItem> GridRow { get; set; }

        [Parameter]
        public RenderFragment<TableItem> EditRow { get; set; }

        [Parameter]
        public IEnumerable<Item> Items { get; set; }

        public List<GridItem<Item>> GridItems { get; private set; } = new List<GridItem<Item>>();

        protected override void OnInitialized()
        {
            Console.WriteLine(Items.Count());
            GridItems.AddRange(Items.Select(n => new GridItem<Item>(n)));
        }

        public void RemoveItem(Item item)
        {
            GridItems.RemoveAll(n => n.Item.Equals(item));
        }

        public void AddItem(Item item, bool isEditing)
        {
            GridItems.Insert(0, new GridItem<Item>(item) { Editing = isEditing });
        }

        public void SetEditMode(Item item, bool isEditing)
        {
            foreach (var gItem in GridItems)
            {
                if (gItem.Item.Equals(item))
                {
                    gItem.Editing = isEditing;
                }
            }
        }

        public void Update()
        {
            GridItems.Clear();
            GridItems.AddRange(Items.Select(n => new GridItem<Item>(n)).ToList());
            StateHasChanged();
        }

        public void Dispose()
        {

        }
    }
}