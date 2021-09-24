using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SynGuildArenaRoleOnline : Protocol
	{

		public override uint GetProtoType()
		{
			return 48528U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaRoleOnline>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaRoleOnline>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SynGuildArenaRoleOnline.Process(this);
		}

		public SynGuildArenaRoleOnline Data = new SynGuildArenaRoleOnline();
	}
}
