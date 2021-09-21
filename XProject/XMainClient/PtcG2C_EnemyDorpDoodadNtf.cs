using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010A2 RID: 4258
	internal class PtcG2C_EnemyDorpDoodadNtf : Protocol
	{
		// Token: 0x0600D748 RID: 55112 RVA: 0x00327AF0 File Offset: 0x00325CF0
		public override uint GetProtoType()
		{
			return 55996U;
		}

		// Token: 0x0600D749 RID: 55113 RVA: 0x00327B07 File Offset: 0x00325D07
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnemyDropDoodadInfo>(stream, this.Data);
		}

		// Token: 0x0600D74A RID: 55114 RVA: 0x00327B17 File Offset: 0x00325D17
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EnemyDropDoodadInfo>(stream);
		}

		// Token: 0x0600D74B RID: 55115 RVA: 0x00327B26 File Offset: 0x00325D26
		public override void Process()
		{
			Process_PtcG2C_EnemyDorpDoodadNtf.Process(this);
		}

		// Token: 0x040061A1 RID: 24993
		public EnemyDropDoodadInfo Data = new EnemyDropDoodadInfo();
	}
}
