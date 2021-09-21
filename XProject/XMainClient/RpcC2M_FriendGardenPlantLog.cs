using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012E2 RID: 4834
	internal class RpcC2M_FriendGardenPlantLog : Rpc
	{
		// Token: 0x0600E06F RID: 57455 RVA: 0x003360D0 File Offset: 0x003342D0
		public override uint GetRpcType()
		{
			return 33646U;
		}

		// Token: 0x0600E070 RID: 57456 RVA: 0x003360E7 File Offset: 0x003342E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendGardenPlantLogArg>(stream, this.oArg);
		}

		// Token: 0x0600E071 RID: 57457 RVA: 0x003360F7 File Offset: 0x003342F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FriendGardenPlantLogRes>(stream);
		}

		// Token: 0x0600E072 RID: 57458 RVA: 0x00336106 File Offset: 0x00334306
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FriendGardenPlantLog.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E073 RID: 57459 RVA: 0x00336122 File Offset: 0x00334322
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FriendGardenPlantLog.OnTimeout(this.oArg);
		}

		// Token: 0x0400635A RID: 25434
		public FriendGardenPlantLogArg oArg = new FriendGardenPlantLogArg();

		// Token: 0x0400635B RID: 25435
		public FriendGardenPlantLogRes oRes = null;
	}
}
