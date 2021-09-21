using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200130F RID: 4879
	internal class RpcC2M_GuildBindGroup : Rpc
	{
		// Token: 0x0600E128 RID: 57640 RVA: 0x003371D4 File Offset: 0x003353D4
		public override uint GetRpcType()
		{
			return 16003U;
		}

		// Token: 0x0600E129 RID: 57641 RVA: 0x003371EB File Offset: 0x003353EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBindGroupReq>(stream, this.oArg);
		}

		// Token: 0x0600E12A RID: 57642 RVA: 0x003371FB File Offset: 0x003353FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildBindGroupRes>(stream);
		}

		// Token: 0x0600E12B RID: 57643 RVA: 0x0033720A File Offset: 0x0033540A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildBindGroup.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E12C RID: 57644 RVA: 0x00337226 File Offset: 0x00335426
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildBindGroup.OnTimeout(this.oArg);
		}

		// Token: 0x0400637D RID: 25469
		public GuildBindGroupReq oArg = new GuildBindGroupReq();

		// Token: 0x0400637E RID: 25470
		public GuildBindGroupRes oRes = null;
	}
}
