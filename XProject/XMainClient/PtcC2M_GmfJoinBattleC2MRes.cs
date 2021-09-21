using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012BD RID: 4797
	internal class PtcC2M_GmfJoinBattleC2MRes : Protocol
	{
		// Token: 0x0600DFD4 RID: 57300 RVA: 0x003352D4 File Offset: 0x003334D4
		public override uint GetProtoType()
		{
			return 25047U;
		}

		// Token: 0x0600DFD5 RID: 57301 RVA: 0x003352EB File Offset: 0x003334EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfJoinBattleRes>(stream, this.Data);
		}

		// Token: 0x0600DFD6 RID: 57302 RVA: 0x003352FB File Offset: 0x003334FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfJoinBattleRes>(stream);
		}

		// Token: 0x0600DFD7 RID: 57303 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400633B RID: 25403
		public GmfJoinBattleRes Data = new GmfJoinBattleRes();
	}
}
