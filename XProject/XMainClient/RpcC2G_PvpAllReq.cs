using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001118 RID: 4376
	internal class RpcC2G_PvpAllReq : Rpc
	{
		// Token: 0x0600D924 RID: 55588 RVA: 0x0032A8DC File Offset: 0x00328ADC
		public override uint GetRpcType()
		{
			return 57262U;
		}

		// Token: 0x0600D925 RID: 55589 RVA: 0x0032A8F3 File Offset: 0x00328AF3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PvpArg>(stream, this.oArg);
		}

		// Token: 0x0600D926 RID: 55590 RVA: 0x0032A903 File Offset: 0x00328B03
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PvpRes>(stream);
		}

		// Token: 0x0600D927 RID: 55591 RVA: 0x0032A912 File Offset: 0x00328B12
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PvpAllReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D928 RID: 55592 RVA: 0x0032A92E File Offset: 0x00328B2E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PvpAllReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061F7 RID: 25079
		public PvpArg oArg = new PvpArg();

		// Token: 0x040061F8 RID: 25080
		public PvpRes oRes = new PvpRes();
	}
}
