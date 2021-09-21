using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004FF RID: 1279
	[ProtoContract(Name = "DailyTaskRefreshOperRes")]
	[Serializable]
	public class DailyTaskRefreshOperRes : IExtensible
	{
		// Token: 0x17001439 RID: 5177
		// (get) Token: 0x06004210 RID: 16912 RVA: 0x0007DC54 File Offset: 0x0007BE54
		// (set) Token: 0x06004211 RID: 16913 RVA: 0x0007DC80 File Offset: 0x0007BE80
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

		// Token: 0x1700143A RID: 5178
		// (get) Token: 0x06004212 RID: 16914 RVA: 0x0007DC90 File Offset: 0x0007BE90
		// (set) Token: 0x06004213 RID: 16915 RVA: 0x0007DCB0 File Offset: 0x0007BEB0
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

		// Token: 0x06004214 RID: 16916 RVA: 0x0007DCF4 File Offset: 0x0007BEF4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06004215 RID: 16917 RVA: 0x0007DD0C File Offset: 0x0007BF0C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700143B RID: 5179
		// (get) Token: 0x06004216 RID: 16918 RVA: 0x0007DD18 File Offset: 0x0007BF18
		// (set) Token: 0x06004217 RID: 16919 RVA: 0x0007DD44 File Offset: 0x0007BF44
		[ProtoMember(2, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x1700143C RID: 5180
		// (get) Token: 0x06004218 RID: 16920 RVA: 0x0007DD54 File Offset: 0x0007BF54
		// (set) Token: 0x06004219 RID: 16921 RVA: 0x0007DD74 File Offset: 0x0007BF74
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x0600421A RID: 16922 RVA: 0x0007DDB8 File Offset: 0x0007BFB8
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x0600421B RID: 16923 RVA: 0x0007DDD0 File Offset: 0x0007BFD0
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x1700143D RID: 5181
		// (get) Token: 0x0600421C RID: 16924 RVA: 0x0007DDDC File Offset: 0x0007BFDC
		// (set) Token: 0x0600421D RID: 16925 RVA: 0x0007DE08 File Offset: 0x0007C008
		[ProtoMember(3, IsRequired = false, Name = "oldscore", DataFormat = DataFormat.TwosComplement)]
		public uint oldscore
		{
			get
			{
				return this._oldscore ?? 0U;
			}
			set
			{
				this._oldscore = new uint?(value);
			}
		}

		// Token: 0x1700143E RID: 5182
		// (get) Token: 0x0600421E RID: 16926 RVA: 0x0007DE18 File Offset: 0x0007C018
		// (set) Token: 0x0600421F RID: 16927 RVA: 0x0007DE38 File Offset: 0x0007C038
		[XmlIgnore]
		[Browsable(false)]
		public bool oldscoreSpecified
		{
			get
			{
				return this._oldscore != null;
			}
			set
			{
				bool flag = value == (this._oldscore == null);
				if (flag)
				{
					this._oldscore = (value ? new uint?(this.oldscore) : null);
				}
			}
		}

		// Token: 0x06004220 RID: 16928 RVA: 0x0007DE7C File Offset: 0x0007C07C
		private bool ShouldSerializeoldscore()
		{
			return this.oldscoreSpecified;
		}

		// Token: 0x06004221 RID: 16929 RVA: 0x0007DE94 File Offset: 0x0007C094
		private void Resetoldscore()
		{
			this.oldscoreSpecified = false;
		}

		// Token: 0x06004222 RID: 16930 RVA: 0x0007DEA0 File Offset: 0x0007C0A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400107A RID: 4218
		private ErrorCode? _result;

		// Token: 0x0400107B RID: 4219
		private uint? _score;

		// Token: 0x0400107C RID: 4220
		private uint? _oldscore;

		// Token: 0x0400107D RID: 4221
		private IExtension extensionObject;
	}
}
