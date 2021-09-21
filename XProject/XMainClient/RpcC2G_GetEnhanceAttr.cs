using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200156C RID: 5484
	internal class RpcC2G_GetEnhanceAttr : Rpc
	{
		// Token: 0x0600EAC9 RID: 60105 RVA: 0x00344D70 File Offset: 0x00342F70
		public override uint GetRpcType()
		{
			return 23396U;
		}

		// Token: 0x0600EACA RID: 60106 RVA: 0x00344D87 File Offset: 0x00342F87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetEnhanceAttrArg>(stream, this.oArg);
		}

		// Token: 0x0600EACB RID: 60107 RVA: 0x00344D97 File Offset: 0x00342F97
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetEnhanceAttrRes>(stream);
		}

		// Token: 0x0600EACC RID: 60108 RVA: 0x00344DA6 File Offset: 0x00342FA6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetEnhanceAttr.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EACD RID: 60109 RVA: 0x00344DC2 File Offset: 0x00342FC2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetEnhanceAttr.OnTimeout(this.oArg);
		}

		// Token: 0x04006559 RID: 25945
		public GetEnhanceAttrArg oArg = new GetEnhanceAttrArg();

		// Token: 0x0400655A RID: 25946
		public GetEnhanceAttrRes oRes = null;
	}
}
