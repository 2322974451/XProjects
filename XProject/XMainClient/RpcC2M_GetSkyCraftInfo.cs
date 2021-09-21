using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014E1 RID: 5345
	internal class RpcC2M_GetSkyCraftInfo : Rpc
	{
		// Token: 0x0600E890 RID: 59536 RVA: 0x00341758 File Offset: 0x0033F958
		public override uint GetRpcType()
		{
			return 26199U;
		}

		// Token: 0x0600E891 RID: 59537 RVA: 0x0034176F File Offset: 0x0033F96F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E892 RID: 59538 RVA: 0x0034177F File Offset: 0x0033F97F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftInfoRes>(stream);
		}

		// Token: 0x0600E893 RID: 59539 RVA: 0x0034178E File Offset: 0x0033F98E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E894 RID: 59540 RVA: 0x003417AA File Offset: 0x0033F9AA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040064E4 RID: 25828
		public GetSkyCraftInfoArg oArg = new GetSkyCraftInfoArg();

		// Token: 0x040064E5 RID: 25829
		public GetSkyCraftInfoRes oRes = null;
	}
}
