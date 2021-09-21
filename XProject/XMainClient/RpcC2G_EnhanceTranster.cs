using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001137 RID: 4407
	internal class RpcC2G_EnhanceTranster : Rpc
	{
		// Token: 0x0600D9A2 RID: 55714 RVA: 0x0032B624 File Offset: 0x00329824
		public override uint GetRpcType()
		{
			return 25778U;
		}

		// Token: 0x0600D9A3 RID: 55715 RVA: 0x0032B63B File Offset: 0x0032983B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnhanceTransterArg>(stream, this.oArg);
		}

		// Token: 0x0600D9A4 RID: 55716 RVA: 0x0032B64B File Offset: 0x0032984B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnhanceTransterRes>(stream);
		}

		// Token: 0x0600D9A5 RID: 55717 RVA: 0x0032B65A File Offset: 0x0032985A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnhanceTranster.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D9A6 RID: 55718 RVA: 0x0032B676 File Offset: 0x00329876
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnhanceTranster.OnTimeout(this.oArg);
		}

		// Token: 0x0400620E RID: 25102
		public EnhanceTransterArg oArg = new EnhanceTransterArg();

		// Token: 0x0400620F RID: 25103
		public EnhanceTransterRes oRes = new EnhanceTransterRes();
	}
}
