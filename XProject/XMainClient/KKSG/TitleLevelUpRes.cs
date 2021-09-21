using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001DC RID: 476
	[ProtoContract(Name = "TitleLevelUpRes")]
	[Serializable]
	public class TitleLevelUpRes : IExtensible
	{
		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x06001B7A RID: 7034 RVA: 0x00036468 File Offset: 0x00034668
		// (set) Token: 0x06001B7B RID: 7035 RVA: 0x00036494 File Offset: 0x00034694
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

		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x06001B7C RID: 7036 RVA: 0x000364A4 File Offset: 0x000346A4
		// (set) Token: 0x06001B7D RID: 7037 RVA: 0x000364C4 File Offset: 0x000346C4
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

		// Token: 0x06001B7E RID: 7038 RVA: 0x00036508 File Offset: 0x00034708
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001B7F RID: 7039 RVA: 0x00036520 File Offset: 0x00034720
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x06001B80 RID: 7040 RVA: 0x0003652C File Offset: 0x0003472C
		// (set) Token: 0x06001B81 RID: 7041 RVA: 0x00036558 File Offset: 0x00034758
		[ProtoMember(2, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x06001B82 RID: 7042 RVA: 0x00036568 File Offset: 0x00034768
		// (set) Token: 0x06001B83 RID: 7043 RVA: 0x00036588 File Offset: 0x00034788
		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x000365CC File Offset: 0x000347CC
		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x000365E4 File Offset: 0x000347E4
		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x000365F0 File Offset: 0x000347F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006D8 RID: 1752
		private ErrorCode? _errorcode;

		// Token: 0x040006D9 RID: 1753
		private uint? _titleID;

		// Token: 0x040006DA RID: 1754
		private IExtension extensionObject;
	}
}
