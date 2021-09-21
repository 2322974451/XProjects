using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001FC RID: 508
	[ProtoContract(Name = "AutoBreakAtlasRes")]
	[Serializable]
	public class AutoBreakAtlasRes : IExtensible
	{
		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x06001CD9 RID: 7385 RVA: 0x00038D0C File Offset: 0x00036F0C
		// (set) Token: 0x06001CDA RID: 7386 RVA: 0x00038D38 File Offset: 0x00036F38
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

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x06001CDB RID: 7387 RVA: 0x00038D48 File Offset: 0x00036F48
		// (set) Token: 0x06001CDC RID: 7388 RVA: 0x00038D68 File Offset: 0x00036F68
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

		// Token: 0x06001CDD RID: 7389 RVA: 0x00038DAC File Offset: 0x00036FAC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001CDE RID: 7390 RVA: 0x00038DC4 File Offset: 0x00036FC4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001CDF RID: 7391 RVA: 0x00038DD0 File Offset: 0x00036FD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400072F RID: 1839
		private ErrorCode? _errorcode;

		// Token: 0x04000730 RID: 1840
		private IExtension extensionObject;
	}
}
