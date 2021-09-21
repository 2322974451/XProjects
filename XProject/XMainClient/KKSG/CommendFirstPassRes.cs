using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E3 RID: 483
	[ProtoContract(Name = "CommendFirstPassRes")]
	[Serializable]
	public class CommendFirstPassRes : IExtensible
	{
		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x06001BB9 RID: 7097 RVA: 0x00036B94 File Offset: 0x00034D94
		// (set) Token: 0x06001BBA RID: 7098 RVA: 0x00036BC0 File Offset: 0x00034DC0
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

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x06001BBB RID: 7099 RVA: 0x00036BD0 File Offset: 0x00034DD0
		// (set) Token: 0x06001BBC RID: 7100 RVA: 0x00036BF0 File Offset: 0x00034DF0
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

		// Token: 0x06001BBD RID: 7101 RVA: 0x00036C34 File Offset: 0x00034E34
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001BBE RID: 7102 RVA: 0x00036C4C File Offset: 0x00034E4C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x06001BBF RID: 7103 RVA: 0x00036C58 File Offset: 0x00034E58
		// (set) Token: 0x06001BC0 RID: 7104 RVA: 0x00036C84 File Offset: 0x00034E84
		[ProtoMember(2, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x06001BC1 RID: 7105 RVA: 0x00036C94 File Offset: 0x00034E94
		// (set) Token: 0x06001BC2 RID: 7106 RVA: 0x00036CB4 File Offset: 0x00034EB4
		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x00036CF8 File Offset: 0x00034EF8
		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x00036D10 File Offset: 0x00034F10
		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x06001BC5 RID: 7109 RVA: 0x00036D1C File Offset: 0x00034F1C
		// (set) Token: 0x06001BC6 RID: 7110 RVA: 0x00036D48 File Offset: 0x00034F48
		[ProtoMember(3, IsRequired = false, Name = "starLevel", DataFormat = DataFormat.TwosComplement)]
		public int starLevel
		{
			get
			{
				return this._starLevel ?? 0;
			}
			set
			{
				this._starLevel = new int?(value);
			}
		}

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x06001BC7 RID: 7111 RVA: 0x00036D58 File Offset: 0x00034F58
		// (set) Token: 0x06001BC8 RID: 7112 RVA: 0x00036D78 File Offset: 0x00034F78
		[XmlIgnore]
		[Browsable(false)]
		public bool starLevelSpecified
		{
			get
			{
				return this._starLevel != null;
			}
			set
			{
				bool flag = value == (this._starLevel == null);
				if (flag)
				{
					this._starLevel = (value ? new int?(this.starLevel) : null);
				}
			}
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x00036DBC File Offset: 0x00034FBC
		private bool ShouldSerializestarLevel()
		{
			return this.starLevelSpecified;
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x00036DD4 File Offset: 0x00034FD4
		private void ResetstarLevel()
		{
			this.starLevelSpecified = false;
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x00036DE0 File Offset: 0x00034FE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006E8 RID: 1768
		private ErrorCode? _error;

		// Token: 0x040006E9 RID: 1769
		private int? _commendNum;

		// Token: 0x040006EA RID: 1770
		private int? _starLevel;

		// Token: 0x040006EB RID: 1771
		private IExtension extensionObject;
	}
}
