using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C8 RID: 456
	[ProtoContract(Name = "GetActivityInfoRes")]
	[Serializable]
	public class GetActivityInfoRes : IExtensible
	{
		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x06001AC4 RID: 6852 RVA: 0x00035004 File Offset: 0x00033204
		// (set) Token: 0x06001AC5 RID: 6853 RVA: 0x00035030 File Offset: 0x00033230
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x06001AC6 RID: 6854 RVA: 0x00035040 File Offset: 0x00033240
		// (set) Token: 0x06001AC7 RID: 6855 RVA: 0x00035060 File Offset: 0x00033260
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

		// Token: 0x06001AC8 RID: 6856 RVA: 0x000350A4 File Offset: 0x000332A4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x000350BC File Offset: 0x000332BC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x06001ACA RID: 6858 RVA: 0x000350C8 File Offset: 0x000332C8
		// (set) Token: 0x06001ACB RID: 6859 RVA: 0x000350E0 File Offset: 0x000332E0
		[ProtoMember(2, IsRequired = false, Name = "Record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ActivityRecord Record
		{
			get
			{
				return this._Record;
			}
			set
			{
				this._Record = value;
			}
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x000350EC File Offset: 0x000332EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006A7 RID: 1703
		private ErrorCode? _errorcode;

		// Token: 0x040006A8 RID: 1704
		private ActivityRecord _Record = null;

		// Token: 0x040006A9 RID: 1705
		private IExtension extensionObject;
	}
}
