using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014DD RID: 5341
	internal class RpcC2M_CustomBattleOp : Rpc
	{
		// Token: 0x0600E880 RID: 59520 RVA: 0x003415D4 File Offset: 0x0033F7D4
		public override uint GetRpcType()
		{
			return 12314U;
		}

		// Token: 0x0600E881 RID: 59521 RVA: 0x003415EB File Offset: 0x0033F7EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CustomBattleOpArg>(stream, this.oArg);
		}

		// Token: 0x0600E882 RID: 59522 RVA: 0x003415FB File Offset: 0x0033F7FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CustomBattleOpRes>(stream);
		}

		// Token: 0x0600E883 RID: 59523 RVA: 0x0034160A File Offset: 0x0033F80A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CustomBattleOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E884 RID: 59524 RVA: 0x00341626 File Offset: 0x0033F826
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CustomBattleOp.OnTimeout(this.oArg);
		}

		// Token: 0x040064E1 RID: 25825
		public CustomBattleOpArg oArg = new CustomBattleOpArg();

		// Token: 0x040064E2 RID: 25826
		public CustomBattleOpRes oRes = null;
	}
}
