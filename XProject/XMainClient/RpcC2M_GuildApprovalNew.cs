using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001295 RID: 4757
	internal class RpcC2M_GuildApprovalNew : Rpc
	{
		// Token: 0x0600DF34 RID: 57140 RVA: 0x00334350 File Offset: 0x00332550
		public override uint GetRpcType()
		{
			return 28348U;
		}

		// Token: 0x0600DF35 RID: 57141 RVA: 0x00334367 File Offset: 0x00332567
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildApprovalArg>(stream, this.oArg);
		}

		// Token: 0x0600DF36 RID: 57142 RVA: 0x00334377 File Offset: 0x00332577
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildApprovalRes>(stream);
		}

		// Token: 0x0600DF37 RID: 57143 RVA: 0x00334386 File Offset: 0x00332586
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildApprovalNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF38 RID: 57144 RVA: 0x003343A2 File Offset: 0x003325A2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildApprovalNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400631D RID: 25373
		public GuildApprovalArg oArg = new GuildApprovalArg();

		// Token: 0x0400631E RID: 25374
		public GuildApprovalRes oRes = null;
	}
}
