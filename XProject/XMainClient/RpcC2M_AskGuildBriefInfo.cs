using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001229 RID: 4649
	internal class RpcC2M_AskGuildBriefInfo : Rpc
	{
		// Token: 0x0600DD6E RID: 56686 RVA: 0x00331D20 File Offset: 0x0032FF20
		public override uint GetRpcType()
		{
			return 53355U;
		}

		// Token: 0x0600DD6F RID: 56687 RVA: 0x00331D37 File Offset: 0x0032FF37
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBriefArg>(stream, this.oArg);
		}

		// Token: 0x0600DD70 RID: 56688 RVA: 0x00331D47 File Offset: 0x0032FF47
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildBriefRes>(stream);
		}

		// Token: 0x0600DD71 RID: 56689 RVA: 0x00331D56 File Offset: 0x0032FF56
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildBriefInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD72 RID: 56690 RVA: 0x00331D72 File Offset: 0x0032FF72
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildBriefInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040062C2 RID: 25282
		public GuildBriefArg oArg = new GuildBriefArg();

		// Token: 0x040062C3 RID: 25283
		public GuildBriefRes oRes = null;
	}
}
