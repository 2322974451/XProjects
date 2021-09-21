using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013B9 RID: 5049
	internal class RpcC2G_ResWarBuff : Rpc
	{
		// Token: 0x0600E3E1 RID: 58337 RVA: 0x0033AF40 File Offset: 0x00339140
		public override uint GetRpcType()
		{
			return 17670U;
		}

		// Token: 0x0600E3E2 RID: 58338 RVA: 0x0033AF57 File Offset: 0x00339157
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarBuffArg>(stream, this.oArg);
		}

		// Token: 0x0600E3E3 RID: 58339 RVA: 0x0033AF67 File Offset: 0x00339167
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarBuffRes>(stream);
		}

		// Token: 0x0600E3E4 RID: 58340 RVA: 0x0033AF76 File Offset: 0x00339176
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResWarBuff.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E3E5 RID: 58341 RVA: 0x0033AF92 File Offset: 0x00339192
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResWarBuff.OnTimeout(this.oArg);
		}

		// Token: 0x04006404 RID: 25604
		public ResWarBuffArg oArg = new ResWarBuffArg();

		// Token: 0x04006405 RID: 25605
		public ResWarBuffRes oRes = null;
	}
}
