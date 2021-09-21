using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000447 RID: 1095
	[ProtoContract(Name = "BuySpriteEggArg")]
	[Serializable]
	public class BuySpriteEggArg : IExtensible
	{
		// Token: 0x170011B5 RID: 4533
		// (get) Token: 0x060039B7 RID: 14775 RVA: 0x0006E660 File Offset: 0x0006C860
		// (set) Token: 0x060039B8 RID: 14776 RVA: 0x0006E68C File Offset: 0x0006C88C
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

		// Token: 0x170011B6 RID: 4534
		// (get) Token: 0x060039B9 RID: 14777 RVA: 0x0006E69C File Offset: 0x0006C89C
		// (set) Token: 0x060039BA RID: 14778 RVA: 0x0006E6BC File Offset: 0x0006C8BC
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

		// Token: 0x060039BB RID: 14779 RVA: 0x0006E700 File Offset: 0x0006C900
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060039BC RID: 14780 RVA: 0x0006E718 File Offset: 0x0006C918
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060039BD RID: 14781 RVA: 0x0006E724 File Offset: 0x0006C924
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E52 RID: 3666
		private uint? _type;

		// Token: 0x04000E53 RID: 3667
		private IExtension extensionObject;
	}
}
