using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200000E RID: 14
	[ProtoContract(Name = "UnitAppearList")]
	[Serializable]
	public class UnitAppearList : IExtensible
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00005010 File Offset: 0x00003210
		[ProtoMember(1, Name = "units", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> units
		{
			get
			{
				return this._units;
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005028 File Offset: 0x00003228
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000054 RID: 84
		private readonly List<UnitAppearance> _units = new List<UnitAppearance>();

		// Token: 0x04000055 RID: 85
		private IExtension extensionObject;
	}
}
