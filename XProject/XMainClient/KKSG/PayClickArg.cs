using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C6 RID: 454
	[ProtoContract(Name = "PayClickArg")]
	[Serializable]
	public class PayClickArg : IExtensible
	{
		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x06001A95 RID: 6805 RVA: 0x00034A2C File Offset: 0x00032C2C
		// (set) Token: 0x06001A96 RID: 6806 RVA: 0x00034A58 File Offset: 0x00032C58
		[ProtoMember(1, IsRequired = false, Name = "buttonType", DataFormat = DataFormat.TwosComplement)]
		public int buttonType
		{
			get
			{
				return this._buttonType ?? 0;
			}
			set
			{
				this._buttonType = new int?(value);
			}
		}

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x06001A97 RID: 6807 RVA: 0x00034A68 File Offset: 0x00032C68
		// (set) Token: 0x06001A98 RID: 6808 RVA: 0x00034A88 File Offset: 0x00032C88
		[XmlIgnore]
		[Browsable(false)]
		public bool buttonTypeSpecified
		{
			get
			{
				return this._buttonType != null;
			}
			set
			{
				bool flag = value == (this._buttonType == null);
				if (flag)
				{
					this._buttonType = (value ? new int?(this.buttonType) : null);
				}
			}
		}

		// Token: 0x06001A99 RID: 6809 RVA: 0x00034ACC File Offset: 0x00032CCC
		private bool ShouldSerializebuttonType()
		{
			return this.buttonTypeSpecified;
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x00034AE4 File Offset: 0x00032CE4
		private void ResetbuttonType()
		{
			this.buttonTypeSpecified = false;
		}

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x06001A9B RID: 6811 RVA: 0x00034AF0 File Offset: 0x00032CF0
		// (set) Token: 0x06001A9C RID: 6812 RVA: 0x00034B1C File Offset: 0x00032D1C
		[ProtoMember(2, IsRequired = false, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public int memberid
		{
			get
			{
				return this._memberid ?? 0;
			}
			set
			{
				this._memberid = new int?(value);
			}
		}

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x06001A9D RID: 6813 RVA: 0x00034B2C File Offset: 0x00032D2C
		// (set) Token: 0x06001A9E RID: 6814 RVA: 0x00034B4C File Offset: 0x00032D4C
		[XmlIgnore]
		[Browsable(false)]
		public bool memberidSpecified
		{
			get
			{
				return this._memberid != null;
			}
			set
			{
				bool flag = value == (this._memberid == null);
				if (flag)
				{
					this._memberid = (value ? new int?(this.memberid) : null);
				}
			}
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x00034B90 File Offset: 0x00032D90
		private bool ShouldSerializememberid()
		{
			return this.memberidSpecified;
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x00034BA8 File Offset: 0x00032DA8
		private void Resetmemberid()
		{
			this.memberidSpecified = false;
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x00034BB4 File Offset: 0x00032DB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400069D RID: 1693
		private int? _buttonType;

		// Token: 0x0400069E RID: 1694
		private int? _memberid;

		// Token: 0x0400069F RID: 1695
		private IExtension extensionObject;
	}
}
