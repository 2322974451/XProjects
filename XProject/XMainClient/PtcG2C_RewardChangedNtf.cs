using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001049 RID: 4169
	internal class PtcG2C_RewardChangedNtf : Protocol
	{
		// Token: 0x0600D5D9 RID: 54745 RVA: 0x00325070 File Offset: 0x00323270
		public override uint GetProtoType()
		{
			return 57873U;
		}

		// Token: 0x0600D5DA RID: 54746 RVA: 0x00325087 File Offset: 0x00323287
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RewardChanged>(stream, this.Data);
		}

		// Token: 0x0600D5DB RID: 54747 RVA: 0x00325097 File Offset: 0x00323297
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RewardChanged>(stream);
		}

		// Token: 0x0600D5DC RID: 54748 RVA: 0x003250A6 File Offset: 0x003232A6
		public override void Process()
		{
			Process_PtcG2C_RewardChangedNtf.Process(this);
		}

		// Token: 0x04006155 RID: 24917
		public RewardChanged Data = new RewardChanged();
	}
}
