namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public interface IModel
    {
        event EventHandler<EventArgs> PluginEnabled;

        event EventHandler<ErrorEventArgs> PluginDisabled;

        event EventHandler<ErrorEventArgs> ErrorOccured;

        void SetOption(Option option);

        void Activated();

        void Deactivated();
    }
}
