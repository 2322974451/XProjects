using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012E0 RID: 4832
	internal class RpcC2M_TryFish : Rpc
	{
		// Token: 0x0600E066 RID: 57446 RVA: 0x00335F94 File Offset: 0x00334194
		public override uint GetRpcType()
		{
			return 7028U;
		}

		// Token: 0x0600E067 RID: 57447 RVA: 0x00335FAB File Offset: 0x003341AB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TryFishArg>(stream, this.oArg);
		}

		// Token: 0x0600E068 RID: 57448 RVA: 0x00335FBB File Offset: 0x003341BB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TryFishRes>(stream);
		}

		// Token: 0x0600E069 RID: 57449 RVA: 0x00335FCA File Offset: 0x003341CA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TryFish.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E06A RID: 57450 RVA: 0x00335FE6 File Offset: 0x003341E6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TryFish.OnTimeout(this.oArg);
		}

		// Token: 0x04006358 RID: 25432
		public TryFishArg oArg = new TryFishArg();

		// Token: 0x04006359 RID: 25433
		public TryFishRes oRes = null;
	}
}
