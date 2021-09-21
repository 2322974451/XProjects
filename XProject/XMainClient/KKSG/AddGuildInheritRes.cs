using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D8 RID: 728
	[ProtoContract(Name = "AddGuildInheritRes")]
	[Serializable]
	public class AddGuildInheritRes : IExtensible
	{
		// Token: 0x17000C7E RID: 3198
		// (get) Token: 0x0600282B RID: 10283 RVA: 0x0004E12C File Offset: 0x0004C32C
		// (set) Token: 0x0600282C RID: 10284 RVA: 0x0004E158 File Offset: 0x0004C358
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

		// Token: 0x17000C7F RID: 3199
		// (get) Token: 0x0600282D RID: 10285 RVA: 0x0004E168 File Offset: 0x0004C368
		// (set) Token: 0x0600282E RID: 10286 RVA: 0x0004E188 File Offset: 0x0004C388
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

		// Token: 0x0600282F RID: 10287 RVA: 0x0004E1CC File Offset: 0x0004C3CC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002830 RID: 10288 RVA: 0x0004E1E4 File Offset: 0x0004C3E4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002831 RID: 10289 RVA: 0x0004E1F0 File Offset: 0x0004C3F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009FF RID: 2559
		private ErrorCode? _errorcode;

		// Token: 0x04000A00 RID: 2560
		private IExtension extensionObject;
	}
}
