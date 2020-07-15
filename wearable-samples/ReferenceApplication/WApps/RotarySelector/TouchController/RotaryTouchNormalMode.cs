using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using Tizen.NUI;

namespace NUIWHome
{
    internal class RotaryTouchNormalMode : RotaryTouchController
    {
        public RotaryTouchNormalMode()
        {
        }
        public override bool ProcessTouchUpEvent(RotarySelectorItem item)
        {
            SelectedItem = item;
            SelectedItem.ClickedItem();
            return true;
        }

        public override bool ProcessTouchDownEvent(RotarySelectorItem item)
        {
            return false;
        }
    }
}