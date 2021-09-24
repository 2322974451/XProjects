using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_InviteRefuseM2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 33486U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InviteRufuse>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InviteRufuse>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_InviteRefuseM2CNtf.Process(this);
		}

		public InviteRufuse Data = new InviteRufuse();
	}
}
