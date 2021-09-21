using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003AA RID: 938
	[ProtoContract(Name = "ClickNewNoticeRes")]
	[Serializable]
	public class ClickNewNoticeRes : IExtensible
	{
		// Token: 0x17000F8E RID: 3982
		// (get) Token: 0x06003263 RID: 12899 RVA: 0x00060ED0 File Offset: 0x0005F0D0
		// (set) Token: 0x06003264 RID: 12900 RVA: 0x00060EFC File Offset: 0x0005F0FC
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000F8F RID: 3983
		// (get) Token: 0x06003265 RID: 12901 RVA: 0x00060F0C File Offset: 0x0005F10C
		// (set) Token: 0x06003266 RID: 12902 RVA: 0x00060F2C File Offset: 0x0005F12C
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003267 RID: 12903 RVA: 0x00060F70 File Offset: 0x0005F170
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003268 RID: 12904 RVA: 0x00060F88 File Offset: 0x0005F188
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003269 RID: 12905 RVA: 0x00060F94 File Offset: 0x0005F194
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C87 RID: 3207
		private ErrorCode? _result;

		// Token: 0x04000C88 RID: 3208
		private IExtension extensionObject;
	}
}
