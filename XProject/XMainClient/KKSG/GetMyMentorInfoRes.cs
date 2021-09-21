using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200030B RID: 779
	[ProtoContract(Name = "GetMyMentorInfoRes")]
	[Serializable]
	public class GetMyMentorInfoRes : IExtensible
	{
		// Token: 0x17000D2E RID: 3374
		// (get) Token: 0x06002A8D RID: 10893 RVA: 0x00052778 File Offset: 0x00050978
		// (set) Token: 0x06002A8E RID: 10894 RVA: 0x000527A4 File Offset: 0x000509A4
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

		// Token: 0x17000D2F RID: 3375
		// (get) Token: 0x06002A8F RID: 10895 RVA: 0x000527B4 File Offset: 0x000509B4
		// (set) Token: 0x06002A90 RID: 10896 RVA: 0x000527D4 File Offset: 0x000509D4
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

		// Token: 0x06002A91 RID: 10897 RVA: 0x00052818 File Offset: 0x00050A18
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002A92 RID: 10898 RVA: 0x00052830 File Offset: 0x00050A30
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000D30 RID: 3376
		// (get) Token: 0x06002A93 RID: 10899 RVA: 0x0005283C File Offset: 0x00050A3C
		[ProtoMember(2, Name = "mentorRelationList", DataFormat = DataFormat.Default)]
		public List<OneMentorRelationInfo2Client> mentorRelationList
		{
			get
			{
				return this._mentorRelationList;
			}
		}

		// Token: 0x17000D31 RID: 3377
		// (get) Token: 0x06002A94 RID: 10900 RVA: 0x00052854 File Offset: 0x00050A54
		// (set) Token: 0x06002A95 RID: 10901 RVA: 0x0005286C File Offset: 0x00050A6C
		[ProtoMember(3, IsRequired = false, Name = "mentorSelfInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MentorSelfInfo mentorSelfInfo
		{
			get
			{
				return this._mentorSelfInfo;
			}
			set
			{
				this._mentorSelfInfo = value;
			}
		}

		// Token: 0x17000D32 RID: 3378
		// (get) Token: 0x06002A96 RID: 10902 RVA: 0x00052878 File Offset: 0x00050A78
		// (set) Token: 0x06002A97 RID: 10903 RVA: 0x000528A4 File Offset: 0x00050AA4
		[ProtoMember(4, IsRequired = false, Name = "curTime", DataFormat = DataFormat.TwosComplement)]
		public int curTime
		{
			get
			{
				return this._curTime ?? 0;
			}
			set
			{
				this._curTime = new int?(value);
			}
		}

		// Token: 0x17000D33 RID: 3379
		// (get) Token: 0x06002A98 RID: 10904 RVA: 0x000528B4 File Offset: 0x00050AB4
		// (set) Token: 0x06002A99 RID: 10905 RVA: 0x000528D4 File Offset: 0x00050AD4
		[XmlIgnore]
		[Browsable(false)]
		public bool curTimeSpecified
		{
			get
			{
				return this._curTime != null;
			}
			set
			{
				bool flag = value == (this._curTime == null);
				if (flag)
				{
					this._curTime = (value ? new int?(this.curTime) : null);
				}
			}
		}

		// Token: 0x06002A9A RID: 10906 RVA: 0x00052918 File Offset: 0x00050B18
		private bool ShouldSerializecurTime()
		{
			return this.curTimeSpecified;
		}

		// Token: 0x06002A9B RID: 10907 RVA: 0x00052930 File Offset: 0x00050B30
		private void ResetcurTime()
		{
			this.curTimeSpecified = false;
		}

		// Token: 0x17000D34 RID: 3380
		// (get) Token: 0x06002A9C RID: 10908 RVA: 0x0005293C File Offset: 0x00050B3C
		// (set) Token: 0x06002A9D RID: 10909 RVA: 0x00052969 File Offset: 0x00050B69
		[ProtoMember(5, IsRequired = false, Name = "audioID", DataFormat = DataFormat.TwosComplement)]
		public ulong audioID
		{
			get
			{
				return this._audioID ?? 0UL;
			}
			set
			{
				this._audioID = new ulong?(value);
			}
		}

		// Token: 0x17000D35 RID: 3381
		// (get) Token: 0x06002A9E RID: 10910 RVA: 0x00052978 File Offset: 0x00050B78
		// (set) Token: 0x06002A9F RID: 10911 RVA: 0x00052998 File Offset: 0x00050B98
		[XmlIgnore]
		[Browsable(false)]
		public bool audioIDSpecified
		{
			get
			{
				return this._audioID != null;
			}
			set
			{
				bool flag = value == (this._audioID == null);
				if (flag)
				{
					this._audioID = (value ? new ulong?(this.audioID) : null);
				}
			}
		}

		// Token: 0x06002AA0 RID: 10912 RVA: 0x000529DC File Offset: 0x00050BDC
		private bool ShouldSerializeaudioID()
		{
			return this.audioIDSpecified;
		}

		// Token: 0x06002AA1 RID: 10913 RVA: 0x000529F4 File Offset: 0x00050BF4
		private void ResetaudioID()
		{
			this.audioIDSpecified = false;
		}

		// Token: 0x17000D36 RID: 3382
		// (get) Token: 0x06002AA2 RID: 10914 RVA: 0x00052A00 File Offset: 0x00050C00
		// (set) Token: 0x06002AA3 RID: 10915 RVA: 0x00052A21 File Offset: 0x00050C21
		[ProtoMember(6, IsRequired = false, Name = "mentorWords", DataFormat = DataFormat.Default)]
		public string mentorWords
		{
			get
			{
				return this._mentorWords ?? "";
			}
			set
			{
				this._mentorWords = value;
			}
		}

		// Token: 0x17000D37 RID: 3383
		// (get) Token: 0x06002AA4 RID: 10916 RVA: 0x00052A2C File Offset: 0x00050C2C
		// (set) Token: 0x06002AA5 RID: 10917 RVA: 0x00052A48 File Offset: 0x00050C48
		[XmlIgnore]
		[Browsable(false)]
		public bool mentorWordsSpecified
		{
			get
			{
				return this._mentorWords != null;
			}
			set
			{
				bool flag = value == (this._mentorWords == null);
				if (flag)
				{
					this._mentorWords = (value ? this.mentorWords : null);
				}
			}
		}

		// Token: 0x06002AA6 RID: 10918 RVA: 0x00052A78 File Offset: 0x00050C78
		private bool ShouldSerializementorWords()
		{
			return this.mentorWordsSpecified;
		}

		// Token: 0x06002AA7 RID: 10919 RVA: 0x00052A90 File Offset: 0x00050C90
		private void ResetmentorWords()
		{
			this.mentorWordsSpecified = false;
		}

		// Token: 0x17000D38 RID: 3384
		// (get) Token: 0x06002AA8 RID: 10920 RVA: 0x00052A9C File Offset: 0x00050C9C
		// (set) Token: 0x06002AA9 RID: 10921 RVA: 0x00052AC8 File Offset: 0x00050CC8
		[ProtoMember(7, IsRequired = false, Name = "isNeedStudent", DataFormat = DataFormat.Default)]
		public bool isNeedStudent
		{
			get
			{
				return this._isNeedStudent ?? false;
			}
			set
			{
				this._isNeedStudent = new bool?(value);
			}
		}

		// Token: 0x17000D39 RID: 3385
		// (get) Token: 0x06002AAA RID: 10922 RVA: 0x00052AD8 File Offset: 0x00050CD8
		// (set) Token: 0x06002AAB RID: 10923 RVA: 0x00052AF8 File Offset: 0x00050CF8
		[XmlIgnore]
		[Browsable(false)]
		public bool isNeedStudentSpecified
		{
			get
			{
				return this._isNeedStudent != null;
			}
			set
			{
				bool flag = value == (this._isNeedStudent == null);
				if (flag)
				{
					this._isNeedStudent = (value ? new bool?(this.isNeedStudent) : null);
				}
			}
		}

		// Token: 0x06002AAC RID: 10924 RVA: 0x00052B3C File Offset: 0x00050D3C
		private bool ShouldSerializeisNeedStudent()
		{
			return this.isNeedStudentSpecified;
		}

		// Token: 0x06002AAD RID: 10925 RVA: 0x00052B54 File Offset: 0x00050D54
		private void ResetisNeedStudent()
		{
			this.isNeedStudentSpecified = false;
		}

		// Token: 0x06002AAE RID: 10926 RVA: 0x00052B60 File Offset: 0x00050D60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A90 RID: 2704
		private ErrorCode? _error;

		// Token: 0x04000A91 RID: 2705
		private readonly List<OneMentorRelationInfo2Client> _mentorRelationList = new List<OneMentorRelationInfo2Client>();

		// Token: 0x04000A92 RID: 2706
		private MentorSelfInfo _mentorSelfInfo = null;

		// Token: 0x04000A93 RID: 2707
		private int? _curTime;

		// Token: 0x04000A94 RID: 2708
		private ulong? _audioID;

		// Token: 0x04000A95 RID: 2709
		private string _mentorWords;

		// Token: 0x04000A96 RID: 2710
		private bool? _isNeedStudent;

		// Token: 0x04000A97 RID: 2711
		private IExtension extensionObject;
	}
}
