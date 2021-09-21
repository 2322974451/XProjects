using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001174 RID: 4468
	internal class PtcG2C_GmfJoinBattleReq : Protocol
	{
		// Token: 0x0600DAA5 RID: 55973 RVA: 0x0032DF5C File Offset: 0x0032C15C
		public override uint GetProtoType()
		{
			return 19954U;
		}

		// Token: 0x0600DAA6 RID: 55974 RVA: 0x0032DF73 File Offset: 0x0032C173
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfJoinBattleArg>(stream, this.Data);
		}

		// Token: 0x0600DAA7 RID: 55975 RVA: 0x0032DF83 File Offset: 0x0032C183
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfJoinBattleArg>(stream);
		}

		// Token: 0x0600DAA8 RID: 55976 RVA: 0x0032DF92 File Offset: 0x0032C192
		public override void Process()
		{
			Process_PtcG2C_GmfJoinBattleReq.Process(this);
		}

		// Token: 0x04006243 RID: 25155
		public GmfJoinBattleArg Data = new GmfJoinBattleArg();
	}
}
