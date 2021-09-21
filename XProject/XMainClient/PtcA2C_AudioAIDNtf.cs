using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014B5 RID: 5301
	internal class PtcA2C_AudioAIDNtf : Protocol
	{
		// Token: 0x0600E7DF RID: 59359 RVA: 0x003409FC File Offset: 0x0033EBFC
		public override uint GetProtoType()
		{
			return 54517U;
		}

		// Token: 0x0600E7E0 RID: 59360 RVA: 0x00340A13 File Offset: 0x0033EC13
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AudioTextArg>(stream, this.Data);
		}

		// Token: 0x0600E7E1 RID: 59361 RVA: 0x00340A23 File Offset: 0x0033EC23
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AudioTextArg>(stream);
		}

		// Token: 0x0600E7E2 RID: 59362 RVA: 0x00340A32 File Offset: 0x0033EC32
		public override void Process()
		{
			Process_PtcA2C_AudioAIDNtf.Process(this);
		}

		// Token: 0x040064C3 RID: 25795
		public AudioTextArg Data = new AudioTextArg();
	}
}
