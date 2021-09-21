using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200158C RID: 5516
	internal class PtcG2C_HeroBattleAncientPower : Protocol
	{
		// Token: 0x0600EB51 RID: 60241 RVA: 0x00345900 File Offset: 0x00343B00
		public override uint GetProtoType()
		{
			return 37102U;
		}

		// Token: 0x0600EB52 RID: 60242 RVA: 0x00345917 File Offset: 0x00343B17
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleAncientPowerData>(stream, this.Data);
		}

		// Token: 0x0600EB53 RID: 60243 RVA: 0x00345927 File Offset: 0x00343B27
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleAncientPowerData>(stream);
		}

		// Token: 0x0600EB54 RID: 60244 RVA: 0x00345936 File Offset: 0x00343B36
		public override void Process()
		{
			Process_PtcG2C_HeroBattleAncientPower.Process(this);
		}

		// Token: 0x04006575 RID: 25973
		public HeroBattleAncientPowerData Data = new HeroBattleAncientPowerData();
	}
}
