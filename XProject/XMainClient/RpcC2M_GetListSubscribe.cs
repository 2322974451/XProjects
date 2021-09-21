using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001480 RID: 5248
	internal class RpcC2M_GetListSubscribe : Rpc
	{
		// Token: 0x0600E703 RID: 59139 RVA: 0x0033F63C File Offset: 0x0033D83C
		public override uint GetRpcType()
		{
			return 1403U;
		}

		// Token: 0x0600E704 RID: 59140 RVA: 0x0033F653 File Offset: 0x0033D853
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetListSubscribeArg>(stream, this.oArg);
		}

		// Token: 0x0600E705 RID: 59141 RVA: 0x0033F663 File Offset: 0x0033D863
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetListSubscribeRes>(stream);
		}

		// Token: 0x0600E706 RID: 59142 RVA: 0x0033F672 File Offset: 0x0033D872
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetListSubscribe.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E707 RID: 59143 RVA: 0x0033F68E File Offset: 0x0033D88E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetListSubscribe.OnTimeout(this.oArg);
		}

		// Token: 0x04006499 RID: 25753
		public GetListSubscribeArg oArg = new GetListSubscribeArg();

		// Token: 0x0400649A RID: 25754
		public GetListSubscribeRes oRes = null;
	}
}
