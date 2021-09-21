using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000EC6 RID: 3782
	internal class RpcC2T_Reconnect : Rpc
	{
		// Token: 0x0600C8B6 RID: 51382 RVA: 0x002CEFA8 File Offset: 0x002CD1A8
		public override uint GetRpcType()
		{
			return 28358U;
		}

		// Token: 0x0600C8B7 RID: 51383 RVA: 0x002CEFBF File Offset: 0x002CD1BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReconnArg>(stream, this.oArg);
		}

		// Token: 0x0600C8B8 RID: 51384 RVA: 0x002CEFCF File Offset: 0x002CD1CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReconnRes>(stream);
		}

		// Token: 0x0600C8B9 RID: 51385 RVA: 0x002CEFDE File Offset: 0x002CD1DE
		public override void Process()
		{
			base.Process();
			Process_RpcC2T_Reconnect.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600C8BA RID: 51386 RVA: 0x002CEFFA File Offset: 0x002CD1FA
		public override void OnTimeout(object args)
		{
			Process_RpcC2T_Reconnect.OnTimeout(this.oArg);
		}

		// Token: 0x040058C3 RID: 22723
		public ReconnArg oArg = new ReconnArg();

		// Token: 0x040058C4 RID: 22724
		public ReconnRes oRes = new ReconnRes();
	}
}
