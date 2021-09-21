using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003DC RID: 988
	[ProtoContract(Name = "SkyCraftMatchNtf")]
	[Serializable]
	public class SkyCraftMatchNtf : IExtensible
	{
		// Token: 0x17001026 RID: 4134
		// (get) Token: 0x0600347E RID: 13438 RVA: 0x00064ABC File Offset: 0x00062CBC
		// (set) Token: 0x0600347F RID: 13439 RVA: 0x00064AE8 File Offset: 0x00062CE8
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public SkyCraftMatchNtfType type
		{
			get
			{
				return this._type ?? SkyCraftMatchNtfType.SCMN_Start;
			}
			set
			{
				this._type = new SkyCraftMatchNtfType?(value);
			}
		}

		// Token: 0x17001027 RID: 4135
		// (get) Token: 0x06003480 RID: 13440 RVA: 0x00064AF8 File Offset: 0x00062CF8
		// (set) Token: 0x06003481 RID: 13441 RVA: 0x00064B18 File Offset: 0x00062D18
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
					this._type = (value ? new SkyCraftMatchNtfType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003482 RID: 13442 RVA: 0x00064B5C File Offset: 0x00062D5C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003483 RID: 13443 RVA: 0x00064B74 File Offset: 0x00062D74
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003484 RID: 13444 RVA: 0x00064B80 File Offset: 0x00062D80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D0A RID: 3338
		private SkyCraftMatchNtfType? _type;

		// Token: 0x04000D0B RID: 3339
		private IExtension extensionObject;
	}
}
