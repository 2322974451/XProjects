using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200013D RID: 317
	[ProtoContract(Name = "AnswerAckNtf")]
	[Serializable]
	public class AnswerAckNtf : IExtensible
	{
		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x06001347 RID: 4935 RVA: 0x00026FB0 File Offset: 0x000251B0
		// (set) Token: 0x06001348 RID: 4936 RVA: 0x00026FDD File Offset: 0x000251DD
		[ProtoMember(1, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
		public ulong roleId
		{
			get
			{
				return this._roleId ?? 0UL;
			}
			set
			{
				this._roleId = new ulong?(value);
			}
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06001349 RID: 4937 RVA: 0x00026FEC File Offset: 0x000251EC
		// (set) Token: 0x0600134A RID: 4938 RVA: 0x0002700C File Offset: 0x0002520C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIdSpecified
		{
			get
			{
				return this._roleId != null;
			}
			set
			{
				bool flag = value == (this._roleId == null);
				if (flag)
				{
					this._roleId = (value ? new ulong?(this.roleId) : null);
				}
			}
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x00027050 File Offset: 0x00025250
		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x00027068 File Offset: 0x00025268
		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x0600134D RID: 4941 RVA: 0x00027074 File Offset: 0x00025274
		// (set) Token: 0x0600134E RID: 4942 RVA: 0x00027095 File Offset: 0x00025295
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

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x0600134F RID: 4943 RVA: 0x000270A0 File Offset: 0x000252A0
		// (set) Token: 0x06001350 RID: 4944 RVA: 0x000270BC File Offset: 0x000252BC
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

		// Token: 0x06001351 RID: 4945 RVA: 0x000270EC File Offset: 0x000252EC
		private bool ShouldSerializeanswer()
		{
			return this.answerSpecified;
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x00027104 File Offset: 0x00025304
		private void Resetanswer()
		{
			this.answerSpecified = false;
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06001353 RID: 4947 RVA: 0x00027110 File Offset: 0x00025310
		// (set) Token: 0x06001354 RID: 4948 RVA: 0x0002713C File Offset: 0x0002533C
		[ProtoMember(3, IsRequired = false, Name = "correct", DataFormat = DataFormat.Default)]
		public bool correct
		{
			get
			{
				return this._correct ?? false;
			}
			set
			{
				this._correct = new bool?(value);
			}
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06001355 RID: 4949 RVA: 0x0002714C File Offset: 0x0002534C
		// (set) Token: 0x06001356 RID: 4950 RVA: 0x0002716C File Offset: 0x0002536C
		[XmlIgnore]
		[Browsable(false)]
		public bool correctSpecified
		{
			get
			{
				return this._correct != null;
			}
			set
			{
				bool flag = value == (this._correct == null);
				if (flag)
				{
					this._correct = (value ? new bool?(this.correct) : null);
				}
			}
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x000271B0 File Offset: 0x000253B0
		private bool ShouldSerializecorrect()
		{
			return this.correctSpecified;
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x000271C8 File Offset: 0x000253C8
		private void Resetcorrect()
		{
			this.correctSpecified = false;
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06001359 RID: 4953 RVA: 0x000271D4 File Offset: 0x000253D4
		// (set) Token: 0x0600135A RID: 4954 RVA: 0x00027200 File Offset: 0x00025400
		[ProtoMember(4, IsRequired = false, Name = "times", DataFormat = DataFormat.TwosComplement)]
		public uint times
		{
			get
			{
				return this._times ?? 0U;
			}
			set
			{
				this._times = new uint?(value);
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x0600135B RID: 4955 RVA: 0x00027210 File Offset: 0x00025410
		// (set) Token: 0x0600135C RID: 4956 RVA: 0x00027230 File Offset: 0x00025430
		[XmlIgnore]
		[Browsable(false)]
		public bool timesSpecified
		{
			get
			{
				return this._times != null;
			}
			set
			{
				bool flag = value == (this._times == null);
				if (flag)
				{
					this._times = (value ? new uint?(this.times) : null);
				}
			}
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00027274 File Offset: 0x00025474
		private bool ShouldSerializetimes()
		{
			return this.timesSpecified;
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x0002728C File Offset: 0x0002548C
		private void Resettimes()
		{
			this.timesSpecified = false;
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x0600135F RID: 4959 RVA: 0x00027298 File Offset: 0x00025498
		// (set) Token: 0x06001360 RID: 4960 RVA: 0x000272C4 File Offset: 0x000254C4
		[ProtoMember(5, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06001361 RID: 4961 RVA: 0x000272D4 File Offset: 0x000254D4
		// (set) Token: 0x06001362 RID: 4962 RVA: 0x000272F4 File Offset: 0x000254F4
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x00027338 File Offset: 0x00025538
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x00027350 File Offset: 0x00025550
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06001365 RID: 4965 RVA: 0x0002735C File Offset: 0x0002555C
		// (set) Token: 0x06001366 RID: 4966 RVA: 0x00027389 File Offset: 0x00025589
		[ProtoMember(6, IsRequired = false, Name = "audioUid", DataFormat = DataFormat.TwosComplement)]
		public ulong audioUid
		{
			get
			{
				return this._audioUid ?? 0UL;
			}
			set
			{
				this._audioUid = new ulong?(value);
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06001367 RID: 4967 RVA: 0x00027398 File Offset: 0x00025598
		// (set) Token: 0x06001368 RID: 4968 RVA: 0x000273B8 File Offset: 0x000255B8
		[XmlIgnore]
		[Browsable(false)]
		public bool audioUidSpecified
		{
			get
			{
				return this._audioUid != null;
			}
			set
			{
				bool flag = value == (this._audioUid == null);
				if (flag)
				{
					this._audioUid = (value ? new ulong?(this.audioUid) : null);
				}
			}
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x000273FC File Offset: 0x000255FC
		private bool ShouldSerializeaudioUid()
		{
			return this.audioUidSpecified;
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x00027414 File Offset: 0x00025614
		private void ResetaudioUid()
		{
			this.audioUidSpecified = false;
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x00027420 File Offset: 0x00025620
		// (set) Token: 0x0600136C RID: 4972 RVA: 0x0002744C File Offset: 0x0002564C
		[ProtoMember(7, IsRequired = false, Name = "answertime", DataFormat = DataFormat.TwosComplement)]
		public uint answertime
		{
			get
			{
				return this._answertime ?? 0U;
			}
			set
			{
				this._answertime = new uint?(value);
			}
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x0002745C File Offset: 0x0002565C
		// (set) Token: 0x0600136E RID: 4974 RVA: 0x0002747C File Offset: 0x0002567C
		[XmlIgnore]
		[Browsable(false)]
		public bool answertimeSpecified
		{
			get
			{
				return this._answertime != null;
			}
			set
			{
				bool flag = value == (this._answertime == null);
				if (flag)
				{
					this._answertime = (value ? new uint?(this.answertime) : null);
				}
			}
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x000274C0 File Offset: 0x000256C0
		private bool ShouldSerializeanswertime()
		{
			return this.answertimeSpecified;
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x000274D8 File Offset: 0x000256D8
		private void Resetanswertime()
		{
			this.answertimeSpecified = false;
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06001371 RID: 4977 RVA: 0x000274E4 File Offset: 0x000256E4
		// (set) Token: 0x06001372 RID: 4978 RVA: 0x00027505 File Offset: 0x00025705
		[ProtoMember(8, IsRequired = false, Name = "userName", DataFormat = DataFormat.Default)]
		public string userName
		{
			get
			{
				return this._userName ?? "";
			}
			set
			{
				this._userName = value;
			}
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x06001373 RID: 4979 RVA: 0x00027510 File Offset: 0x00025710
		// (set) Token: 0x06001374 RID: 4980 RVA: 0x0002752C File Offset: 0x0002572C
		[XmlIgnore]
		[Browsable(false)]
		public bool userNameSpecified
		{
			get
			{
				return this._userName != null;
			}
			set
			{
				bool flag = value == (this._userName == null);
				if (flag)
				{
					this._userName = (value ? this.userName : null);
				}
			}
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x0002755C File Offset: 0x0002575C
		private bool ShouldSerializeuserName()
		{
			return this.userNameSpecified;
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x00027574 File Offset: 0x00025774
		private void ResetuserName()
		{
			this.userNameSpecified = false;
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x06001377 RID: 4983 RVA: 0x00027580 File Offset: 0x00025780
		// (set) Token: 0x06001378 RID: 4984 RVA: 0x000275AC File Offset: 0x000257AC
		[ProtoMember(9, IsRequired = false, Name = "coverDesignationId", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationId
		{
			get
			{
				return this._coverDesignationId ?? 0U;
			}
			set
			{
				this._coverDesignationId = new uint?(value);
			}
		}

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06001379 RID: 4985 RVA: 0x000275BC File Offset: 0x000257BC
		// (set) Token: 0x0600137A RID: 4986 RVA: 0x000275DC File Offset: 0x000257DC
		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIdSpecified
		{
			get
			{
				return this._coverDesignationId != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationId == null);
				if (flag)
				{
					this._coverDesignationId = (value ? new uint?(this.coverDesignationId) : null);
				}
			}
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x00027620 File Offset: 0x00025820
		private bool ShouldSerializecoverDesignationId()
		{
			return this.coverDesignationIdSpecified;
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00027638 File Offset: 0x00025838
		private void ResetcoverDesignationId()
		{
			this.coverDesignationIdSpecified = false;
		}

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x0600137D RID: 4989 RVA: 0x00027644 File Offset: 0x00025844
		// (set) Token: 0x0600137E RID: 4990 RVA: 0x00027670 File Offset: 0x00025870
		[ProtoMember(10, IsRequired = false, Name = "audioTime", DataFormat = DataFormat.TwosComplement)]
		public uint audioTime
		{
			get
			{
				return this._audioTime ?? 0U;
			}
			set
			{
				this._audioTime = new uint?(value);
			}
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x0600137F RID: 4991 RVA: 0x00027680 File Offset: 0x00025880
		// (set) Token: 0x06001380 RID: 4992 RVA: 0x000276A0 File Offset: 0x000258A0
		[XmlIgnore]
		[Browsable(false)]
		public bool audioTimeSpecified
		{
			get
			{
				return this._audioTime != null;
			}
			set
			{
				bool flag = value == (this._audioTime == null);
				if (flag)
				{
					this._audioTime = (value ? new uint?(this.audioTime) : null);
				}
			}
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x000276E4 File Offset: 0x000258E4
		private bool ShouldSerializeaudioTime()
		{
			return this.audioTimeSpecified;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x000276FC File Offset: 0x000258FC
		private void ResetaudioTime()
		{
			this.audioTimeSpecified = false;
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06001383 RID: 4995 RVA: 0x00027708 File Offset: 0x00025908
		// (set) Token: 0x06001384 RID: 4996 RVA: 0x00027734 File Offset: 0x00025934
		[ProtoMember(11, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06001385 RID: 4997 RVA: 0x00027744 File Offset: 0x00025944
		// (set) Token: 0x06001386 RID: 4998 RVA: 0x00027764 File Offset: 0x00025964
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x000277A8 File Offset: 0x000259A8
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x000277C0 File Offset: 0x000259C0
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x000277CC File Offset: 0x000259CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004CF RID: 1231
		private ulong? _roleId;

		// Token: 0x040004D0 RID: 1232
		private string _answer;

		// Token: 0x040004D1 RID: 1233
		private bool? _correct;

		// Token: 0x040004D2 RID: 1234
		private uint? _times;

		// Token: 0x040004D3 RID: 1235
		private uint? _rank;

		// Token: 0x040004D4 RID: 1236
		private ulong? _audioUid;

		// Token: 0x040004D5 RID: 1237
		private uint? _answertime;

		// Token: 0x040004D6 RID: 1238
		private string _userName;

		// Token: 0x040004D7 RID: 1239
		private uint? _coverDesignationId;

		// Token: 0x040004D8 RID: 1240
		private uint? _audioTime;

		// Token: 0x040004D9 RID: 1241
		private uint? _profession;

		// Token: 0x040004DA RID: 1242
		private IExtension extensionObject;
	}
}
