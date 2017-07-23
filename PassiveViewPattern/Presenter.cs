namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    public class Presenter
    {
        public Presenter(IView view, IModel model)
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
                    Utilities.InvokeIfNeeded(view, () => view.SetWarningVisible(false));
                    Utilities.InvokeIfNeeded(view, () => view.SetOptionsVisible(true));
                    Utilities.InvokeIfNeeded(view, () => view.SetInitialOption());
                };
            model.PluginDisabled += (sender, args) =>
                {
                    Utilities.InvokeIfNeeded(view, () => view.SetWarningVisible(true));
                    Utilities.InvokeIfNeeded(view, () => view.SetOptionsVisible(false));
                    Utilities.InvokeIfNeeded(view, () => view.SetWarningText(args.Message));
                };
            model.ErrorOccured += (sender, args) =>
                {
                    Utilities.InvokeIfNeeded(view, () => view.SetWarningVisible(true));
                    Utilities.InvokeIfNeeded(view, () => view.SetOptionsVisible(false));
                    Utilities.InvokeIfNeeded(view, () => view.SetWarningText(args.Message));
                };
        }
    }
}
