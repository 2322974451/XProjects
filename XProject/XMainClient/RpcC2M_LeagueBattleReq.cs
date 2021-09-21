using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200146C RID: 5228
	internal class RpcC2M_LeagueBattleReq : Rpc
	{
		// Token: 0x0600E6B5 RID: 59061 RVA: 0x0033EEB0 File Offset: 0x0033D0B0
		public override uint GetRpcType()
		{
			return 8012U;
		}

		// Token: 0x0600E6B6 RID: 59062 RVA: 0x0033EEC7 File Offset: 0x0033D0C7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleReqArg>(stream, this.oArg);
		}

		// Token: 0x0600E6B7 RID: 59063 RVA: 0x0033EED7 File Offset: 0x0033D0D7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeagueBattleReqRes>(stream);
		}

		// Token: 0x0600E6B8 RID: 59064 RVA: 0x0033EEE6 File Offset: 0x0033D0E6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeagueBattleReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E6B9 RID: 59065 RVA: 0x0033EF02 File Offset: 0x0033D102
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeagueBattleReq.OnTimeout(this.oArg);
		}

		// Token: 0x0400648B RID: 25739
		public LeagueBattleReqArg oArg = new LeagueBattleReqArg();

		// Token: 0x0400648C RID: 25740
		public LeagueBattleReqRes oRes = null;
	}
}
