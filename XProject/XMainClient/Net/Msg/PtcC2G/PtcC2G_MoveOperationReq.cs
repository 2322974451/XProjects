using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_MoveOperationReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 30732U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MoveInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MoveInfo>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public MoveInfo Data = new MoveInfo();
	}
}
