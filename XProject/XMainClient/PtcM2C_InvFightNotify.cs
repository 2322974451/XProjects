using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_InvFightNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 38172U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvFightPara>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_InvFightNotify.Process(this);
		}

		public InvFightPara Data = new InvFightPara();
	}
}
