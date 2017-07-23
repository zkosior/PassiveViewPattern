namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IInvokable
    {
        object Invoke(Delegate method);

        bool InvokeRequired { get; }
    }
}
