using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012C4 RID: 4804
	internal class RpcC2M_AdjustGuildArenaRolePosNew : Rpc
	{
		// Token: 0x0600DFF4 RID: 57332 RVA: 0x003355E0 File Offset: 0x003337E0
		public override uint GetRpcType()
		{
			return 57124U;
		}

		// Token: 0x0600DFF5 RID: 57333 RVA: 0x003355F7 File Offset: 0x003337F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AdjustGuildArenaRolePosArg>(stream, this.oArg);
		}

		// Token: 0x0600DFF6 RID: 57334 RVA: 0x00335607 File Offset: 0x00333807
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AdjustGuildArenaRolePosRes>(stream);
		}

		// Token: 0x0600DFF7 RID: 57335 RVA: 0x00335616 File Offset: 0x00333816
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AdjustGuildArenaRolePosNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DFF8 RID: 57336 RVA: 0x00335632 File Offset: 0x00333832
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AdjustGuildArenaRolePosNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006342 RID: 25410
		public AdjustGuildArenaRolePosArg oArg = new AdjustGuildArenaRolePosArg();

		// Token: 0x04006343 RID: 25411
		public AdjustGuildArenaRolePosRes oRes = null;
	}
}
