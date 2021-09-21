using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003AD RID: 941
	[ProtoContract(Name = "ChangeSkillSetRes")]
	[Serializable]
	public class ChangeSkillSetRes : IExtensible
	{
		// Token: 0x17000F94 RID: 3988
		// (get) Token: 0x0600327B RID: 12923 RVA: 0x0006118C File Offset: 0x0005F38C
		// (set) Token: 0x0600327C RID: 12924 RVA: 0x000611B8 File Offset: 0x0005F3B8
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

		// Token: 0x17000F95 RID: 3989
		// (get) Token: 0x0600327D RID: 12925 RVA: 0x000611C8 File Offset: 0x0005F3C8
		// (set) Token: 0x0600327E RID: 12926 RVA: 0x000611E8 File Offset: 0x0005F3E8
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

		// Token: 0x0600327F RID: 12927 RVA: 0x0006122C File Offset: 0x0005F42C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003280 RID: 12928 RVA: 0x00061244 File Offset: 0x0005F444
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000F96 RID: 3990
		// (get) Token: 0x06003281 RID: 12929 RVA: 0x00061250 File Offset: 0x0005F450
		// (set) Token: 0x06003282 RID: 12930 RVA: 0x00061268 File Offset: 0x0005F468
		[ProtoMember(2, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkillRecord record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		// Token: 0x06003283 RID: 12931 RVA: 0x00061274 File Offset: 0x0005F474
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C8D RID: 3213
		private ErrorCode? _errorcode;

		// Token: 0x04000C8E RID: 3214
		private SkillRecord _record = null;

		// Token: 0x04000C8F RID: 3215
		private IExtension extensionObject;
	}
}
