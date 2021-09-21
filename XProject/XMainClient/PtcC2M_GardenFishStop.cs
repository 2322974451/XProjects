using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001390 RID: 5008
	internal class PtcC2M_GardenFishStop : Protocol
	{
		// Token: 0x0600E337 RID: 58167 RVA: 0x0033A0D8 File Offset: 0x003382D8
		public override uint GetProtoType()
		{
			return 56656U;
		}

		// Token: 0x0600E338 RID: 58168 RVA: 0x0033A0EF File Offset: 0x003382EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenFishStopArg>(stream, this.Data);
		}

		// Token: 0x0600E339 RID: 58169 RVA: 0x0033A0FF File Offset: 0x003382FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GardenFishStopArg>(stream);
		}

		// Token: 0x0600E33A RID: 58170 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040063E3 RID: 25571
		public GardenFishStopArg Data = new GardenFishStopArg();
	}
}
