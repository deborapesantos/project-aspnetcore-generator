using HexagonalAPIWEBWORKER.Core.Domain.Enum;
using HexagonalAPIWEBWORKER.Core.Domain.Shared;

namespace HexagonalAPIWEBWORKER.Core.Globalization
{
    public interface ILocalizeMessageReason
    {
        MessageError LocalizeMessage(MessageReasonType enumb);
        MessageError LocalizeMessage(MessageReasonType enumb, string code);
    }
}
