using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200155E RID: 5470
	internal class PtcG2C_BMRoleSceneSyncNtf : Protocol
	{
		// Token: 0x0600EA90 RID: 60048 RVA: 0x00344758 File Offset: 0x00342958
		public override uint GetProtoType()
		{
			return 40091U;
		}

		// Token: 0x0600EA91 RID: 60049 RVA: 0x0034476F File Offset: 0x0034296F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BMRoleSceneSync>(stream, this.Data);
		}

		// Token: 0x0600EA92 RID: 60050 RVA: 0x0034477F File Offset: 0x0034297F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BMRoleSceneSync>(stream);
		}

		// Token: 0x0600EA93 RID: 60051 RVA: 0x0034478E File Offset: 0x0034298E
		public override void Process()
		{
			Process_PtcG2C_BMRoleSceneSyncNtf.Process(this);
		}

		// Token: 0x0400654E RID: 25934
		public BMRoleSceneSync Data = new BMRoleSceneSync();
	}
}
