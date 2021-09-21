using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D7 RID: 471
	[ProtoContract(Name = "ChooseRollReqRes")]
	[Serializable]
	public class ChooseRollReqRes : IExtensible
	{
		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x06001B46 RID: 6982 RVA: 0x00035E6C File Offset: 0x0003406C
		// (set) Token: 0x06001B47 RID: 6983 RVA: 0x00035E98 File Offset: 0x00034098
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x06001B48 RID: 6984 RVA: 0x00035EA8 File Offset: 0x000340A8
		// (set) Token: 0x06001B49 RID: 6985 RVA: 0x00035EC8 File Offset: 0x000340C8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001B4A RID: 6986 RVA: 0x00035F0C File Offset: 0x0003410C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001B4B RID: 6987 RVA: 0x00035F24 File Offset: 0x00034124
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001B4C RID: 6988 RVA: 0x00035F30 File Offset: 0x00034130
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006CC RID: 1740
		private ErrorCode? _error;

		// Token: 0x040006CD RID: 1741
		private IExtension extensionObject;
	}
}
