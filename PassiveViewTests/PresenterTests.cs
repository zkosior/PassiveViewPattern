using System;
using System.Collections.Generic;
using System.Text;

namespace PassiveViewTests
{
    using System.Linq.Expressions;

    using NUnit.Framework;

    using PassiveViewPattern;

    using TypeMock.ArrangeActAssert;

    [TestFixture]
    public class PresenterTests
    {
        [SetUp]
        public void SetUp()
        {
            Isolate.CleanUp();
        }
        [Test]
        public void PluginEnabled_Invoked_UpdateUIControlsVisibilityAndSelectInitialOption()
        {
            IView view = Isolate.Fake.Instance<IView>();
            IModel model = Isolate.Fake.Instance<IModel>();
            Isolate.Fake.StaticMethods<Utilities>();

            new Presenter(view, model);

            // Act
            Isolate.Invoke.Event(() => model.PluginEnabled += null, model, EventArgs.Empty);

            // Assert
            Isolate.Verify.WasCalledWithArguments(() => Utilities.InvokeIfNeeded(view, (Expression<Action>)null))
            .Matching(args => Validator.Validate((Expression<Action>)args[1], () => view.SetWarningVisible(false)));
            Isolate.Verify.WasCalledWithArguments(() => Utilities.InvokeIfNeeded(view, (Expression<Action>)null))
            .Matching(args => Validator.Validate((Expression<Action>)args[1], () => view.SetOptionsVisible(true)));
            Isolate.Verify.WasCalledWithArguments(() => Utilities.InvokeIfNeeded(view, (Expression<Action>)null))
            .Matching(args => Validator.Validate((Expression<Action>)args[1], () => view.SetInitialOption()));
        }
    }
}
