namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public class PresenterWithReflection
    {
        public PresenterWithReflection(IView view, IModel model)
        {
            InitializeUIControlsState(view);
            AttachToViewEvents(view, model);
            AttachToModelEvents(model, view);
        }

        private static void InitializeUIControlsState(IView view)
        {
            view.SetWarningVisible(false);
            view.SetOptionsVisible(false);
        }

        private static void AttachToViewEvents(IView view, IModel model)
        {
            view.Activated += (sender, args) => model.Activated();
            view.Deactivated += (sender, args) => model.Deactivated();
            view.OptionOneRadioButtonCheckedChanged += (sender, args) =>
                {
                    if (IsRadioButtonChecked(sender))
                    {
                        model.SetOption(Option.One);
                    }
                };
            view.OptionTwoRadioButtonCheckedChanged += (sender, args) =>
                {
                    if (IsRadioButtonChecked(sender))
                    {
                        model.SetOption(Option.Two);
                    }
                };
        }

        private static bool IsRadioButtonChecked(object sender)
        {
            RadioButton radioButton = sender as RadioButton;
            return radioButton != null == radioButton.Checked;
        }

        private static void AttachToModelEvents(IModel model, IView view)
        {
            model.PluginEnabled += (sender, args) =>
            {
                Utilities.InvokeIfNeeded(view, "SetOptionsVisible", true);
                Utilities.InvokeIfNeeded(view, "SetWarningVisible", false);
                Utilities.InvokeIfNeeded(view, "SetInitialOption");
            };
            model.PluginDisabled += (sender, args) =>
            {
                Utilities.InvokeIfNeeded(view, "SetOptionsVisible", false);
                Utilities.InvokeIfNeeded(view, "SetWarningVisible", true);
                Utilities.InvokeIfNeeded(view, "SetWarningText", args.Message);
            };
            model.ErrorOccured += (sender, args) =>
            {
                Utilities.InvokeIfNeeded(view, "SetOptionsVisible", false);
                Utilities.InvokeIfNeeded(view, "SetWarningVisible", true);
                Utilities.InvokeIfNeeded(view, "SetWarningText", args.Message);
            };
        }
    }
}
