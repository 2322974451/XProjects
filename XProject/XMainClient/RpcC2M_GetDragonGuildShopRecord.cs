using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001642 RID: 5698
	internal class RpcC2M_GetDragonGuildShopRecord : Rpc
	{
		// Token: 0x0600EE4D RID: 61005 RVA: 0x00349930 File Offset: 0x00347B30
		public override uint GetRpcType()
		{
			return 3114U;
		}

		// Token: 0x0600EE4E RID: 61006 RVA: 0x00349947 File Offset: 0x00347B47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildShopRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600EE4F RID: 61007 RVA: 0x00349957 File Offset: 0x00347B57
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildShopRecordRes>(stream);
		}

		// Token: 0x0600EE50 RID: 61008 RVA: 0x00349966 File Offset: 0x00347B66
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildShopRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE51 RID: 61009 RVA: 0x00349982 File Offset: 0x00347B82
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildShopRecord.OnTimeout(this.oArg);
		}

		// Token: 0x0400660C RID: 26124
		public GetDragonGuildShopRecordArg oArg = new GetDragonGuildShopRecordArg();

		// Token: 0x0400660D RID: 26125
		public GetDragonGuildShopRecordRes oRes = null;
	}
}
