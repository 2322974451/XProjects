using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010E4 RID: 4324
	internal class RpcC2G_ExpFindBack : Rpc
	{
		// Token: 0x0600D847 RID: 55367 RVA: 0x00329530 File Offset: 0x00327730
		public override uint GetRpcType()
		{
			return 38008U;
		}

		// Token: 0x0600D848 RID: 55368 RVA: 0x00329547 File Offset: 0x00327747
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ExpFindBackArg>(stream, this.oArg);
		}

		// Token: 0x0600D849 RID: 55369 RVA: 0x00329557 File Offset: 0x00327757
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ExpFindBackRes>(stream);
		}

		// Token: 0x0600D84A RID: 55370 RVA: 0x00329566 File Offset: 0x00327766
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ExpFindBack.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D84B RID: 55371 RVA: 0x00329582 File Offset: 0x00327782
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ExpFindBack.OnTimeout(this.oArg);
		}

		// Token: 0x040061CB RID: 25035
		public ExpFindBackArg oArg = new ExpFindBackArg();

		// Token: 0x040061CC RID: 25036
		public ExpFindBackRes oRes = new ExpFindBackRes();
	}
}
