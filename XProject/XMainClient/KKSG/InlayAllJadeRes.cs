using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000558 RID: 1368
	[ProtoContract(Name = "InlayAllJadeRes")]
	[Serializable]
	public class InlayAllJadeRes : IExtensible
	{
		// Token: 0x17001556 RID: 5462
		// (get) Token: 0x060045DF RID: 17887 RVA: 0x00084C04 File Offset: 0x00082E04
		// (set) Token: 0x060045E0 RID: 17888 RVA: 0x00084C30 File Offset: 0x00082E30
		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17001557 RID: 5463
		// (get) Token: 0x060045E1 RID: 17889 RVA: 0x00084C40 File Offset: 0x00082E40
		// (set) Token: 0x060045E2 RID: 17890 RVA: 0x00084C60 File Offset: 0x00082E60
		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		// Token: 0x060045E3 RID: 17891 RVA: 0x00084CA4 File Offset: 0x00082EA4
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x060045E4 RID: 17892 RVA: 0x00084CBC File Offset: 0x00082EBC
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x17001558 RID: 5464
		// (get) Token: 0x060045E5 RID: 17893 RVA: 0x00084CC8 File Offset: 0x00082EC8
		// (set) Token: 0x060045E6 RID: 17894 RVA: 0x00084CF4 File Offset: 0x00082EF4
		[ProtoMember(2, IsRequired = false, Name = "jadeSealID", DataFormat = DataFormat.TwosComplement)]
		public uint jadeSealID
		{
			get
			{
				return this._jadeSealID ?? 0U;
			}
			set
			{
				this._jadeSealID = new uint?(value);
			}
		}

		// Token: 0x17001559 RID: 5465
		// (get) Token: 0x060045E7 RID: 17895 RVA: 0x00084D04 File Offset: 0x00082F04
		// (set) Token: 0x060045E8 RID: 17896 RVA: 0x00084D24 File Offset: 0x00082F24
		[XmlIgnore]
		[Browsable(false)]
		public bool jadeSealIDSpecified
		{
			get
			{
				return this._jadeSealID != null;
			}
			set
			{
				bool flag = value == (this._jadeSealID == null);
				if (flag)
				{
					this._jadeSealID = (value ? new uint?(this.jadeSealID) : null);
				}
			}
		}

		// Token: 0x060045E9 RID: 17897 RVA: 0x00084D68 File Offset: 0x00082F68
		private bool ShouldSerializejadeSealID()
		{
			return this.jadeSealIDSpecified;
		}

		// Token: 0x060045EA RID: 17898 RVA: 0x00084D80 File Offset: 0x00082F80
		private void ResetjadeSealID()
		{
			this.jadeSealIDSpecified = false;
		}

		// Token: 0x060045EB RID: 17899 RVA: 0x00084D8C File Offset: 0x00082F8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001172 RID: 4466
		private ErrorCode? _errorCode;

		// Token: 0x04001173 RID: 4467
		private uint? _jadeSealID;

		// Token: 0x04001174 RID: 4468
		private IExtension extensionObject;
	}
}
