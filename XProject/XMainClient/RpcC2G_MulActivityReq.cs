using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001156 RID: 4438
	internal class RpcC2G_MulActivityReq : Rpc
	{
		// Token: 0x0600DA22 RID: 55842 RVA: 0x0032CB74 File Offset: 0x0032AD74
		public override uint GetRpcType()
		{
			return 22806U;
		}

		// Token: 0x0600DA23 RID: 55843 RVA: 0x0032CB8B File Offset: 0x0032AD8B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MulActivityArg>(stream, this.oArg);
		}

		// Token: 0x0600DA24 RID: 55844 RVA: 0x0032CB9B File Offset: 0x0032AD9B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MulActivityRes>(stream);
		}

		// Token: 0x0600DA25 RID: 55845 RVA: 0x0032CBAA File Offset: 0x0032ADAA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_MulActivityReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA26 RID: 55846 RVA: 0x0032CBC6 File Offset: 0x0032ADC6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_MulActivityReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006227 RID: 25127
		public MulActivityArg oArg = new MulActivityArg();

		// Token: 0x04006228 RID: 25128
		public MulActivityRes oRes = new MulActivityRes();
	}
}
