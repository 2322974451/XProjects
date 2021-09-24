using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SynGuildIntegralState : Protocol
	{

		public override uint GetProtoType()
		{
			return 4104U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildIntegralState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildIntegralState>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SynGuildIntegralState.Process(this);
		}

		public SynGuildIntegralState Data = new SynGuildIntegralState();
	}
}
