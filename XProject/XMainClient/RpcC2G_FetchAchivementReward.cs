using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001019 RID: 4121
	internal class RpcC2G_FetchAchivementReward : Rpc
	{
		// Token: 0x0600D508 RID: 54536 RVA: 0x00322DD0 File Offset: 0x00320FD0
		public override uint GetRpcType()
		{
			return 47094U;
		}

		// Token: 0x0600D509 RID: 54537 RVA: 0x00322DE7 File Offset: 0x00320FE7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchAchiveArg>(stream, this.oArg);
		}

		// Token: 0x0600D50A RID: 54538 RVA: 0x00322DF7 File Offset: 0x00320FF7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchAchiveRes>(stream);
		}

		// Token: 0x0600D50B RID: 54539 RVA: 0x00322E06 File Offset: 0x00321006
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FetchAchivementReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D50C RID: 54540 RVA: 0x00322E22 File Offset: 0x00321022
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FetchAchivementReward.OnTimeout(this.oArg);
		}

		// Token: 0x0400610C RID: 24844
		public FetchAchiveArg oArg = new FetchAchiveArg();

		// Token: 0x0400610D RID: 24845
		public FetchAchiveRes oRes = new FetchAchiveRes();
	}
}
