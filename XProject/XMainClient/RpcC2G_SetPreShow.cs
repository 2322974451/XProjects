using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001601 RID: 5633
	internal class RpcC2G_SetPreShow : Rpc
	{
		// Token: 0x0600ED34 RID: 60724 RVA: 0x003480AC File Offset: 0x003462AC
		public override uint GetRpcType()
		{
			return 346U;
		}

		// Token: 0x0600ED35 RID: 60725 RVA: 0x003480C3 File Offset: 0x003462C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetPreShowArg>(stream, this.oArg);
		}

		// Token: 0x0600ED36 RID: 60726 RVA: 0x003480D3 File Offset: 0x003462D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetPreShowRes>(stream);
		}

		// Token: 0x0600ED37 RID: 60727 RVA: 0x003480E2 File Offset: 0x003462E2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetPreShow.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED38 RID: 60728 RVA: 0x003480FE File Offset: 0x003462FE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetPreShow.OnTimeout(this.oArg);
		}

		// Token: 0x040065D1 RID: 26065
		public SetPreShowArg oArg = new SetPreShowArg();

		// Token: 0x040065D2 RID: 26066
		public SetPreShowRes oRes = null;
	}
}
