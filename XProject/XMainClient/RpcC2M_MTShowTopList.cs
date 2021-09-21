using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200128F RID: 4751
	internal class RpcC2M_MTShowTopList : Rpc
	{
		// Token: 0x0600DF19 RID: 57113 RVA: 0x003340C0 File Offset: 0x003322C0
		public override uint GetRpcType()
		{
			return 10166U;
		}

		// Token: 0x0600DF1A RID: 57114 RVA: 0x003340D7 File Offset: 0x003322D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TShowTopListArg>(stream, this.oArg);
		}

		// Token: 0x0600DF1B RID: 57115 RVA: 0x003340E7 File Offset: 0x003322E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TShowTopListRes>(stream);
		}

		// Token: 0x0600DF1C RID: 57116 RVA: 0x003340F6 File Offset: 0x003322F6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MTShowTopList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF1D RID: 57117 RVA: 0x00334112 File Offset: 0x00332312
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MTShowTopList.OnTimeout(this.oArg);
		}

		// Token: 0x04006317 RID: 25367
		public TShowTopListArg oArg = new TShowTopListArg();

		// Token: 0x04006318 RID: 25368
		public TShowTopListRes oRes = null;
	}
}
