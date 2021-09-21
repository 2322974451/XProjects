using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001541 RID: 5441
	internal class RpcC2G_MobaSignaling : Rpc
	{
		// Token: 0x0600EA19 RID: 59929 RVA: 0x00343B8C File Offset: 0x00341D8C
		public override uint GetRpcType()
		{
			return 52475U;
		}

		// Token: 0x0600EA1A RID: 59930 RVA: 0x00343BA3 File Offset: 0x00341DA3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaSignalingArg>(stream, this.oArg);
		}

		// Token: 0x0600EA1B RID: 59931 RVA: 0x00343BB3 File Offset: 0x00341DB3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MobaSignalingRes>(stream);
		}

		// Token: 0x0600EA1C RID: 59932 RVA: 0x00343BC2 File Offset: 0x00341DC2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_MobaSignaling.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA1D RID: 59933 RVA: 0x00343BDE File Offset: 0x00341DDE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_MobaSignaling.OnTimeout(this.oArg);
		}

		// Token: 0x04006530 RID: 25904
		public MobaSignalingArg oArg = new MobaSignalingArg();

		// Token: 0x04006531 RID: 25905
		public MobaSignalingRes oRes = null;
	}
}
