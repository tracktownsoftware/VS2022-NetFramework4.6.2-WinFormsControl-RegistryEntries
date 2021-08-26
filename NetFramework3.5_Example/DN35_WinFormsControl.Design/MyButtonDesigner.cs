using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace DN35_WinFormsControl.Design
{
    public class MyButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        MyButton _myButton;
        private DesignerActionListCollection _actionLists;

        internal static void DontRemoveConstructor()
        {
            new MyButtonDesigner();
        }

        public MyButtonDesigner()
        {
        }

        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            _myButton = component as MyButton;
            if (_myButton != null)
            {
                _myButton.Width = 200;
                _myButton.Height = 125;
            }
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == _actionLists)
                {
                    _actionLists = new DesignerActionListCollection();
                    _actionLists.Add(new MyButtonActionList(this.Component));
                }
                return _actionLists;
            }
        }

        public class MyButtonActionList : System.ComponentModel.Design.DesignerActionList
        {
            MyButton _myButton;

            private DesignerActionUIService _designerActionUISvc = null;

            //The constructor associates the control with the smart tag list.
            public MyButtonActionList(IComponent component)
                : base(component)
            {
                _myButton = component as MyButton;

                // Cache a reference to DesignerActionUIService, 
                // so the DesigneractionList can be refreshed.
                _designerActionUISvc = GetService(typeof(DesignerActionUIService))
            as DesignerActionUIService;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection();
                items.Add(new DesignerActionMethodItem(
                    this,
                    "ShowMessageBox",
                    "Show MessageBox",
                    "Trigger",
                    "",
                    true));
                items.Add(new DesignerActionMethodItem(
                    this,
                    "SetBackgroundRed",
                    "Red Background",
                    "BackgroundColor",
                    "",
                    true));
                items.Add(new DesignerActionMethodItem(
                    this,
                    "SetBackgroundWhite",
                    "White Background",
                    "BackgroundColor",
                    "",
                    true));
                items.Add(new DesignerActionMethodItem(
                    this,
                    "SetBackgroundBlue",
                    "Blue Background",
                    "BackgroundColor",
                    "",
                    true));
                return items;
            }

            public void ShowMessageBox()
            {
                System.Windows.Forms.MessageBox.Show("Hello World from .NET Framework 4.6.2 Windows Forms", "Show MessageBox"); ;
            }

            public void SetBackgroundRed()
            {
                _myButton.BackColor = System.Drawing.Color.Red;
            }

            public void SetBackgroundWhite()
            {
                _myButton.BackColor = System.Drawing.Color.White;
            }

            public void SetBackgroundBlue()
            {
                _myButton.BackColor = System.Drawing.Color.Blue;
            }
        }
    }
}
