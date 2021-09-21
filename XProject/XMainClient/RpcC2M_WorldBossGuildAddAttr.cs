using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014C3 RID: 5315
	internal class RpcC2M_WorldBossGuildAddAttr : Rpc
	{
		// Token: 0x0600E814 RID: 59412 RVA: 0x00340DF4 File Offset: 0x0033EFF4
		public override uint GetRpcType()
		{
			return 9805U;
		}

		// Token: 0x0600E815 RID: 59413 RVA: 0x00340E0B File Offset: 0x0033F00B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossGuildAddAttrArg>(stream, this.oArg);
		}

		// Token: 0x0600E816 RID: 59414 RVA: 0x00340E1B File Offset: 0x0033F01B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WorldBossGuildAddAttrRes>(stream);
		}

		// Token: 0x0600E817 RID: 59415 RVA: 0x00340E2A File Offset: 0x0033F02A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_WorldBossGuildAddAttr.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E818 RID: 59416 RVA: 0x00340E46 File Offset: 0x0033F046
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_WorldBossGuildAddAttr.OnTimeout(this.oArg);
		}

		// Token: 0x040064CC RID: 25804
		public WorldBossGuildAddAttrArg oArg = new WorldBossGuildAddAttrArg();

		// Token: 0x040064CD RID: 25805
		public WorldBossGuildAddAttrRes oRes = null;
	}
}
