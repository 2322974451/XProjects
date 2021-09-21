using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200167C RID: 5756
	internal class RpcC2G_RiftFirstPassReward : Rpc
	{
		// Token: 0x0600EF3F RID: 61247 RVA: 0x0034AFD8 File Offset: 0x003491D8
		public override uint GetRpcType()
		{
			return 63150U;
		}

		// Token: 0x0600EF40 RID: 61248 RVA: 0x0034AFEF File Offset: 0x003491EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiftFirstPassRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600EF41 RID: 61249 RVA: 0x0034AFFF File Offset: 0x003491FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RiftFirstPassRewardRes>(stream);
		}

		// Token: 0x0600EF42 RID: 61250 RVA: 0x0034B00E File Offset: 0x0034920E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RiftFirstPassReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF43 RID: 61251 RVA: 0x0034B02A File Offset: 0x0034922A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RiftFirstPassReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006643 RID: 26179
		public RiftFirstPassRewardArg oArg = new RiftFirstPassRewardArg();

		// Token: 0x04006644 RID: 26180
		public RiftFirstPassRewardRes oRes = null;
	}
}
