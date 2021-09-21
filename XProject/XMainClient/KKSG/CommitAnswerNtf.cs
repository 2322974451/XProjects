using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200024E RID: 590
	[ProtoContract(Name = "CommitAnswerNtf")]
	[Serializable]
	public class CommitAnswerNtf : IExtensible
	{
		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x06002104 RID: 8452 RVA: 0x00040AB4 File Offset: 0x0003ECB4
		// (set) Token: 0x06002105 RID: 8453 RVA: 0x00040AE1 File Offset: 0x0003ECE1
		[ProtoMember(1, IsRequired = false, Name = "audiouid", DataFormat = DataFormat.TwosComplement)]
		public ulong audiouid
		{
			get
			{
				return this._audiouid ?? 0UL;
			}
			set
			{
				this._audiouid = new ulong?(value);
			}
		}

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x06002106 RID: 8454 RVA: 0x00040AF0 File Offset: 0x0003ECF0
		// (set) Token: 0x06002107 RID: 8455 RVA: 0x00040B10 File Offset: 0x0003ED10
		[XmlIgnore]
		[Browsable(false)]
		public bool audiouidSpecified
		{
			get
			{
				return this._audiouid != null;
			}
			set
			{
				bool flag = value == (this._audiouid == null);
				if (flag)
				{
					this._audiouid = (value ? new ulong?(this.audiouid) : null);
				}
			}
		}

		// Token: 0x06002108 RID: 8456 RVA: 0x00040B54 File Offset: 0x0003ED54
		private bool ShouldSerializeaudiouid()
		{
			return this.audiouidSpecified;
		}

		// Token: 0x06002109 RID: 8457 RVA: 0x00040B6C File Offset: 0x0003ED6C
		private void Resetaudiouid()
		{
			this.audiouidSpecified = false;
		}

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x0600210A RID: 8458 RVA: 0x00040B78 File Offset: 0x0003ED78
		// (set) Token: 0x0600210B RID: 8459 RVA: 0x00040B99 File Offset: 0x0003ED99
		[ProtoMember(2, IsRequired = false, Name = "answer", DataFormat = DataFormat.Default)]
		public string answer
		{
			get
			{
				return this._answer ?? "";
			}
			set
			{
				this._answer = value;
			}
		}

		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x0600210C RID: 8460 RVA: 0x00040BA4 File Offset: 0x0003EDA4
		// (set) Token: 0x0600210D RID: 8461 RVA: 0x00040BC0 File Offset: 0x0003EDC0
		[XmlIgnore]
		[Browsable(false)]
		public bool answerSpecified
		{
			get
			{
				return this._answer != null;
			}
			set
			{
				bool flag = value == (this._answer == null);
				if (flag)
				{
					this._answer = (value ? this.answer : null);
				}
			}
		}

		// Token: 0x0600210E RID: 8462 RVA: 0x00040BF0 File Offset: 0x0003EDF0
		private bool ShouldSerializeanswer()
		{
			return this.answerSpecified;
		}

		// Token: 0x0600210F RID: 8463 RVA: 0x00040C08 File Offset: 0x0003EE08
		private void Resetanswer()
		{
			this.answerSpecified = false;
		}

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x06002110 RID: 8464 RVA: 0x00040C14 File Offset: 0x0003EE14
		// (set) Token: 0x06002111 RID: 8465 RVA: 0x00040C40 File Offset: 0x0003EE40
		[ProtoMember(3, IsRequired = false, Name = "audiotime", DataFormat = DataFormat.TwosComplement)]
		public uint audiotime
		{
			get
			{
				return this._audiotime ?? 0U;
			}
			set
			{
				this._audiotime = new uint?(value);
			}
		}

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x06002112 RID: 8466 RVA: 0x00040C50 File Offset: 0x0003EE50
		// (set) Token: 0x06002113 RID: 8467 RVA: 0x00040C70 File Offset: 0x0003EE70
		[XmlIgnore]
		[Browsable(false)]
		public bool audiotimeSpecified
		{
			get
			{
				return this._audiotime != null;
			}
			set
			{
				bool flag = value == (this._audiotime == null);
				if (flag)
				{
					this._audiotime = (value ? new uint?(this.audiotime) : null);
				}
			}
		}

		// Token: 0x06002114 RID: 8468 RVA: 0x00040CB4 File Offset: 0x0003EEB4
		private bool ShouldSerializeaudiotime()
		{
			return this.audiotimeSpecified;
		}

		// Token: 0x06002115 RID: 8469 RVA: 0x00040CCC File Offset: 0x0003EECC
		private void Resetaudiotime()
		{
			this.audiotimeSpecified = false;
		}

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06002116 RID: 8470 RVA: 0x00040CD8 File Offset: 0x0003EED8
		// (set) Token: 0x06002117 RID: 8471 RVA: 0x00040D04 File Offset: 0x0003EF04
		[ProtoMember(4, IsRequired = false, Name = "qid", DataFormat = DataFormat.TwosComplement)]
		public uint qid
		{
			get
			{
				return this._qid ?? 0U;
			}
			set
			{
				this._qid = new uint?(value);
			}
		}

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06002118 RID: 8472 RVA: 0x00040D14 File Offset: 0x0003EF14
		// (set) Token: 0x06002119 RID: 8473 RVA: 0x00040D34 File Offset: 0x0003EF34
		[XmlIgnore]
		[Browsable(false)]
		public bool qidSpecified
		{
			get
			{
				return this._qid != null;
			}
			set
			{
				bool flag = value == (this._qid == null);
				if (flag)
				{
					this._qid = (value ? new uint?(this.qid) : null);
				}
			}
		}

		// Token: 0x0600211A RID: 8474 RVA: 0x00040D78 File Offset: 0x0003EF78
		private bool ShouldSerializeqid()
		{
			return this.qidSpecified;
		}

		// Token: 0x0600211B RID: 8475 RVA: 0x00040D90 File Offset: 0x0003EF90
		private void Resetqid()
		{
			this.qidSpecified = false;
		}

		// Token: 0x0600211C RID: 8476 RVA: 0x00040D9C File Offset: 0x0003EF9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000836 RID: 2102
		private ulong? _audiouid;

		// Token: 0x04000837 RID: 2103
		private string _answer;

		// Token: 0x04000838 RID: 2104
		private uint? _audiotime;

		// Token: 0x04000839 RID: 2105
		private uint? _qid;

		// Token: 0x0400083A RID: 2106
		private IExtension extensionObject;
	}
}
