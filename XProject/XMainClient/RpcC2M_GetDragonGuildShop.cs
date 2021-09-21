using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001640 RID: 5696
	internal class RpcC2M_GetDragonGuildShop : Rpc
	{
		// Token: 0x0600EE44 RID: 60996 RVA: 0x0034988C File Offset: 0x00347A8C
		public override uint GetRpcType()
		{
			return 6075U;
		}

		// Token: 0x0600EE45 RID: 60997 RVA: 0x003498A3 File Offset: 0x00347AA3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildShopArg>(stream, this.oArg);
		}

		// Token: 0x0600EE46 RID: 60998 RVA: 0x003498B3 File Offset: 0x00347AB3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildShopRes>(stream);
		}

		// Token: 0x0600EE47 RID: 60999 RVA: 0x003498C2 File Offset: 0x00347AC2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildShop.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE48 RID: 61000 RVA: 0x003498DE File Offset: 0x00347ADE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildShop.OnTimeout(this.oArg);
		}

		// Token: 0x0400660A RID: 26122
		public GetDragonGuildShopArg oArg = new GetDragonGuildShopArg();

		// Token: 0x0400660B RID: 26123
		public GetDragonGuildShopRes oRes = null;
	}
}
