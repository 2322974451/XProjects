using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200123F RID: 4671
	internal class RpcC2G_ActivatAtlas : Rpc
	{
		// Token: 0x0600DDCB RID: 56779 RVA: 0x0033263C File Offset: 0x0033083C
		public override uint GetRpcType()
		{
			return 15919U;
		}

		// Token: 0x0600DDCC RID: 56780 RVA: 0x00332653 File Offset: 0x00330853
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivatAtlasArg>(stream, this.oArg);
		}

		// Token: 0x0600DDCD RID: 56781 RVA: 0x00332663 File Offset: 0x00330863
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivatAtlasRes>(stream);
		}

		// Token: 0x0600DDCE RID: 56782 RVA: 0x00332672 File Offset: 0x00330872
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivatAtlas.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDCF RID: 56783 RVA: 0x0033268E File Offset: 0x0033088E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivatAtlas.OnTimeout(this.oArg);
		}

		// Token: 0x040062D5 RID: 25301
		public ActivatAtlasArg oArg = new ActivatAtlasArg();

		// Token: 0x040062D6 RID: 25302
		public ActivatAtlasRes oRes = new ActivatAtlasRes();
	}
}
