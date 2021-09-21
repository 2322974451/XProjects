using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000067 RID: 103
	[ProtoContract(Name = "AddTempAttrArg")]
	[Serializable]
	public class AddTempAttrArg : IExtensible
	{
		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x0000FE40 File Offset: 0x0000E040
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x0000FE6C File Offset: 0x0000E06C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x0000FE7C File Offset: 0x0000E07C
		// (set) Token: 0x060006EA RID: 1770 RVA: 0x0000FE9C File Offset: 0x0000E09C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0000FEE0 File Offset: 0x0000E0E0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0000FEF8 File Offset: 0x0000E0F8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0000FF04 File Offset: 0x0000E104
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001BE RID: 446
		private uint? _type;

		// Token: 0x040001BF RID: 447
		private IExtension extensionObject;
	}
}
