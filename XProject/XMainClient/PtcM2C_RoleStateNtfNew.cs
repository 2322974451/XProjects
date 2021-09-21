using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011BE RID: 4542
	internal class PtcM2C_RoleStateNtfNew : Protocol
	{
		// Token: 0x0600DBBE RID: 56254 RVA: 0x0032F6F4 File Offset: 0x0032D8F4
		public override uint GetProtoType()
		{
			return 62463U;
		}

		// Token: 0x0600DBBF RID: 56255 RVA: 0x0032F70B File Offset: 0x0032D90B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RoleStateNtf>(stream, this.Data);
		}

		// Token: 0x0600DBC0 RID: 56256 RVA: 0x0032F71B File Offset: 0x0032D91B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RoleStateNtf>(stream);
		}

		// Token: 0x0600DBC1 RID: 56257 RVA: 0x0032F72A File Offset: 0x0032D92A
		public override void Process()
		{
			Process_PtcM2C_RoleStateNtfNew.Process(this);
		}

		// Token: 0x04006271 RID: 25201
		public RoleStateNtf Data = new RoleStateNtf();
	}
}
