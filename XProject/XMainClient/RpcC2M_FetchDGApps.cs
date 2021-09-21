using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001628 RID: 5672
	internal class RpcC2M_FetchDGApps : Rpc
	{
		// Token: 0x0600EDDC RID: 60892 RVA: 0x00348EEC File Offset: 0x003470EC
		public override uint GetRpcType()
		{
			return 48732U;
		}

		// Token: 0x0600EDDD RID: 60893 RVA: 0x00348F03 File Offset: 0x00347103
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchDGAppArg>(stream, this.oArg);
		}

		// Token: 0x0600EDDE RID: 60894 RVA: 0x00348F13 File Offset: 0x00347113
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchDGAppRes>(stream);
		}

		// Token: 0x0600EDDF RID: 60895 RVA: 0x00348F22 File Offset: 0x00347122
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchDGApps.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EDE0 RID: 60896 RVA: 0x00348F3E File Offset: 0x0034713E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchDGApps.OnTimeout(this.oArg);
		}

		// Token: 0x040065F4 RID: 26100
		public FetchDGAppArg oArg = new FetchDGAppArg();

		// Token: 0x040065F5 RID: 26101
		public FetchDGAppRes oRes = null;
	}
}
