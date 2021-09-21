using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200133D RID: 4925
	internal class RpcC2M_GardenExpelSprite : Rpc
	{
		// Token: 0x0600E1E5 RID: 57829 RVA: 0x0033848C File Offset: 0x0033668C
		public override uint GetRpcType()
		{
			return 3250U;
		}

		// Token: 0x0600E1E6 RID: 57830 RVA: 0x003384A3 File Offset: 0x003366A3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenExpelSpriteArg>(stream, this.oArg);
		}

		// Token: 0x0600E1E7 RID: 57831 RVA: 0x003384B3 File Offset: 0x003366B3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenExpelSpriteRes>(stream);
		}

		// Token: 0x0600E1E8 RID: 57832 RVA: 0x003384C2 File Offset: 0x003366C2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenExpelSprite.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1E9 RID: 57833 RVA: 0x003384DE File Offset: 0x003366DE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenExpelSprite.OnTimeout(this.oArg);
		}

		// Token: 0x040063A2 RID: 25506
		public GardenExpelSpriteArg oArg = new GardenExpelSpriteArg();

		// Token: 0x040063A3 RID: 25507
		public GardenExpelSpriteRes oRes = null;
	}
}
