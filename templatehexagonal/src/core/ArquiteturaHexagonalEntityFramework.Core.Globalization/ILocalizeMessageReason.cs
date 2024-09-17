using TemplateHexagonal.Core.Domain.Enum;
using TemplateHexagonal.Core.Domain.Shared;

namespace TemplateHexagonal.Core.Globalization
{
    public interface ILocalizeMessageReason
    {
        MessageError LocalizeMessage(MessageReasonType enumb);
        MessageError LocalizeMessage(MessageReasonType enumb, string code);
    }
}
