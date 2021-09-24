using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_WeddingInviteNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 35104U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingInviteNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingInviteNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_WeddingInviteNtf.Process(this);
		}

		public WeddingInviteNtf Data = new WeddingInviteNtf();
	}
}
