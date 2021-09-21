using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200054C RID: 1356
	[ProtoContract(Name = "JadeComposeNewRes")]
	[Serializable]
	public class JadeComposeNewRes : IExtensible
	{
		// Token: 0x17001531 RID: 5425
		// (get) Token: 0x0600455A RID: 17754 RVA: 0x00083D80 File Offset: 0x00081F80
		// (set) Token: 0x0600455B RID: 17755 RVA: 0x00083DAC File Offset: 0x00081FAC
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17001532 RID: 5426
		// (get) Token: 0x0600455C RID: 17756 RVA: 0x00083DBC File Offset: 0x00081FBC
		// (set) Token: 0x0600455D RID: 17757 RVA: 0x00083DDC File Offset: 0x00081FDC
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x0600455E RID: 17758 RVA: 0x00083E20 File Offset: 0x00082020
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600455F RID: 17759 RVA: 0x00083E38 File Offset: 0x00082038
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17001533 RID: 5427
		// (get) Token: 0x06004560 RID: 17760 RVA: 0x00083E44 File Offset: 0x00082044
		// (set) Token: 0x06004561 RID: 17761 RVA: 0x00083E70 File Offset: 0x00082070
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

		// Token: 0x17001534 RID: 5428
		// (get) Token: 0x06004562 RID: 17762 RVA: 0x00083E80 File Offset: 0x00082080
		// (set) Token: 0x06004563 RID: 17763 RVA: 0x00083EA0 File Offset: 0x000820A0
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

		// Token: 0x06004564 RID: 17764 RVA: 0x00083EE4 File Offset: 0x000820E4
		private bool ShouldSerializejadeSealID()
		{
			return this.jadeSealIDSpecified;
		}

		// Token: 0x06004565 RID: 17765 RVA: 0x00083EFC File Offset: 0x000820FC
		private void ResetjadeSealID()
		{
			this.jadeSealIDSpecified = false;
		}

		// Token: 0x06004566 RID: 17766 RVA: 0x00083F08 File Offset: 0x00082108
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001153 RID: 4435
		private ErrorCode? _ErrorCode;

		// Token: 0x04001154 RID: 4436
		private uint? _jadeSealID;

		// Token: 0x04001155 RID: 4437
		private IExtension extensionObject;
	}
}
