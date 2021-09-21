using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001652 RID: 5714
	internal class RpcC2G_PeerBox : Rpc
	{
		// Token: 0x0600EE93 RID: 61075 RVA: 0x00349F70 File Offset: 0x00348170
		public override uint GetRpcType()
		{
			return 21959U;
		}

		// Token: 0x0600EE94 RID: 61076 RVA: 0x00349F87 File Offset: 0x00348187
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PeerBoxArg>(stream, this.oArg);
		}

		// Token: 0x0600EE95 RID: 61077 RVA: 0x00349F97 File Offset: 0x00348197
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PeerBoxRes>(stream);
		}

		// Token: 0x0600EE96 RID: 61078 RVA: 0x00349FA6 File Offset: 0x003481A6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PeerBox.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE97 RID: 61079 RVA: 0x00349FC2 File Offset: 0x003481C2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PeerBox.OnTimeout(this.oArg);
		}

		// Token: 0x0400661B RID: 26139
		public PeerBoxArg oArg = new PeerBoxArg();

		// Token: 0x0400661C RID: 26140
		public PeerBoxRes oRes = null;
	}
}
