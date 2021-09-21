using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200004F RID: 79
	[ProtoContract(Name = "GetUnitAppearanceRes")]
	[Serializable]
	public class GetUnitAppearanceRes : IExtensible
	{
		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0000CCC4 File Offset: 0x0000AEC4
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x0000CCDC File Offset: 0x0000AEDC
		[ProtoMember(1, IsRequired = false, Name = "UnitAppearance", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance UnitAppearance
		{
			get
			{
				return this._UnitAppearance;
			}
			set
			{
				this._UnitAppearance = value;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0000CCE8 File Offset: 0x0000AEE8
		// (set) Token: 0x0600054C RID: 1356 RVA: 0x0000CD14 File Offset: 0x0000AF14
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

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0000CD24 File Offset: 0x0000AF24
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0000CD44 File Offset: 0x0000AF44
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

		// Token: 0x0600054F RID: 1359 RVA: 0x0000CD88 File Offset: 0x0000AF88
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0000CDA0 File Offset: 0x0000AFA0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0000CDAC File Offset: 0x0000AFAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400015A RID: 346
		private UnitAppearance _UnitAppearance = null;

		// Token: 0x0400015B RID: 347
		private ErrorCode? _errorcode;

		// Token: 0x0400015C RID: 348
		private IExtension extensionObject;
	}
}
