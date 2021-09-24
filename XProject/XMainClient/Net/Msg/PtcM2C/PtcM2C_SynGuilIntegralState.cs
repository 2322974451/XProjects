using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SynGuilIntegralState : Protocol
	{

		public override uint GetProtoType()
		{
			return 28075U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuilIntegralState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuilIntegralState>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SynGuilIntegralState.Process(this);
		}

		public SynGuilIntegralState Data = new SynGuilIntegralState();
	}
}
