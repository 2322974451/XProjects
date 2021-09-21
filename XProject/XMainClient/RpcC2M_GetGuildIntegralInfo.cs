using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200136C RID: 4972
	internal class RpcC2M_GetGuildIntegralInfo : Rpc
	{
		// Token: 0x0600E2A6 RID: 58022 RVA: 0x003395C4 File Offset: 0x003377C4
		public override uint GetRpcType()
		{
			return 56762U;
		}

		// Token: 0x0600E2A7 RID: 58023 RVA: 0x003395DB File Offset: 0x003377DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildIntegralInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E2A8 RID: 58024 RVA: 0x003395EB File Offset: 0x003377EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildIntegralInfoRes>(stream);
		}

		// Token: 0x0600E2A9 RID: 58025 RVA: 0x003395FA File Offset: 0x003377FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildIntegralInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E2AA RID: 58026 RVA: 0x00339616 File Offset: 0x00337816
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildIntegralInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040063C8 RID: 25544
		public GetGuildIntegralInfoArg oArg = new GetGuildIntegralInfoArg();

		// Token: 0x040063C9 RID: 25545
		public GetGuildIntegralInfoRes oRes = null;
	}
}
