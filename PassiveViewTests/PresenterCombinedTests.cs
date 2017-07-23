// -----------------------------------------------------------------------
// <copyright file="PresenterCombinedTests.cs" company="Tieto">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

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

    [TestFixture]
    public class PresenterCombinedTests
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
            Isolate.WhenCalled(() => Utilities.InvokeIfNeeded(viewOrg, (Action<IView>)null))
                .DoInstead(callContext => ((Action<IView>)callContext.Parameters[1])(viewSurrogate));

            new PresenterCombined(viewOrg, model);

            // Act
            Isolate.Invoke.Event(() => model.PluginEnabled += null, model, EventArgs.Empty);

            // Assert
            Isolate.Verify.WasCalledWithExactArguments(() => viewSurrogate.SetWarningVisible(false));
            Isolate.Verify.WasCalledWithExactArguments(() => viewSurrogate.SetOptionsVisible(true));
            Isolate.Verify.WasCalledWithExactArguments(() => viewSurrogate.SetInitialOption());
        }
    }
}
