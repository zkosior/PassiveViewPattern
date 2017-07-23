namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Model : IModel
    {
        public Model(ISomeComunicationApi component)
        {
        }

        public event EventHandler<EventArgs> PluginEnabled;

        public event EventHandler<ErrorEventArgs> PluginDisabled;

        public event EventHandler<ErrorEventArgs> ErrorOccured;

        public void SetOption(Option option)
        {

        }

        public void Activated()
        {

        }

        public void Deactivated()
        {
            
        }
    }
}
