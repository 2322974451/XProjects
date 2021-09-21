using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012C0 RID: 4800
	internal class RpcC2M_AskGuildArenaInfoNew : Rpc
	{
		// Token: 0x0600DFE2 RID: 57314 RVA: 0x0033541C File Offset: 0x0033361C
		public override uint GetRpcType()
		{
			return 24504U;
		}

		// Token: 0x0600DFE3 RID: 57315 RVA: 0x00335433 File Offset: 0x00333633
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildArenaInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DFE4 RID: 57316 RVA: 0x00335443 File Offset: 0x00333643
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildArenaInfoReq>(stream);
		}

		// Token: 0x0600DFE5 RID: 57317 RVA: 0x00335452 File Offset: 0x00333652
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildArenaInfoNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DFE6 RID: 57318 RVA: 0x0033546E File Offset: 0x0033366E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildArenaInfoNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400633E RID: 25406
		public AskGuildArenaInfoArg oArg = new AskGuildArenaInfoArg();

		// Token: 0x0400633F RID: 25407
		public AskGuildArenaInfoReq oRes = null;
	}
}
