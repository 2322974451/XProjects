using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001646 RID: 5702
	internal class RpcC2M_GetDragonGuildBindInfo : Rpc
	{
		// Token: 0x0600EE5F RID: 61023 RVA: 0x00349AA0 File Offset: 0x00347CA0
		public override uint GetRpcType()
		{
			return 39788U;
		}

		// Token: 0x0600EE60 RID: 61024 RVA: 0x00349AB7 File Offset: 0x00347CB7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildBindInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600EE61 RID: 61025 RVA: 0x00349AC7 File Offset: 0x00347CC7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildBindInfoRes>(stream);
		}

		// Token: 0x0600EE62 RID: 61026 RVA: 0x00349AD6 File Offset: 0x00347CD6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildBindInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE63 RID: 61027 RVA: 0x00349AF2 File Offset: 0x00347CF2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildBindInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006610 RID: 26128
		public GetDragonGuildBindInfoArg oArg = new GetDragonGuildBindInfoArg();

		// Token: 0x04006611 RID: 26129
		public GetDragonGuildBindInfoRes oRes = null;
	}
}
