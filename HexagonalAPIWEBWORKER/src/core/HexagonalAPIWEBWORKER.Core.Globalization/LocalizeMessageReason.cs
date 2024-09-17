using HexagonalAPIWEBWORKER.Core.Domain.Enum;
using HexagonalAPIWEBWORKER.Core.Domain.Shared;
using HexagonalAPIWEBWORKER.Core.Infra.Shared;
using Microsoft.Extensions.Localization;
using HexagonalAPIWEBWORKER.Core.Globalization;

namespace HexagonalAPIWEBWORKER.Core.Globalization
{
    public class LocalizeMessageReason : ILocalizeMessageReason
    {
        private readonly IStringLocalizer<Resource> _localizer;

        public LocalizeMessageReason(IStringLocalizer<Resource> localizer)
        {
            _localizer = localizer;
        }

        public MessageError LocalizeMessage(MessageReasonType enumb)
        {
            return new MessageError(FormatErrorCode(enumb.GetDescription()),
                                        FormatErrorDescription(enumb));
        }

        public MessageError LocalizeMessage(MessageReasonType enumb, string code)
        {
            if (string.IsNullOrEmpty(code))
                return LocalizeMessage(enumb);

            return new MessageError(code, FormatErrorDescription(enumb));
        }
        private string FormatErrorCode(string authorizeErrorCode)
        {
            return authorizeErrorCode ?? string.Empty;
        }

        private string FormatErrorDescription(MessageReasonType enumb)
        {
            string description = enumb.GetDescription();

            return $"{_localizer[description].Value} ({description})" ?? string.Empty;
        }
    }
}
