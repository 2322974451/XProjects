using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000FFE RID: 4094
	internal class RpcC2G_SyncTime : Rpc
	{
		// Token: 0x0600D49E RID: 54430 RVA: 0x003219DC File Offset: 0x0031FBDC
		public override uint GetRpcType()
		{
			return 30514U;
		}

		// Token: 0x0600D49F RID: 54431 RVA: 0x003219F3 File Offset: 0x0031FBF3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SyncTimeArg>(stream, this.oArg);
		}

		// Token: 0x0600D4A0 RID: 54432 RVA: 0x00321A03 File Offset: 0x0031FC03
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes.serverTime = 0L;
			this.oRes.serverTimeSpecified = false;
			Serializer.Merge<SyncTimeRes>(stream, this.oRes);
		}

		// Token: 0x0600D4A1 RID: 54433 RVA: 0x00321A2E File Offset: 0x0031FC2E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SyncTime.Ticks = this.replyTick;
			Process_RpcC2G_SyncTime.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D4A2 RID: 54434 RVA: 0x00321A55 File Offset: 0x0031FC55
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SyncTime.OnTimeout(this.oArg);
		}

		// Token: 0x040060F5 RID: 24821
		public SyncTimeArg oArg = new SyncTimeArg();

		// Token: 0x040060F6 RID: 24822
		public SyncTimeRes oRes = new SyncTimeRes();
	}
}
