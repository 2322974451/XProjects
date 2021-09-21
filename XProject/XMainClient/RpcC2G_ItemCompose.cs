using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014BF RID: 5311
	internal class RpcC2G_ItemCompose : Rpc
	{
		// Token: 0x0600E804 RID: 59396 RVA: 0x00340C94 File Offset: 0x0033EE94
		public override uint GetRpcType()
		{
			return 16118U;
		}

		// Token: 0x0600E805 RID: 59397 RVA: 0x00340CAB File Offset: 0x0033EEAB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemComposeArg>(stream, this.oArg);
		}

		// Token: 0x0600E806 RID: 59398 RVA: 0x00340CBB File Offset: 0x0033EEBB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemComposeRes>(stream);
		}

		// Token: 0x0600E807 RID: 59399 RVA: 0x00340CCA File Offset: 0x0033EECA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemCompose.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E808 RID: 59400 RVA: 0x00340CE6 File Offset: 0x0033EEE6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemCompose.OnTimeout(this.oArg);
		}

		// Token: 0x040064C9 RID: 25801
		public ItemComposeArg oArg = new ItemComposeArg();

		// Token: 0x040064CA RID: 25802
		public ItemComposeRes oRes = null;
	}
}
