using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_InvfightAgainReqC2G : Protocol
	{

		public override uint GetProtoType()
		{
			return 2055U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightAgainPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvFightAgainPara>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public InvFightAgainPara Data = new InvFightAgainPara();
	}
}
