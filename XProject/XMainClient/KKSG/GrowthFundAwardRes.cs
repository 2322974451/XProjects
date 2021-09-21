using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D0 RID: 464
	[ProtoContract(Name = "GrowthFundAwardRes")]
	[Serializable]
	public class GrowthFundAwardRes : IExtensible
	{
		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x06001B0C RID: 6924 RVA: 0x00035804 File Offset: 0x00033A04
		// (set) Token: 0x06001B0D RID: 6925 RVA: 0x00035830 File Offset: 0x00033A30
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

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x06001B0E RID: 6926 RVA: 0x00035840 File Offset: 0x00033A40
		// (set) Token: 0x06001B0F RID: 6927 RVA: 0x00035860 File Offset: 0x00033A60
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

		// Token: 0x06001B10 RID: 6928 RVA: 0x000358A4 File Offset: 0x00033AA4
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x000358BC File Offset: 0x00033ABC
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06001B12 RID: 6930 RVA: 0x000358C8 File Offset: 0x00033AC8
		[ProtoMember(2, Name = "growthFundLevelInfo", DataFormat = DataFormat.TwosComplement)]
		public List<int> growthFundLevelInfo
		{
			get
			{
				return this._growthFundLevelInfo;
			}
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x06001B13 RID: 6931 RVA: 0x000358E0 File Offset: 0x00033AE0
		[ProtoMember(3, Name = "growthFundLoginInfo", DataFormat = DataFormat.TwosComplement)]
		public List<int> growthFundLoginInfo
		{
			get
			{
				return this._growthFundLoginInfo;
			}
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x000358F8 File Offset: 0x00033AF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006B9 RID: 1721
		private ErrorCode? _errcode;

		// Token: 0x040006BA RID: 1722
		private readonly List<int> _growthFundLevelInfo = new List<int>();

		// Token: 0x040006BB RID: 1723
		private readonly List<int> _growthFundLoginInfo = new List<int>();

		// Token: 0x040006BC RID: 1724
		private IExtension extensionObject;
	}
}
