using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004EC RID: 1260
	[ProtoContract(Name = "SetPreShowArg")]
	[Serializable]
	public class SetPreShowArg : IExtensible
	{
		// Token: 0x170013E8 RID: 5096
		// (get) Token: 0x06004114 RID: 16660 RVA: 0x0007BEAC File Offset: 0x0007A0AC
		[ProtoMember(1, Name = "showid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> showid
		{
			get
			{
				return this._showid;
			}
		}

		// Token: 0x06004115 RID: 16661 RVA: 0x0007BEC4 File Offset: 0x0007A0C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001036 RID: 4150
		private readonly List<uint> _showid = new List<uint>();

		// Token: 0x04001037 RID: 4151
		private IExtension extensionObject;
	}
}
