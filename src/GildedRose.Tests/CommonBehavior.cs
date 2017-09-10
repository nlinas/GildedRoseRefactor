using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class CommonBehavior
    {
        protected Program _program;
        protected Item _item;

        public void SetUp(Item item)
        {
            _item = item;
            _program = new Program { Items = new List<Item> { _item } };
            _program.UpdateQuality();
        }
    }
}