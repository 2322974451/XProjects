using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011DA RID: 4570
	internal class RpcC2M_ShowFlowerPageNew : Rpc
	{
		// Token: 0x0600DC31 RID: 56369 RVA: 0x0032FFF0 File Offset: 0x0032E1F0
		public override uint GetRpcType()
		{
			return 49446U;
		}

		// Token: 0x0600DC32 RID: 56370 RVA: 0x00330007 File Offset: 0x0032E207
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShowFlowerPageArg>(stream, this.oArg);
		}

		// Token: 0x0600DC33 RID: 56371 RVA: 0x00330017 File Offset: 0x0032E217
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ShowFlowerPageRes>(stream);
		}

		// Token: 0x0600DC34 RID: 56372 RVA: 0x00330026 File Offset: 0x0032E226
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ShowFlowerPageNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC35 RID: 56373 RVA: 0x00330042 File Offset: 0x0032E242
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ShowFlowerPageNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006287 RID: 25223
		public ShowFlowerPageArg oArg = new ShowFlowerPageArg();

		// Token: 0x04006288 RID: 25224
		public ShowFlowerPageRes oRes = null;
	}
}
