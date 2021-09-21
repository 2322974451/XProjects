using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B4C RID: 2892
	internal class RpcC2G_LeagueBattleReadyReq : Rpc
	{
		// Token: 0x0600A8A8 RID: 43176 RVA: 0x001E0E28 File Offset: 0x001DF028
		public override uint GetRpcType()
		{
			return 15873U;
		}

		// Token: 0x0600A8A9 RID: 43177 RVA: 0x001E0E3F File Offset: 0x001DF03F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleReadyReqArg>(stream, this.oArg);
		}

		// Token: 0x0600A8AA RID: 43178 RVA: 0x001E0E4F File Offset: 0x001DF04F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeagueBattleReadyReqRes>(stream);
		}

		// Token: 0x0600A8AB RID: 43179 RVA: 0x001E0E5E File Offset: 0x001DF05E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LeagueBattleReadyReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8AC RID: 43180 RVA: 0x001E0E7A File Offset: 0x001DF07A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LeagueBattleReadyReq.OnTimeout(this.oArg);
		}

		// Token: 0x04003E7D RID: 15997
		public LeagueBattleReadyReqArg oArg = new LeagueBattleReadyReqArg();

		// Token: 0x04003E7E RID: 15998
		public LeagueBattleReadyReqRes oRes = null;
	}
}
