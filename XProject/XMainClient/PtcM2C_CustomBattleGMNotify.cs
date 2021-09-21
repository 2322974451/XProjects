using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001520 RID: 5408
	internal class PtcM2C_CustomBattleGMNotify : Protocol
	{
		// Token: 0x0600E99A RID: 59802 RVA: 0x00342F64 File Offset: 0x00341164
		public override uint GetProtoType()
		{
			return 65108U;
		}

		// Token: 0x0600E99B RID: 59803 RVA: 0x00342F7B File Offset: 0x0034117B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CustomBattleGMNotify>(stream, this.Data);
		}

		// Token: 0x0600E99C RID: 59804 RVA: 0x00342F8B File Offset: 0x0034118B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CustomBattleGMNotify>(stream);
		}

		// Token: 0x0600E99D RID: 59805 RVA: 0x00342F9A File Offset: 0x0034119A
		public override void Process()
		{
			Process_PtcM2C_CustomBattleGMNotify.Process(this);
		}

		// Token: 0x0400651A RID: 25882
		public CustomBattleGMNotify Data = new CustomBattleGMNotify();
	}
}
