using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000493 RID: 1171
	[ProtoContract(Name = "TakeMarriageChestArg")]
	[Serializable]
	public class TakeMarriageChestArg : IExtensible
	{
		// Token: 0x170012B3 RID: 4787
		// (get) Token: 0x06003D00 RID: 15616 RVA: 0x00074738 File Offset: 0x00072938
		// (set) Token: 0x06003D01 RID: 15617 RVA: 0x00074764 File Offset: 0x00072964
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x170012B4 RID: 4788
		// (get) Token: 0x06003D02 RID: 15618 RVA: 0x00074774 File Offset: 0x00072974
		// (set) Token: 0x06003D03 RID: 15619 RVA: 0x00074794 File Offset: 0x00072994
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06003D04 RID: 15620 RVA: 0x000747D8 File Offset: 0x000729D8
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06003D05 RID: 15621 RVA: 0x000747F0 File Offset: 0x000729F0
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06003D06 RID: 15622 RVA: 0x000747FC File Offset: 0x000729FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F32 RID: 3890
		private uint? _index;

		// Token: 0x04000F33 RID: 3891
		private IExtension extensionObject;
	}
}
