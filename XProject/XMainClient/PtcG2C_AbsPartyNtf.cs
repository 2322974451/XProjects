using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001500 RID: 5376
	internal class PtcG2C_AbsPartyNtf : Protocol
	{
		// Token: 0x0600E916 RID: 59670 RVA: 0x003422F0 File Offset: 0x003404F0
		public override uint GetProtoType()
		{
			return 35041U;
		}

		// Token: 0x0600E917 RID: 59671 RVA: 0x00342307 File Offset: 0x00340507
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AbsPartyInfo>(stream, this.Data);
		}

		// Token: 0x0600E918 RID: 59672 RVA: 0x00342317 File Offset: 0x00340517
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AbsPartyInfo>(stream);
		}

		// Token: 0x0600E919 RID: 59673 RVA: 0x00342326 File Offset: 0x00340526
		public override void Process()
		{
			Process_PtcG2C_AbsPartyNtf.Process(this);
		}

		// Token: 0x04006500 RID: 25856
		public AbsPartyInfo Data = new AbsPartyInfo();
	}
}
