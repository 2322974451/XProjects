using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200140A RID: 5130
	internal class PtcG2C_InvFightBefEnterSceneNtf : Protocol
	{
		// Token: 0x0600E52F RID: 58671 RVA: 0x0033C9EC File Offset: 0x0033ABEC
		public override uint GetProtoType()
		{
			return 7135U;
		}

		// Token: 0x0600E530 RID: 58672 RVA: 0x0033CA03 File Offset: 0x0033AC03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightBefESpara>(stream, this.Data);
		}

		// Token: 0x0600E531 RID: 58673 RVA: 0x0033CA13 File Offset: 0x0033AC13
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvFightBefESpara>(stream);
		}

		// Token: 0x0600E532 RID: 58674 RVA: 0x0033CA22 File Offset: 0x0033AC22
		public override void Process()
		{
			Process_PtcG2C_InvFightBefEnterSceneNtf.Process(this);
		}

		// Token: 0x04006445 RID: 25669
		public InvFightBefESpara Data = new InvFightBefESpara();
	}
}
