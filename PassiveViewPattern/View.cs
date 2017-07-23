using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PassiveViewPattern
{
    public partial class View : Form, IView, IActivable
    {
        public View()
        {
            InitializeComponent();
            ISomeComunicationApi component = null;
            new Presenter(this, new Model(component));
        }

        public event EventHandler Activated;

        public event EventHandler Deactivated;

        void IActivable.Activate()
        {
            Utilities.RaiseEvent(this.Activated, this, EventArgs.Empty);
        }

        void IActivable.Deactivate()
        {
            Utilities.RaiseEvent(this.Deactivated, this, EventArgs.Empty);
        }

        public event EventHandler OptionOneRadioButtonCheckedChanged
        {
            add
            {
                this.radioButtonOptionOne.CheckedChanged += value;
            }
            remove
            {
                this.radioButtonOptionOne.CheckedChanged -= value;
            }
        }

        public event EventHandler OptionTwoRadioButtonCheckedChanged
        {
            add
            {
                this.radioButtonOptionTwo.CheckedChanged += value;
            }
            remove
            {
                this.radioButtonOptionTwo.CheckedChanged -= value;
            }
        }

        public void SetWarningText(string text)
        {
            this.labelWarning.Text = text;
        }

        public void SetWarningVisible(bool visible)
        {
            this.labelWarning.Visible = visible;
        }

        public void SetOptionsVisible(bool visible)
        {
            this.panelOptions.Visible = visible;
        }

        public void SetInitialOption()
        {
            this.radioButtonOptionOne.Checked = true;
        }
    }
}
