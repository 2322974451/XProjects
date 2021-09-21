using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000588 RID: 1416
	[ProtoContract(Name = "MapIntItem")]
	[Serializable]
	public class MapIntItem : IExtensible
	{
		// Token: 0x170016F3 RID: 5875
		// (get) Token: 0x06004A9D RID: 19101 RVA: 0x0008DDC4 File Offset: 0x0008BFC4
		// (set) Token: 0x06004A9E RID: 19102 RVA: 0x0008DDF1 File Offset: 0x0008BFF1
		[ProtoMember(1, IsRequired = false, Name = "key", DataFormat = DataFormat.TwosComplement)]
		public ulong key
		{
			get
			{
				return this._key ?? 0UL;
			}
			set
			{
				this._key = new ulong?(value);
			}
		}

		// Token: 0x170016F4 RID: 5876
		// (get) Token: 0x06004A9F RID: 19103 RVA: 0x0008DE00 File Offset: 0x0008C000
		// (set) Token: 0x06004AA0 RID: 19104 RVA: 0x0008DE20 File Offset: 0x0008C020
		[XmlIgnore]
		[Browsable(false)]
		public bool keySpecified
		{
			get
			{
				return this._key != null;
			}
			set
			{
				bool flag = value == (this._key == null);
				if (flag)
				{
					this._key = (value ? new ulong?(this.key) : null);
				}
			}
		}

		// Token: 0x06004AA1 RID: 19105 RVA: 0x0008DE64 File Offset: 0x0008C064
		private bool ShouldSerializekey()
		{
			return this.keySpecified;
		}

		// Token: 0x06004AA2 RID: 19106 RVA: 0x0008DE7C File Offset: 0x0008C07C
		private void Resetkey()
		{
			this.keySpecified = false;
		}

		// Token: 0x170016F5 RID: 5877
		// (get) Token: 0x06004AA3 RID: 19107 RVA: 0x0008DE88 File Offset: 0x0008C088
		// (set) Token: 0x06004AA4 RID: 19108 RVA: 0x0008DEB4 File Offset: 0x0008C0B4
		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public uint value
		{
			get
			{
				return this._value ?? 0U;
			}
			set
			{
				this._value = new uint?(value);
			}
		}

		// Token: 0x170016F6 RID: 5878
		// (get) Token: 0x06004AA5 RID: 19109 RVA: 0x0008DEC4 File Offset: 0x0008C0C4
		// (set) Token: 0x06004AA6 RID: 19110 RVA: 0x0008DEE4 File Offset: 0x0008C0E4
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
					this._value = (value ? new uint?(this.value) : null);
				}
			}
		}

		// Token: 0x06004AA7 RID: 19111 RVA: 0x0008DF28 File Offset: 0x0008C128
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x06004AA8 RID: 19112 RVA: 0x0008DF40 File Offset: 0x0008C140
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x06004AA9 RID: 19113 RVA: 0x0008DF4C File Offset: 0x0008C14C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001296 RID: 4758
		private ulong? _key;

		// Token: 0x04001297 RID: 4759
		private uint? _value;

		// Token: 0x04001298 RID: 4760
		private IExtension extensionObject;
	}
}
