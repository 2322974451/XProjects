using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000367 RID: 871
	[ProtoContract(Name = "GetHeroBattleGameRecordRes")]
	[Serializable]
	public class GetHeroBattleGameRecordRes : IExtensible
	{
		// Token: 0x17000EB2 RID: 3762
		// (get) Token: 0x06002F79 RID: 12153 RVA: 0x0005B9F0 File Offset: 0x00059BF0
		// (set) Token: 0x06002F7A RID: 12154 RVA: 0x0005BA1C File Offset: 0x00059C1C
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

		// Token: 0x17000EB3 RID: 3763
		// (get) Token: 0x06002F7B RID: 12155 RVA: 0x0005BA2C File Offset: 0x00059C2C
		// (set) Token: 0x06002F7C RID: 12156 RVA: 0x0005BA4C File Offset: 0x00059C4C
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

		// Token: 0x06002F7D RID: 12157 RVA: 0x0005BA90 File Offset: 0x00059C90
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002F7E RID: 12158 RVA: 0x0005BAA8 File Offset: 0x00059CA8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000EB4 RID: 3764
		// (get) Token: 0x06002F7F RID: 12159 RVA: 0x0005BAB4 File Offset: 0x00059CB4
		[ProtoMember(2, Name = "games", DataFormat = DataFormat.Default)]
		public List<HeroBattleOneGame> games
		{
			get
			{
				return this._games;
			}
		}

		// Token: 0x06002F80 RID: 12160 RVA: 0x0005BACC File Offset: 0x00059CCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BC6 RID: 3014
		private ErrorCode? _errorcode;

		// Token: 0x04000BC7 RID: 3015
		private readonly List<HeroBattleOneGame> _games = new List<HeroBattleOneGame>();

		// Token: 0x04000BC8 RID: 3016
		private IExtension extensionObject;
	}
}
