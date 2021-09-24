using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_CheckQueuingReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 28232U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckQueuingReq>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckQueuingReq>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public CheckQueuingReq Data = new CheckQueuingReq();
	}
}
