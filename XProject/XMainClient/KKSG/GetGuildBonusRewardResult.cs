using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000BD RID: 189
	[ProtoContract(Name = "GetGuildBonusRewardResult")]
	[Serializable]
	public class GetGuildBonusRewardResult : IExtensible
	{
		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x0001ABC0 File Offset: 0x00018DC0
		// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x0001ABEC File Offset: 0x00018DEC
		[ProtoMember(1, IsRequired = false, Name = "getValue", DataFormat = DataFormat.TwosComplement)]
		public uint getValue
		{
			get
			{
				return this._getValue ?? 0U;
			}
			set
			{
				this._getValue = new uint?(value);
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x0001ABFC File Offset: 0x00018DFC
		// (set) Token: 0x06000CB7 RID: 3255 RVA: 0x0001AC1C File Offset: 0x00018E1C
		[XmlIgnore]
		[Browsable(false)]
		public bool getValueSpecified
		{
			get
			{
				return this._getValue != null;
			}
			set
			{
				bool flag = value == (this._getValue == null);
				if (flag)
				{
					this._getValue = (value ? new uint?(this.getValue) : null);
				}
			}
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x0001AC60 File Offset: 0x00018E60
		private bool ShouldSerializegetValue()
		{
			return this.getValueSpecified;
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0001AC78 File Offset: 0x00018E78
		private void ResetgetValue()
		{
			this.getValueSpecified = false;
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000CBA RID: 3258 RVA: 0x0001AC84 File Offset: 0x00018E84
		// (set) Token: 0x06000CBB RID: 3259 RVA: 0x0001ACB0 File Offset: 0x00018EB0
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000CBC RID: 3260 RVA: 0x0001ACC0 File Offset: 0x00018EC0
		// (set) Token: 0x06000CBD RID: 3261 RVA: 0x0001ACE0 File Offset: 0x00018EE0
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0001AD24 File Offset: 0x00018F24
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0001AD3C File Offset: 0x00018F3C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x0001AD48 File Offset: 0x00018F48
		// (set) Token: 0x06000CC1 RID: 3265 RVA: 0x0001AD74 File Offset: 0x00018F74
		[ProtoMember(3, IsRequired = false, Name = "bonusType", DataFormat = DataFormat.TwosComplement)]
		public int bonusType
		{
			get
			{
				return this._bonusType ?? 0;
			}
			set
			{
				this._bonusType = new int?(value);
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x0001AD84 File Offset: 0x00018F84
		// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x0001ADA4 File Offset: 0x00018FA4
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusTypeSpecified
		{
			get
			{
				return this._bonusType != null;
			}
			set
			{
				bool flag = value == (this._bonusType == null);
				if (flag)
				{
					this._bonusType = (value ? new int?(this.bonusType) : null);
				}
			}
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x0001ADE8 File Offset: 0x00018FE8
		private bool ShouldSerializebonusType()
		{
			return this.bonusTypeSpecified;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x0001AE00 File Offset: 0x00019000
		private void ResetbonusType()
		{
			this.bonusTypeSpecified = false;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0001AE0C File Offset: 0x0001900C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000329 RID: 809
		private uint? _getValue;

		// Token: 0x0400032A RID: 810
		private ErrorCode? _errorcode;

		// Token: 0x0400032B RID: 811
		private int? _bonusType;

		// Token: 0x0400032C RID: 812
		private IExtension extensionObject;
	}
}
