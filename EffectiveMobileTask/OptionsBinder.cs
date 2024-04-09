using System.CommandLine;
using System.CommandLine.Binding;
using System.Net;

namespace EffectiveMobileTask
{
    public class OptionsBinder : BinderBase<SelectorsOptions>
    {
        private readonly Option<DateOnly> _timeStartOption;
        private readonly Option<DateOnly> _timeEndOption;
        private readonly Option<IPAddress> _addressStartOption;
        private readonly Option<IPAddress> _addressEndOption;

        public OptionsBinder(
            Option<DateOnly> timeStartOption,
            Option<DateOnly> timeEndOption,
            Option<IPAddress> addressStartOption,
            Option<IPAddress> addressEndOption)
        {
            _timeStartOption = timeStartOption;
            _timeEndOption = timeEndOption;
            _addressStartOption = addressStartOption;
            _addressEndOption = addressEndOption;
        }

        protected override SelectorsOptions GetBoundValue(BindingContext bindingContext) =>
            new SelectorsOptions(
                bindingContext.ParseResult.GetValueForOption(_timeStartOption),
                bindingContext.ParseResult.GetValueForOption(_timeEndOption),
                bindingContext.ParseResult.GetValueForOption(_addressStartOption),
                bindingContext.ParseResult.GetValueForOption(_addressEndOption));
    }
}