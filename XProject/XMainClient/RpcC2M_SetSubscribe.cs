using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001482 RID: 5250
	internal class RpcC2M_SetSubscribe : Rpc
	{
		// Token: 0x0600E70C RID: 59148 RVA: 0x0033F730 File Offset: 0x0033D930
		public override uint GetRpcType()
		{
			return 40540U;
		}

		// Token: 0x0600E70D RID: 59149 RVA: 0x0033F747 File Offset: 0x0033D947
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetSubscirbeArg>(stream, this.oArg);
		}

		// Token: 0x0600E70E RID: 59150 RVA: 0x0033F757 File Offset: 0x0033D957
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetSubscribeRes>(stream);
		}

		// Token: 0x0600E70F RID: 59151 RVA: 0x0033F766 File Offset: 0x0033D966
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SetSubscribe.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E710 RID: 59152 RVA: 0x0033F782 File Offset: 0x0033D982
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SetSubscribe.OnTimeout(this.oArg);
		}

		// Token: 0x0400649B RID: 25755
		public SetSubscirbeArg oArg = new SetSubscirbeArg();

		// Token: 0x0400649C RID: 25756
		public SetSubscribeRes oRes = null;
	}
}
