namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IActivable
    {
        void Activate();

        void Deactivate();
    }
}
