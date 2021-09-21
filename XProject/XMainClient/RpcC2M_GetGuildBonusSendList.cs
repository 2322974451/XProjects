using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001358 RID: 4952
	internal class RpcC2M_GetGuildBonusSendList : Rpc
	{
		// Token: 0x0600E251 RID: 57937 RVA: 0x00338DBC File Offset: 0x00336FBC
		public override uint GetRpcType()
		{
			return 59719U;
		}

		// Token: 0x0600E252 RID: 57938 RVA: 0x00338DD3 File Offset: 0x00336FD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusSendListArg>(stream, this.oArg);
		}

		// Token: 0x0600E253 RID: 57939 RVA: 0x00338DE3 File Offset: 0x00336FE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusSendListRes>(stream);
		}

		// Token: 0x0600E254 RID: 57940 RVA: 0x00338DF2 File Offset: 0x00336FF2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildBonusSendList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E255 RID: 57941 RVA: 0x00338E0E File Offset: 0x0033700E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildBonusSendList.OnTimeout(this.oArg);
		}

		// Token: 0x040063B6 RID: 25526
		public GetGuildBonusSendListArg oArg = new GetGuildBonusSendListArg();

		// Token: 0x040063B7 RID: 25527
		public GetGuildBonusSendListRes oRes = null;
	}
}
