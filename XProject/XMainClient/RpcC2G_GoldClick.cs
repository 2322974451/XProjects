using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B4E RID: 2894
	internal class RpcC2G_GoldClick : Rpc
	{
		// Token: 0x0600A8B3 RID: 43187 RVA: 0x001E0EFC File Offset: 0x001DF0FC
		public override uint GetRpcType()
		{
			return 12917U;
		}

		// Token: 0x0600A8B4 RID: 43188 RVA: 0x001E0F13 File Offset: 0x001DF113
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoldClickArg>(stream, this.oArg);
		}

		// Token: 0x0600A8B5 RID: 43189 RVA: 0x001E0F23 File Offset: 0x001DF123
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GoldClickRes>(stream);
		}

		// Token: 0x0600A8B6 RID: 43190 RVA: 0x001E0F32 File Offset: 0x001DF132
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GoldClick.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8B7 RID: 43191 RVA: 0x001E0F4E File Offset: 0x001DF14E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GoldClick.OnTimeout(this.oArg);
		}

		// Token: 0x04003E80 RID: 16000
		public GoldClickArg oArg = new GoldClickArg();

		// Token: 0x04003E81 RID: 16001
		public GoldClickRes oRes = null;
	}
}
