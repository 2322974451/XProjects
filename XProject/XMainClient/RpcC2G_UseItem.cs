using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000EC3 RID: 3779
	internal class RpcC2G_UseItem : Rpc
	{
		// Token: 0x0600C8A4 RID: 51364 RVA: 0x002CEE20 File Offset: 0x002CD020
		public override uint GetRpcType()
		{
			return 64132U;
		}

		// Token: 0x0600C8A5 RID: 51365 RVA: 0x002CEE37 File Offset: 0x002CD037
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UseItemArg>(stream, this.oArg);
		}

		// Token: 0x0600C8A6 RID: 51366 RVA: 0x002CEE47 File Offset: 0x002CD047
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UseItemRes>(stream);
		}

		// Token: 0x0600C8A7 RID: 51367 RVA: 0x002CEE56 File Offset: 0x002CD056
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_UseItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600C8A8 RID: 51368 RVA: 0x002CEE72 File Offset: 0x002CD072
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_UseItem.OnTimeout(this.oArg);
		}

		// Token: 0x040058BD RID: 22717
		public UseItemArg oArg = new UseItemArg();

		// Token: 0x040058BE RID: 22718
		public UseItemRes oRes = new UseItemRes();
	}
}
