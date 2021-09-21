using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012B1 RID: 4785
	internal class PtcG2C_TowerFirstPassRewardNtf : Protocol
	{
		// Token: 0x0600DFA4 RID: 57252 RVA: 0x00334EBC File Offset: 0x003330BC
		public override uint GetProtoType()
		{
			return 1039U;
		}

		// Token: 0x0600DFA5 RID: 57253 RVA: 0x00334ED3 File Offset: 0x003330D3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TowerFirstPassRewardData>(stream, this.Data);
		}

		// Token: 0x0600DFA6 RID: 57254 RVA: 0x00334EE3 File Offset: 0x003330E3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TowerFirstPassRewardData>(stream);
		}

		// Token: 0x0600DFA7 RID: 57255 RVA: 0x00334EF2 File Offset: 0x003330F2
		public override void Process()
		{
			Process_PtcG2C_TowerFirstPassRewardNtf.Process(this);
		}

		// Token: 0x04006332 RID: 25394
		public TowerFirstPassRewardData Data = new TowerFirstPassRewardData();
	}
}
