using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014E5 RID: 5349
	internal class RpcC2M_GetSkyCraftEliInfo : Rpc
	{
		// Token: 0x0600E8A2 RID: 59554 RVA: 0x00341858 File Offset: 0x0033FA58
		public override uint GetRpcType()
		{
			return 41103U;
		}

		// Token: 0x0600E8A3 RID: 59555 RVA: 0x0034186F File Offset: 0x0033FA6F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftEliInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E8A4 RID: 59556 RVA: 0x0034187F File Offset: 0x0033FA7F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftEliInfoRes>(stream);
		}

		// Token: 0x0600E8A5 RID: 59557 RVA: 0x0034188E File Offset: 0x0033FA8E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftEliInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8A6 RID: 59558 RVA: 0x003418AA File Offset: 0x0033FAAA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftEliInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040064E8 RID: 25832
		public GetSkyCraftEliInfoArg oArg = new GetSkyCraftEliInfoArg();

		// Token: 0x040064E9 RID: 25833
		public GetSkyCraftEliInfoRes oRes = null;
	}
}
