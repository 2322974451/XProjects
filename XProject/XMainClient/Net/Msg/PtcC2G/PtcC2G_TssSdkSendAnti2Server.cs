using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_TssSdkSendAnti2Server : Protocol
	{

		public override uint GetProtoType()
		{
			return 62305U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TssSdkAntiData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TssSdkAntiData>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public TssSdkAntiData Data = new TssSdkAntiData();
	}
}
