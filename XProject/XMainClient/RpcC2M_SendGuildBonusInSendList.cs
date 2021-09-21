using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200135A RID: 4954
	internal class RpcC2M_SendGuildBonusInSendList : Rpc
	{
		// Token: 0x0600E25A RID: 57946 RVA: 0x00338E78 File Offset: 0x00337078
		public override uint GetRpcType()
		{
			return 64498U;
		}

		// Token: 0x0600E25B RID: 57947 RVA: 0x00338E8F File Offset: 0x0033708F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGuildBonusInSendListArg>(stream, this.oArg);
		}

		// Token: 0x0600E25C RID: 57948 RVA: 0x00338E9F File Offset: 0x0033709F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendGuildBonusInSendListRes>(stream);
		}

		// Token: 0x0600E25D RID: 57949 RVA: 0x00338EAE File Offset: 0x003370AE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SendGuildBonusInSendList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E25E RID: 57950 RVA: 0x00338ECA File Offset: 0x003370CA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SendGuildBonusInSendList.OnTimeout(this.oArg);
		}

		// Token: 0x040063B8 RID: 25528
		public SendGuildBonusInSendListArg oArg = new SendGuildBonusInSendListArg();

		// Token: 0x040063B9 RID: 25529
		public SendGuildBonusInSendListRes oRes = null;
	}
}
