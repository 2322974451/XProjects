using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011C4 RID: 4548
	internal class PtcG2C_WorldBossAttrNtf : Protocol
	{
		// Token: 0x0600DBD7 RID: 56279 RVA: 0x0032F8F8 File Offset: 0x0032DAF8
		public override uint GetProtoType()
		{
			return 31578U;
		}

		// Token: 0x0600DBD8 RID: 56280 RVA: 0x0032F90F File Offset: 0x0032DB0F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossAttrNtf>(stream, this.Data);
		}

		// Token: 0x0600DBD9 RID: 56281 RVA: 0x0032F91F File Offset: 0x0032DB1F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldBossAttrNtf>(stream);
		}

		// Token: 0x0600DBDA RID: 56282 RVA: 0x0032F92E File Offset: 0x0032DB2E
		public override void Process()
		{
			Process_PtcG2C_WorldBossAttrNtf.Process(this);
		}

		// Token: 0x04006276 RID: 25206
		public WorldBossAttrNtf Data = new WorldBossAttrNtf();
	}
}
