using Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IMessageAppService
    {
        MessageDto CreateMessage(string service);

        byte[] EncodeMessage(MessageDto dto);

        string DecodeMessage(ReadOnlyMemory<byte> message);

        string ReturnMessage(MessageDto dto);
    }
}
