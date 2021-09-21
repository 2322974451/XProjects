using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001CE RID: 462
	[ProtoContract(Name = "PayFirstAwardRes")]
	[Serializable]
	public class PayFirstAwardRes : IExtensible
	{
		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x06001AF6 RID: 6902 RVA: 0x00035558 File Offset: 0x00033758
		// (set) Token: 0x06001AF7 RID: 6903 RVA: 0x00035584 File Offset: 0x00033784
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x06001AF8 RID: 6904 RVA: 0x00035594 File Offset: 0x00033794
		// (set) Token: 0x06001AF9 RID: 6905 RVA: 0x000355B4 File Offset: 0x000337B4
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x000355F8 File Offset: 0x000337F8
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x00035610 File Offset: 0x00033810
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x0003561C File Offset: 0x0003381C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006B4 RID: 1716
		private ErrorCode? _errcode;

		// Token: 0x040006B5 RID: 1717
		private IExtension extensionObject;
	}
}
