using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200006F RID: 111
	[ProtoContract(Name = "QueryOpenGameRes")]
	[Serializable]
	public class QueryOpenGameRes : IExtensible
	{
		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x0001059C File Offset: 0x0000E79C
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x000105C8 File Offset: 0x0000E7C8
		[ProtoMember(1, IsRequired = false, Name = "timeLeft", DataFormat = DataFormat.TwosComplement)]
		public uint timeLeft
		{
			get
			{
				return this._timeLeft ?? 0U;
			}
			set
			{
				this._timeLeft = new uint?(value);
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x000105D8 File Offset: 0x0000E7D8
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x000105F8 File Offset: 0x0000E7F8
		[XmlIgnore]
		[Browsable(false)]
		public bool timeLeftSpecified
		{
			get
			{
				return this._timeLeft != null;
			}
			set
			{
				bool flag = value == (this._timeLeft == null);
				if (flag)
				{
					this._timeLeft = (value ? new uint?(this.timeLeft) : null);
				}
			}
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0001063C File Offset: 0x0000E83C
		private bool ShouldSerializetimeLeft()
		{
			return this.timeLeftSpecified;
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00010654 File Offset: 0x0000E854
		private void ResettimeLeft()
		{
			this.timeLeftSpecified = false;
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x00010660 File Offset: 0x0000E860
		// (set) Token: 0x0600072F RID: 1839 RVA: 0x0001068C File Offset: 0x0000E88C
		[ProtoMember(2, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x0001069C File Offset: 0x0000E89C
		// (set) Token: 0x06000731 RID: 1841 RVA: 0x000106BC File Offset: 0x0000E8BC
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

		// Token: 0x06000732 RID: 1842 RVA: 0x00010700 File Offset: 0x0000E900
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00010718 File Offset: 0x0000E918
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00010724 File Offset: 0x0000E924
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001D3 RID: 467
		private uint? _timeLeft;

		// Token: 0x040001D4 RID: 468
		private ErrorCode? _errcode;

		// Token: 0x040001D5 RID: 469
		private IExtension extensionObject;
	}
}
