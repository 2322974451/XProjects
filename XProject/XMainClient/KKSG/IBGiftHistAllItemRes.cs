using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003BE RID: 958
	[ProtoContract(Name = "IBGiftHistAllItemRes")]
	[Serializable]
	public class IBGiftHistAllItemRes : IExtensible
	{
		// Token: 0x17000FCD RID: 4045
		// (get) Token: 0x06003340 RID: 13120 RVA: 0x00062768 File Offset: 0x00060968
		// (set) Token: 0x06003341 RID: 13121 RVA: 0x00062794 File Offset: 0x00060994
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

		// Token: 0x17000FCE RID: 4046
		// (get) Token: 0x06003342 RID: 13122 RVA: 0x000627A4 File Offset: 0x000609A4
		// (set) Token: 0x06003343 RID: 13123 RVA: 0x000627C4 File Offset: 0x000609C4
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

		// Token: 0x06003344 RID: 13124 RVA: 0x00062808 File Offset: 0x00060A08
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003345 RID: 13125 RVA: 0x00062820 File Offset: 0x00060A20
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000FCF RID: 4047
		// (get) Token: 0x06003346 RID: 13126 RVA: 0x0006282C File Offset: 0x00060A2C
		// (set) Token: 0x06003347 RID: 13127 RVA: 0x00062844 File Offset: 0x00060A44
		[ProtoMember(2, IsRequired = false, Name = "gift", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public IBGiftHistAllItem gift
		{
			get
			{
				return this._gift;
			}
			set
			{
				this._gift = value;
			}
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x00062850 File Offset: 0x00060A50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CBD RID: 3261
		private ErrorCode? _errorcode;

		// Token: 0x04000CBE RID: 3262
		private IBGiftHistAllItem _gift = null;

		// Token: 0x04000CBF RID: 3263
		private IExtension extensionObject;
	}
}
