using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012FB RID: 4859
	internal class RpcC2G_SkyCityAllInfoReq : Rpc
	{
		// Token: 0x0600E0D7 RID: 57559 RVA: 0x00336AC4 File Offset: 0x00334CC4
		public override uint GetRpcType()
		{
			return 29365U;
		}

		// Token: 0x0600E0D8 RID: 57560 RVA: 0x00336ADB File Offset: 0x00334CDB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityArg>(stream, this.oArg);
		}

		// Token: 0x0600E0D9 RID: 57561 RVA: 0x00336AEB File Offset: 0x00334CEB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkyCityRes>(stream);
		}

		// Token: 0x0600E0DA RID: 57562 RVA: 0x00336AFA File Offset: 0x00334CFA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SkyCityAllInfoReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E0DB RID: 57563 RVA: 0x00336B16 File Offset: 0x00334D16
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SkyCityAllInfoReq.OnTimeout(this.oArg);
		}

		// Token: 0x0400636E RID: 25454
		public SkyCityArg oArg = new SkyCityArg();

		// Token: 0x0400636F RID: 25455
		public SkyCityRes oRes = new SkyCityRes();
	}
}
