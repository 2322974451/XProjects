using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200122D RID: 4653
	internal class RpcC2M_LeaveFromGuild : Rpc
	{
		// Token: 0x0600DD80 RID: 56704 RVA: 0x00331F54 File Offset: 0x00330154
		public override uint GetRpcType()
		{
			return 2565U;
		}

		// Token: 0x0600DD81 RID: 56705 RVA: 0x00331F6B File Offset: 0x0033016B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveGuildArg>(stream, this.oArg);
		}

		// Token: 0x0600DD82 RID: 56706 RVA: 0x00331F7B File Offset: 0x0033017B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveGuildRes>(stream);
		}

		// Token: 0x0600DD83 RID: 56707 RVA: 0x00331F8A File Offset: 0x0033018A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveFromGuild.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD84 RID: 56708 RVA: 0x00331FA6 File Offset: 0x003301A6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveFromGuild.OnTimeout(this.oArg);
		}

		// Token: 0x040062C6 RID: 25286
		public LeaveGuildArg oArg = new LeaveGuildArg();

		// Token: 0x040062C7 RID: 25287
		public LeaveGuildRes oRes = null;
	}
}
