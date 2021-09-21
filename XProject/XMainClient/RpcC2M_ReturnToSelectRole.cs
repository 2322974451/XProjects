using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001164 RID: 4452
	internal class RpcC2M_ReturnToSelectRole : Rpc
	{
		// Token: 0x0600DA61 RID: 55905 RVA: 0x0032D3AC File Offset: 0x0032B5AC
		public override uint GetRpcType()
		{
			return 25477U;
		}

		// Token: 0x0600DA62 RID: 55906 RVA: 0x0032D3C3 File Offset: 0x0032B5C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReturnToSelectRoleArg>(stream, this.oArg);
		}

		// Token: 0x0600DA63 RID: 55907 RVA: 0x0032D3D3 File Offset: 0x0032B5D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReturnToSelectRoleRes>(stream);
		}

		// Token: 0x0600DA64 RID: 55908 RVA: 0x0032D3E2 File Offset: 0x0032B5E2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReturnToSelectRole.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA65 RID: 55909 RVA: 0x0032D3FE File Offset: 0x0032B5FE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReturnToSelectRole.OnTimeout(this.oArg);
		}

		// Token: 0x04006235 RID: 25141
		public ReturnToSelectRoleArg oArg = new ReturnToSelectRoleArg();

		// Token: 0x04006236 RID: 25142
		public ReturnToSelectRoleRes oRes = null;
	}
}
