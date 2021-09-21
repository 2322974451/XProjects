using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000363 RID: 867
	[ProtoContract(Name = "GetGuildBonusLeftRes")]
	[Serializable]
	public class GetGuildBonusLeftRes : IExtensible
	{
		// Token: 0x17000EA7 RID: 3751
		// (get) Token: 0x06002F52 RID: 12114 RVA: 0x0005B570 File Offset: 0x00059770
		// (set) Token: 0x06002F53 RID: 12115 RVA: 0x0005B59C File Offset: 0x0005979C
		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000EA8 RID: 3752
		// (get) Token: 0x06002F54 RID: 12116 RVA: 0x0005B5AC File Offset: 0x000597AC
		// (set) Token: 0x06002F55 RID: 12117 RVA: 0x0005B5CC File Offset: 0x000597CC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		// Token: 0x06002F56 RID: 12118 RVA: 0x0005B610 File Offset: 0x00059810
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x06002F57 RID: 12119 RVA: 0x0005B628 File Offset: 0x00059828
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x17000EA9 RID: 3753
		// (get) Token: 0x06002F58 RID: 12120 RVA: 0x0005B634 File Offset: 0x00059834
		[ProtoMember(2, Name = "bonusInfos", DataFormat = DataFormat.Default)]
		public List<GuildBonusBriefInfo> bonusInfos
		{
			get
			{
				return this._bonusInfos;
			}
		}

		// Token: 0x06002F59 RID: 12121 RVA: 0x0005B64C File Offset: 0x0005984C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BBC RID: 3004
		private ErrorCode? _errorCode;

		// Token: 0x04000BBD RID: 3005
		private readonly List<GuildBonusBriefInfo> _bonusInfos = new List<GuildBonusBriefInfo>();

		// Token: 0x04000BBE RID: 3006
		private IExtension extensionObject;
	}
}
