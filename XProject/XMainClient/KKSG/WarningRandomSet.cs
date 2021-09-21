using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000488 RID: 1160
	[ProtoContract(Name = "WarningRandomSet")]
	[Serializable]
	public class WarningRandomSet : IExtensible
	{
		// Token: 0x17001299 RID: 4761
		// (get) Token: 0x06003CA6 RID: 15526 RVA: 0x00073D74 File Offset: 0x00071F74
		[ProtoMember(1, Name = "WarningItems", DataFormat = DataFormat.Default)]
		public List<WarningItemSet> WarningItems
		{
			get
			{
				return this._WarningItems;
			}
		}

		// Token: 0x1700129A RID: 4762
		// (get) Token: 0x06003CA7 RID: 15527 RVA: 0x00073D8C File Offset: 0x00071F8C
		// (set) Token: 0x06003CA8 RID: 15528 RVA: 0x00073DA4 File Offset: 0x00071FA4
		[ProtoMember(2, IsRequired = true, Name = "Firer", DataFormat = DataFormat.TwosComplement)]
		public ulong Firer
		{
			get
			{
				return this._Firer;
			}
			set
			{
				this._Firer = value;
			}
		}

		// Token: 0x1700129B RID: 4763
		// (get) Token: 0x06003CA9 RID: 15529 RVA: 0x00073DB0 File Offset: 0x00071FB0
		// (set) Token: 0x06003CAA RID: 15530 RVA: 0x00073DC8 File Offset: 0x00071FC8
		[ProtoMember(3, IsRequired = true, Name = "skill", DataFormat = DataFormat.TwosComplement)]
		public uint skill
		{
			get
			{
				return this._skill;
			}
			set
			{
				this._skill = value;
			}
		}

		// Token: 0x06003CAB RID: 15531 RVA: 0x00073DD4 File Offset: 0x00071FD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F17 RID: 3863
		private readonly List<WarningItemSet> _WarningItems = new List<WarningItemSet>();

		// Token: 0x04000F18 RID: 3864
		private ulong _Firer;

		// Token: 0x04000F19 RID: 3865
		private uint _skill;

		// Token: 0x04000F1A RID: 3866
		private IExtension extensionObject;
	}
}
