using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015CC RID: 5580
	internal class RpcC2M_StartWeddingCar : Rpc
	{
		// Token: 0x0600EC5A RID: 60506 RVA: 0x00346F5C File Offset: 0x0034515C
		public override uint GetRpcType()
		{
			return 26388U;
		}

		// Token: 0x0600EC5B RID: 60507 RVA: 0x00346F73 File Offset: 0x00345173
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartWeddingCarArg>(stream, this.oArg);
		}

		// Token: 0x0600EC5C RID: 60508 RVA: 0x00346F83 File Offset: 0x00345183
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StartWeddingCarRes>(stream);
		}

		// Token: 0x0600EC5D RID: 60509 RVA: 0x00346F92 File Offset: 0x00345192
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StartWeddingCar.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC5E RID: 60510 RVA: 0x00346FAE File Offset: 0x003451AE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StartWeddingCar.OnTimeout(this.oArg);
		}

		// Token: 0x040065A7 RID: 26023
		public StartWeddingCarArg oArg = new StartWeddingCarArg();

		// Token: 0x040065A8 RID: 26024
		public StartWeddingCarRes oRes = null;
	}
}
