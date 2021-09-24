using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_NotifyPlatShareResult : Protocol
	{

		public override uint GetProtoType()
		{
			return 8480U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyPlatShareResultArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyPlatShareResultArg>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public NotifyPlatShareResultArg Data = new NotifyPlatShareResultArg();
	}
}
