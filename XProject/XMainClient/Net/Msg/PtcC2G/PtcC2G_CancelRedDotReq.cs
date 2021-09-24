using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_CancelRedDotReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 40873U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CancelRedDot>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CancelRedDot>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public CancelRedDot Data = new CancelRedDot();
	}
}
