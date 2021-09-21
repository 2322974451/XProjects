using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200053A RID: 1338
	[ProtoContract(Name = "GuildHallUpdateBuff_M2C")]
	[Serializable]
	public class GuildHallUpdateBuff_M2C : IExtensible
	{
		// Token: 0x170014F8 RID: 5368
		// (get) Token: 0x06004495 RID: 17557 RVA: 0x00082730 File Offset: 0x00080930
		// (set) Token: 0x06004496 RID: 17558 RVA: 0x00082748 File Offset: 0x00080948
		[ProtoMember(1, IsRequired = false, Name = "buffdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildHallBuffData buffdata
		{
			get
			{
				return this._buffdata;
			}
			set
			{
				this._buffdata = value;
			}
		}

		// Token: 0x170014F9 RID: 5369
		// (get) Token: 0x06004497 RID: 17559 RVA: 0x00082754 File Offset: 0x00080954
		// (set) Token: 0x06004498 RID: 17560 RVA: 0x00082780 File Offset: 0x00080980
		[ProtoMember(2, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		// Token: 0x170014FA RID: 5370
		// (get) Token: 0x06004499 RID: 17561 RVA: 0x00082790 File Offset: 0x00080990
		// (set) Token: 0x0600449A RID: 17562 RVA: 0x000827B0 File Offset: 0x000809B0
		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		// Token: 0x0600449B RID: 17563 RVA: 0x000827F4 File Offset: 0x000809F4
		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		// Token: 0x0600449C RID: 17564 RVA: 0x0008280C File Offset: 0x00080A0C
		private void Resetec()
		{
			this.ecSpecified = false;
		}

		// Token: 0x0600449D RID: 17565 RVA: 0x00082818 File Offset: 0x00080A18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001121 RID: 4385
		private GuildHallBuffData _buffdata = null;

		// Token: 0x04001122 RID: 4386
		private ErrorCode? _ec;

		// Token: 0x04001123 RID: 4387
		private IExtension extensionObject;
	}
}
