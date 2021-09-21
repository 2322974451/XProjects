using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015F3 RID: 5619
	internal class PtcG2C_BattleFieldRoleAgainstNtf : Protocol
	{
		// Token: 0x0600ECF9 RID: 60665 RVA: 0x00347C48 File Offset: 0x00345E48
		public override uint GetProtoType()
		{
			return 8049U;
		}

		// Token: 0x0600ECFA RID: 60666 RVA: 0x00347C5F File Offset: 0x00345E5F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldRoleAgainst>(stream, this.Data);
		}

		// Token: 0x0600ECFB RID: 60667 RVA: 0x00347C6F File Offset: 0x00345E6F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleFieldRoleAgainst>(stream);
		}

		// Token: 0x0600ECFC RID: 60668 RVA: 0x00347C7E File Offset: 0x00345E7E
		public override void Process()
		{
			Process_PtcG2C_BattleFieldRoleAgainstNtf.Process(this);
		}

		// Token: 0x040065C5 RID: 26053
		public BattleFieldRoleAgainst Data = new BattleFieldRoleAgainst();
	}
}
