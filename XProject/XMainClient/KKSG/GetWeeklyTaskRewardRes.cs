using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E2 RID: 1250
	[ProtoContract(Name = "GetWeeklyTaskRewardRes")]
	[Serializable]
	public class GetWeeklyTaskRewardRes : IExtensible
	{
		// Token: 0x170013C7 RID: 5063
		// (get) Token: 0x0600409E RID: 16542 RVA: 0x0007B0E4 File Offset: 0x000792E4
		// (set) Token: 0x0600409F RID: 16543 RVA: 0x0007B110 File Offset: 0x00079310
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

		// Token: 0x170013C8 RID: 5064
		// (get) Token: 0x060040A0 RID: 16544 RVA: 0x0007B120 File Offset: 0x00079320
		// (set) Token: 0x060040A1 RID: 16545 RVA: 0x0007B140 File Offset: 0x00079340
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

		// Token: 0x060040A2 RID: 16546 RVA: 0x0007B184 File Offset: 0x00079384
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060040A3 RID: 16547 RVA: 0x0007B19C File Offset: 0x0007939C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170013C9 RID: 5065
		// (get) Token: 0x060040A4 RID: 16548 RVA: 0x0007B1A8 File Offset: 0x000793A8
		// (set) Token: 0x060040A5 RID: 16549 RVA: 0x0007B1D4 File Offset: 0x000793D4
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

		// Token: 0x170013CA RID: 5066
		// (get) Token: 0x060040A6 RID: 16550 RVA: 0x0007B1E4 File Offset: 0x000793E4
		// (set) Token: 0x060040A7 RID: 16551 RVA: 0x0007B204 File Offset: 0x00079404
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

		// Token: 0x060040A8 RID: 16552 RVA: 0x0007B248 File Offset: 0x00079448
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x060040A9 RID: 16553 RVA: 0x0007B260 File Offset: 0x00079460
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x060040AA RID: 16554 RVA: 0x0007B26C File Offset: 0x0007946C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400101B RID: 4123
		private ErrorCode? _result;

		// Token: 0x0400101C RID: 4124
		private uint? _score;

		// Token: 0x0400101D RID: 4125
		private IExtension extensionObject;
	}
}
