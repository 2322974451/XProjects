using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012A9 RID: 4777
	internal class RpcC2M_GuildCheckinNew : Rpc
	{
		// Token: 0x0600DF82 RID: 57218 RVA: 0x00334B18 File Offset: 0x00332D18
		public override uint GetRpcType()
		{
			return 5584U;
		}

		// Token: 0x0600DF83 RID: 57219 RVA: 0x00334B2F File Offset: 0x00332D2F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCheckinArg>(stream, this.oArg);
		}

		// Token: 0x0600DF84 RID: 57220 RVA: 0x00334B3F File Offset: 0x00332D3F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCheckinRes>(stream);
		}

		// Token: 0x0600DF85 RID: 57221 RVA: 0x00334B4E File Offset: 0x00332D4E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildCheckinNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF86 RID: 57222 RVA: 0x00334B6A File Offset: 0x00332D6A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildCheckinNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400632B RID: 25387
		public GuildCheckinArg oArg = new GuildCheckinArg();

		// Token: 0x0400632C RID: 25388
		public GuildCheckinRes oRes = null;
	}
}
