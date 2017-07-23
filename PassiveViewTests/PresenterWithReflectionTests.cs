namespace PassiveViewTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    using NUnit.Framework;

    using PassiveViewPattern;

    using TypeMock.ArrangeActAssert;

    public class PresenterWithReflectionTests
    {
        [SetUp]
        public void SetUp()
        {
            Isolate.CleanUp();
        }
        [Test]
        public void PluginEnabled_Invoked_UpdateUIControlsVisibilityAndSelectInitialOption()
        {
            IView viewOrg = Isolate.Fake.Instance<IView>();
            IView viewSurrogate = Isolate.Fake.Instance<IView>();
            IModel model = Isolate.Fake.Instance<IModel>();

            Isolate.Fake.StaticMethods<Utilities>();
            Isolate.WhenCalled(() => Utilities.InvokeIfNeeded(viewOrg, null, null)).DoInstead(
                callContext =>
                viewSurrogate.GetType().GetMethod((string)callContext.Parameters[1]).Invoke(viewSurrogate, new[] { callContext.Parameters[2] }));
            Isolate.WhenCalled(() => Utilities.InvokeIfNeeded(viewOrg, (string)null)).DoInstead(
                callContext =>
                viewSurrogate.GetType().GetMethod((string)callContext.Parameters[1]).Invoke(viewSurrogate, new object[] { }));


            // Act
            new PresenterWithReflection(viewOrg, model);

            Isolate.Invoke.Event(() => model.PluginEnabled += null, model, EventArgs.Empty);

            // Assert
            Isolate.Verify.WasCalledWithExactArguments(() => viewSurrogate.SetWarningVisible(false));
            Isolate.Verify.WasCalledWithExactArguments(() => viewSurrogate.SetOptionsVisible(true));
            Isolate.Verify.WasCalledWithExactArguments(() => viewSurrogate.SetInitialOption());
        }
    }
}
