using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200144C RID: 5196
	internal class RpcC2G_GetHeroBattleGameRecord : Rpc
	{
		// Token: 0x0600E639 RID: 58937 RVA: 0x0033E264 File Offset: 0x0033C464
		public override uint GetRpcType()
		{
			return 41057U;
		}

		// Token: 0x0600E63A RID: 58938 RVA: 0x0033E27B File Offset: 0x0033C47B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHeroBattleGameRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600E63B RID: 58939 RVA: 0x0033E28B File Offset: 0x0033C48B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHeroBattleGameRecordRes>(stream);
		}

		// Token: 0x0600E63C RID: 58940 RVA: 0x0033E29A File Offset: 0x0033C49A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHeroBattleGameRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E63D RID: 58941 RVA: 0x0033E2B6 File Offset: 0x0033C4B6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHeroBattleGameRecord.OnTimeout(this.oArg);
		}

		// Token: 0x04006476 RID: 25718
		public GetHeroBattleGameRecordArg oArg = new GetHeroBattleGameRecordArg();

		// Token: 0x04006477 RID: 25719
		public GetHeroBattleGameRecordRes oRes = null;
	}
}
