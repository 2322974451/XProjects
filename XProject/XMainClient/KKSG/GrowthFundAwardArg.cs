using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001CF RID: 463
	[ProtoContract(Name = "GrowthFundAwardArg")]
	[Serializable]
	public class GrowthFundAwardArg : IExtensible
	{
		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x06001AFE RID: 6910 RVA: 0x0003563C File Offset: 0x0003383C
		// (set) Token: 0x06001AFF RID: 6911 RVA: 0x00035668 File Offset: 0x00033868
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x06001B00 RID: 6912 RVA: 0x00035678 File Offset: 0x00033878
		// (set) Token: 0x06001B01 RID: 6913 RVA: 0x00035698 File Offset: 0x00033898
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
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x000356DC File Offset: 0x000338DC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x000356F4 File Offset: 0x000338F4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x06001B04 RID: 6916 RVA: 0x00035700 File Offset: 0x00033900
		// (set) Token: 0x06001B05 RID: 6917 RVA: 0x0003572C File Offset: 0x0003392C
		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public int value
		{
			get
			{
				return this._value ?? 0;
			}
			set
			{
				this._value = new int?(value);
			}
		}

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x06001B06 RID: 6918 RVA: 0x0003573C File Offset: 0x0003393C
		// (set) Token: 0x06001B07 RID: 6919 RVA: 0x0003575C File Offset: 0x0003395C
		[XmlIgnore]
		[Browsable(false)]
		public bool valueSpecified
		{
			get
			{
				return this._value != null;
			}
			set
			{
				bool flag = value == (this._value == null);
				if (flag)
				{
					this._value = (value ? new int?(this.value) : null);
				}
			}
		}

		// Token: 0x06001B08 RID: 6920 RVA: 0x000357A0 File Offset: 0x000339A0
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x06001B09 RID: 6921 RVA: 0x000357B8 File Offset: 0x000339B8
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x000357C4 File Offset: 0x000339C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006B6 RID: 1718
		private int? _type;

		// Token: 0x040006B7 RID: 1719
		private int? _value;

		// Token: 0x040006B8 RID: 1720
		private IExtension extensionObject;
	}
}
