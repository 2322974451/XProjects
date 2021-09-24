using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_EnterSceneCoolDownQuery : Protocol
	{

		public override uint GetProtoType()
		{
			return 40442U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterSceneCoolDownQuery>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EnterSceneCoolDownQuery>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public EnterSceneCoolDownQuery Data = new EnterSceneCoolDownQuery();
	}
}
