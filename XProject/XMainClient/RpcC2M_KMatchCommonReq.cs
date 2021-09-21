using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001518 RID: 5400
	internal class RpcC2M_KMatchCommonReq : Rpc
	{
		// Token: 0x0600E978 RID: 59768 RVA: 0x00342C20 File Offset: 0x00340E20
		public override uint GetRpcType()
		{
			return 57822U;
		}

		// Token: 0x0600E979 RID: 59769 RVA: 0x00342C37 File Offset: 0x00340E37
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<KMatchCommonArg>(stream, this.oArg);
		}

		// Token: 0x0600E97A RID: 59770 RVA: 0x00342C47 File Offset: 0x00340E47
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<KMatchCommonRes>(stream);
		}

		// Token: 0x0600E97B RID: 59771 RVA: 0x00342C56 File Offset: 0x00340E56
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_KMatchCommonReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E97C RID: 59772 RVA: 0x00342C72 File Offset: 0x00340E72
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_KMatchCommonReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006513 RID: 25875
		public KMatchCommonArg oArg = new KMatchCommonArg();

		// Token: 0x04006514 RID: 25876
		public KMatchCommonRes oRes = null;
	}
}
