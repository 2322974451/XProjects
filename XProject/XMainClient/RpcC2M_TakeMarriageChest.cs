using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015C5 RID: 5573
	internal class RpcC2M_TakeMarriageChest : Rpc
	{
		// Token: 0x0600EC3A RID: 60474 RVA: 0x00346C78 File Offset: 0x00344E78
		public override uint GetRpcType()
		{
			return 38713U;
		}

		// Token: 0x0600EC3B RID: 60475 RVA: 0x00346C8F File Offset: 0x00344E8F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakeMarriageChestArg>(stream, this.oArg);
		}

		// Token: 0x0600EC3C RID: 60476 RVA: 0x00346C9F File Offset: 0x00344E9F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakeMarriageChestRes>(stream);
		}

		// Token: 0x0600EC3D RID: 60477 RVA: 0x00346CAE File Offset: 0x00344EAE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TakeMarriageChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC3E RID: 60478 RVA: 0x00346CCA File Offset: 0x00344ECA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TakeMarriageChest.OnTimeout(this.oArg);
		}

		// Token: 0x040065A0 RID: 26016
		public TakeMarriageChestArg oArg = new TakeMarriageChestArg();

		// Token: 0x040065A1 RID: 26017
		public TakeMarriageChestRes oRes = null;
	}
}
