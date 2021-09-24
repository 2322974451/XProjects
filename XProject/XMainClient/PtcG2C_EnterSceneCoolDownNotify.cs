using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_EnterSceneCoolDownNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 38664U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterSceneCoolDownNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EnterSceneCoolDownNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_EnterSceneCoolDownNotify.Process(this);
		}

		public EnterSceneCoolDownNotify Data = new EnterSceneCoolDownNotify();
	}
}
