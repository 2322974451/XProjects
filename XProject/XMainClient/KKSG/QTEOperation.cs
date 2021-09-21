using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000EF RID: 239
	[ProtoContract(Name = "QTEOperation")]
	[Serializable]
	public class QTEOperation : IExtensible
	{
		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06000F31 RID: 3889 RVA: 0x0001F54C File Offset: 0x0001D74C
		// (set) Token: 0x06000F32 RID: 3890 RVA: 0x0001F578 File Offset: 0x0001D778
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

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06000F33 RID: 3891 RVA: 0x0001F588 File Offset: 0x0001D788
		// (set) Token: 0x06000F34 RID: 3892 RVA: 0x0001F5A8 File Offset: 0x0001D7A8
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

		// Token: 0x06000F35 RID: 3893 RVA: 0x0001F5EC File Offset: 0x0001D7EC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0001F604 File Offset: 0x0001D804
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x0001F610 File Offset: 0x0001D810
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x0001F63D File Offset: 0x0001D83D
		[ProtoMember(2, IsRequired = false, Name = "monsterid", DataFormat = DataFormat.TwosComplement)]
		public ulong monsterid
		{
			get
			{
				return this._monsterid ?? 0UL;
			}
			set
			{
				this._monsterid = new ulong?(value);
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x0001F64C File Offset: 0x0001D84C
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x0001F66C File Offset: 0x0001D86C
		[XmlIgnore]
		[Browsable(false)]
		public bool monsteridSpecified
		{
			get
			{
				return this._monsterid != null;
			}
			set
			{
				bool flag = value == (this._monsterid == null);
				if (flag)
				{
					this._monsterid = (value ? new ulong?(this.monsterid) : null);
				}
			}
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0001F6B0 File Offset: 0x0001D8B0
		private bool ShouldSerializemonsterid()
		{
			return this.monsteridSpecified;
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x0001F6C8 File Offset: 0x0001D8C8
		private void Resetmonsterid()
		{
			this.monsteridSpecified = false;
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x0001F6D4 File Offset: 0x0001D8D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003D1 RID: 977
		private uint? _type;

		// Token: 0x040003D2 RID: 978
		private ulong? _monsterid;

		// Token: 0x040003D3 RID: 979
		private IExtension extensionObject;
	}
}
