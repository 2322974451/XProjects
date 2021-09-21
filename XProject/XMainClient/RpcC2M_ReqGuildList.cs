using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200123D RID: 4669
	internal class RpcC2M_ReqGuildList : Rpc
	{
		// Token: 0x0600DDC2 RID: 56770 RVA: 0x0033250C File Offset: 0x0033070C
		public override uint GetRpcType()
		{
			return 46835U;
		}

		// Token: 0x0600DDC3 RID: 56771 RVA: 0x00332523 File Offset: 0x00330723
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchGuildListArg>(stream, this.oArg);
		}

		// Token: 0x0600DDC4 RID: 56772 RVA: 0x00332533 File Offset: 0x00330733
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchGuildListRes>(stream);
		}

		// Token: 0x0600DDC5 RID: 56773 RVA: 0x00332542 File Offset: 0x00330742
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDC6 RID: 56774 RVA: 0x0033255E File Offset: 0x0033075E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildList.OnTimeout(this.oArg);
		}

		// Token: 0x040062D3 RID: 25299
		public FetchGuildListArg oArg = new FetchGuildListArg();

		// Token: 0x040062D4 RID: 25300
		public FetchGuildListRes oRes = null;
	}
}
