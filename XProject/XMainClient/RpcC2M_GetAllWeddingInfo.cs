using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001598 RID: 5528
	internal class RpcC2M_GetAllWeddingInfo : Rpc
	{
		// Token: 0x0600EB85 RID: 60293 RVA: 0x00345E60 File Offset: 0x00344060
		public override uint GetRpcType()
		{
			return 30155U;
		}

		// Token: 0x0600EB86 RID: 60294 RVA: 0x00345E77 File Offset: 0x00344077
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAllWeddingInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600EB87 RID: 60295 RVA: 0x00345E87 File Offset: 0x00344087
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAllWeddingInfoRes>(stream);
		}

		// Token: 0x0600EB88 RID: 60296 RVA: 0x00345E96 File Offset: 0x00344096
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetAllWeddingInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB89 RID: 60297 RVA: 0x00345EB2 File Offset: 0x003440B2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetAllWeddingInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006580 RID: 25984
		public GetAllWeddingInfoArg oArg = new GetAllWeddingInfoArg();

		// Token: 0x04006581 RID: 25985
		public GetAllWeddingInfoRes oRes = null;
	}
}
