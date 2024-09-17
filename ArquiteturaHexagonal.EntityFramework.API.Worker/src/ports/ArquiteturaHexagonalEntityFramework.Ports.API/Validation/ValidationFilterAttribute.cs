using TemplateHexagonal.Core.Domain.Enum;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TemplateHexagonal.Core.Globalization.Message;
using TemplateHexagonal.Core.Domain.Shared;
using TemplateHexagonal.Core.Infra.Shared;

namespace TemplateHexagonal.Ports.API.Validation
{
    public class ValidationFilterAttribute : IActionFilter
    {
        private readonly ILocalizeMessageReason _localizeMessageReason;

        public ValidationFilterAttribute(ILocalizeMessageReason localizeMessageReason)
        {
            _localizeMessageReason = localizeMessageReason;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                MessageError message = _localizeMessageReason.LocalizeMessage(MessageReasonType.Code001InvalidParameter);

                var error = context.ModelState.Where(x => x.Value?.Errors.Count > 0)
                                               .ToList()?
                                               .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).FirstOrDefault()).LastOrDefault();

                var newMessageReasonType = EnumHelper.GetValueFromDescription<MessageReasonType>(error.Value.Value);

                if (newMessageReasonType != MessageReasonType.Code001InvalidParameter)
                    message = _localizeMessageReason.LocalizeMessage(newMessageReasonType);

                context.Result = new BadRequestObjectResult(new
                {
                    Error = message.Code,
                    ErrorDescription = string.Format("Payload incorreto - " + message.Description ?? "+ - {0} ", "'" + error.Value.Key.Replace("$.", "") + "'")
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }
}
