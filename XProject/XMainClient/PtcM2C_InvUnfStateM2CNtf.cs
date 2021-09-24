using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_InvUnfStateM2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 2693U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvUnfState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvUnfState>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_InvUnfStateM2CNtf.Process(this);
		}

		public InvUnfState Data = new InvUnfState();
	}
}
