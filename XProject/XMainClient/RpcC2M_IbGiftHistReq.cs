using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014EA RID: 5354
	internal class RpcC2M_IbGiftHistReq : Rpc
	{
		// Token: 0x0600E8B9 RID: 59577 RVA: 0x003419A4 File Offset: 0x0033FBA4
		public override uint GetRpcType()
		{
			return 27050U;
		}

		// Token: 0x0600E8BA RID: 59578 RVA: 0x003419BB File Offset: 0x0033FBBB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBGiftHistAllItemArg>(stream, this.oArg);
		}

		// Token: 0x0600E8BB RID: 59579 RVA: 0x003419CB File Offset: 0x0033FBCB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<IBGiftHistAllItemRes>(stream);
		}

		// Token: 0x0600E8BC RID: 59580 RVA: 0x003419DA File Offset: 0x0033FBDA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_IbGiftHistReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8BD RID: 59581 RVA: 0x003419F6 File Offset: 0x0033FBF6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_IbGiftHistReq.OnTimeout(this.oArg);
		}

		// Token: 0x040064ED RID: 25837
		public IBGiftHistAllItemArg oArg = new IBGiftHistAllItemArg();

		// Token: 0x040064EE RID: 25838
		public IBGiftHistAllItemRes oRes = null;
	}
}
