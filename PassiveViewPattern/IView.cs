namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    public interface IView : ISynchronizeInvoke, IInvokable
    {
        event EventHandler Activated;
        event EventHandler Deactivated;
        event EventHandler OptionOneRadioButtonCheckedChanged;
        event EventHandler OptionTwoRadioButtonCheckedChanged;
        void SetWarningText(string text);
        void SetWarningVisible(bool visible);
        void SetOptionsVisible(bool visible);
        void SetInitialOption();
    }
}
