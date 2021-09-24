using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SynGuildArenaRoleOnlineNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 26598U;
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
			Process_PtcM2C_SynGuildArenaRoleOnlineNew.Process(this);
		}

		public SynGuildArenaRoleOnline Data = new SynGuildArenaRoleOnline();
	}
}
