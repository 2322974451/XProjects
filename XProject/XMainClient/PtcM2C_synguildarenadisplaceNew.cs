using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001277 RID: 4727
	internal class PtcM2C_synguildarenadisplaceNew : Protocol
	{
		// Token: 0x0600DEB4 RID: 57012 RVA: 0x00333930 File Offset: 0x00331B30
		public override uint GetProtoType()
		{
			return 56166U;
		}

		// Token: 0x0600DEB5 RID: 57013 RVA: 0x00333947 File Offset: 0x00331B47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<guildarenadisplace>(stream, this.Data);
		}

		// Token: 0x0600DEB6 RID: 57014 RVA: 0x00333957 File Offset: 0x00331B57
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<guildarenadisplace>(stream);
		}

		// Token: 0x0600DEB7 RID: 57015 RVA: 0x00333966 File Offset: 0x00331B66
		public override void Process()
		{
			Process_PtcM2C_synguildarenadisplaceNew.Process(this);
		}

		// Token: 0x04006303 RID: 25347
		public guildarenadisplace Data = new guildarenadisplace();
	}
}
