using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B9 RID: 953
	[ProtoContract(Name = "PayFriendItemArg")]
	[Serializable]
	public class PayFriendItemArg : IExtensible
	{
		// Token: 0x17000FB1 RID: 4017
		// (get) Token: 0x060032E5 RID: 13029 RVA: 0x00061D8C File Offset: 0x0005FF8C
		// (set) Token: 0x060032E6 RID: 13030 RVA: 0x00061DA4 File Offset: 0x0005FFA4
		[ProtoMember(1, IsRequired = false, Name = "payparam", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayParameterInfo payparam
		{
			get
			{
				return this._payparam;
			}
			set
			{
				this._payparam = value;
			}
		}

		// Token: 0x17000FB2 RID: 4018
		// (get) Token: 0x060032E7 RID: 13031 RVA: 0x00061DB0 File Offset: 0x0005FFB0
		// (set) Token: 0x060032E8 RID: 13032 RVA: 0x00061DDC File Offset: 0x0005FFDC
		[ProtoMember(2, IsRequired = false, Name = "goodsid", DataFormat = DataFormat.TwosComplement)]
		public uint goodsid
		{
			get
			{
				return this._goodsid ?? 0U;
			}
			set
			{
				this._goodsid = new uint?(value);
			}
		}

		// Token: 0x17000FB3 RID: 4019
		// (get) Token: 0x060032E9 RID: 13033 RVA: 0x00061DEC File Offset: 0x0005FFEC
		// (set) Token: 0x060032EA RID: 13034 RVA: 0x00061E0C File Offset: 0x0006000C
		[XmlIgnore]
		[Browsable(false)]
		public bool goodsidSpecified
		{
			get
			{
				return this._goodsid != null;
			}
			set
			{
				bool flag = value == (this._goodsid == null);
				if (flag)
				{
					this._goodsid = (value ? new uint?(this.goodsid) : null);
				}
			}
		}

		// Token: 0x060032EB RID: 13035 RVA: 0x00061E50 File Offset: 0x00060050
		private bool ShouldSerializegoodsid()
		{
			return this.goodsidSpecified;
		}

		// Token: 0x060032EC RID: 13036 RVA: 0x00061E68 File Offset: 0x00060068
		private void Resetgoodsid()
		{
			this.goodsidSpecified = false;
		}

		// Token: 0x17000FB4 RID: 4020
		// (get) Token: 0x060032ED RID: 13037 RVA: 0x00061E74 File Offset: 0x00060074
		// (set) Token: 0x060032EE RID: 13038 RVA: 0x00061EA0 File Offset: 0x000600A0
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000FB5 RID: 4021
		// (get) Token: 0x060032EF RID: 13039 RVA: 0x00061EB0 File Offset: 0x000600B0
		// (set) Token: 0x060032F0 RID: 13040 RVA: 0x00061ED0 File Offset: 0x000600D0
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x060032F1 RID: 13041 RVA: 0x00061F14 File Offset: 0x00060114
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060032F2 RID: 13042 RVA: 0x00061F2C File Offset: 0x0006012C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x17000FB6 RID: 4022
		// (get) Token: 0x060032F3 RID: 13043 RVA: 0x00061F38 File Offset: 0x00060138
		// (set) Token: 0x060032F4 RID: 13044 RVA: 0x00061F65 File Offset: 0x00060165
		[ProtoMember(4, IsRequired = false, Name = "toroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong toroleid
		{
			get
			{
				return this._toroleid ?? 0UL;
			}
			set
			{
				this._toroleid = new ulong?(value);
			}
		}

		// Token: 0x17000FB7 RID: 4023
		// (get) Token: 0x060032F5 RID: 13045 RVA: 0x00061F74 File Offset: 0x00060174
		// (set) Token: 0x060032F6 RID: 13046 RVA: 0x00061F94 File Offset: 0x00060194
		[XmlIgnore]
		[Browsable(false)]
		public bool toroleidSpecified
		{
			get
			{
				return this._toroleid != null;
			}
			set
			{
				bool flag = value == (this._toroleid == null);
				if (flag)
				{
					this._toroleid = (value ? new ulong?(this.toroleid) : null);
				}
			}
		}

		// Token: 0x060032F7 RID: 13047 RVA: 0x00061FD8 File Offset: 0x000601D8
		private bool ShouldSerializetoroleid()
		{
			return this.toroleidSpecified;
		}

		// Token: 0x060032F8 RID: 13048 RVA: 0x00061FF0 File Offset: 0x000601F0
		private void Resettoroleid()
		{
			this.toroleidSpecified = false;
		}

		// Token: 0x17000FB8 RID: 4024
		// (get) Token: 0x060032F9 RID: 13049 RVA: 0x00061FFC File Offset: 0x000601FC
		// (set) Token: 0x060032FA RID: 13050 RVA: 0x0006201D File Offset: 0x0006021D
		[ProtoMember(5, IsRequired = false, Name = "text", DataFormat = DataFormat.Default)]
		public string text
		{
			get
			{
				return this._text ?? "";
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x17000FB9 RID: 4025
		// (get) Token: 0x060032FB RID: 13051 RVA: 0x00062028 File Offset: 0x00060228
		// (set) Token: 0x060032FC RID: 13052 RVA: 0x00062044 File Offset: 0x00060244
		[XmlIgnore]
		[Browsable(false)]
		public bool textSpecified
		{
			get
			{
				return this._text != null;
			}
			set
			{
				bool flag = value == (this._text == null);
				if (flag)
				{
					this._text = (value ? this.text : null);
				}
			}
		}

		// Token: 0x060032FD RID: 13053 RVA: 0x00062074 File Offset: 0x00060274
		private bool ShouldSerializetext()
		{
			return this.textSpecified;
		}

		// Token: 0x060032FE RID: 13054 RVA: 0x0006208C File Offset: 0x0006028C
		private void Resettext()
		{
			this.textSpecified = false;
		}

		// Token: 0x060032FF RID: 13055 RVA: 0x00062098 File Offset: 0x00060298
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CA9 RID: 3241
		private PayParameterInfo _payparam = null;

		// Token: 0x04000CAA RID: 3242
		private uint? _goodsid;

		// Token: 0x04000CAB RID: 3243
		private uint? _count;

		// Token: 0x04000CAC RID: 3244
		private ulong? _toroleid;

		// Token: 0x04000CAD RID: 3245
		private string _text;

		// Token: 0x04000CAE RID: 3246
		private IExtension extensionObject;
	}
}
