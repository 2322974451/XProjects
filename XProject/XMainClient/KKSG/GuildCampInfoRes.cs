using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002BB RID: 699
	[ProtoContract(Name = "GuildCampInfoRes")]
	[Serializable]
	public class GuildCampInfoRes : IExtensible
	{
		// Token: 0x17000C13 RID: 3091
		// (get) Token: 0x060026D2 RID: 9938 RVA: 0x0004B86C File Offset: 0x00049A6C
		// (set) Token: 0x060026D3 RID: 9939 RVA: 0x0004B898 File Offset: 0x00049A98
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

		// Token: 0x17000C14 RID: 3092
		// (get) Token: 0x060026D4 RID: 9940 RVA: 0x0004B8A8 File Offset: 0x00049AA8
		// (set) Token: 0x060026D5 RID: 9941 RVA: 0x0004B8C8 File Offset: 0x00049AC8
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

		// Token: 0x060026D6 RID: 9942 RVA: 0x0004B90C File Offset: 0x00049B0C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060026D7 RID: 9943 RVA: 0x0004B924 File Offset: 0x00049B24
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000C15 RID: 3093
		// (get) Token: 0x060026D8 RID: 9944 RVA: 0x0004B930 File Offset: 0x00049B30
		[ProtoMember(2, Name = "rankInfos", DataFormat = DataFormat.Default)]
		public List<GuildCampRankInfo> rankInfos
		{
			get
			{
				return this._rankInfos;
			}
		}

		// Token: 0x17000C16 RID: 3094
		// (get) Token: 0x060026D9 RID: 9945 RVA: 0x0004B948 File Offset: 0x00049B48
		// (set) Token: 0x060026DA RID: 9946 RVA: 0x0004B974 File Offset: 0x00049B74
		[ProtoMember(3, IsRequired = false, Name = "curCampID", DataFormat = DataFormat.TwosComplement)]
		public int curCampID
		{
			get
			{
				return this._curCampID ?? 0;
			}
			set
			{
				this._curCampID = new int?(value);
			}
		}

		// Token: 0x17000C17 RID: 3095
		// (get) Token: 0x060026DB RID: 9947 RVA: 0x0004B984 File Offset: 0x00049B84
		// (set) Token: 0x060026DC RID: 9948 RVA: 0x0004B9A4 File Offset: 0x00049BA4
		[XmlIgnore]
		[Browsable(false)]
		public bool curCampIDSpecified
		{
			get
			{
				return this._curCampID != null;
			}
			set
			{
				bool flag = value == (this._curCampID == null);
				if (flag)
				{
					this._curCampID = (value ? new int?(this.curCampID) : null);
				}
			}
		}

		// Token: 0x060026DD RID: 9949 RVA: 0x0004B9E8 File Offset: 0x00049BE8
		private bool ShouldSerializecurCampID()
		{
			return this.curCampIDSpecified;
		}

		// Token: 0x060026DE RID: 9950 RVA: 0x0004BA00 File Offset: 0x00049C00
		private void ResetcurCampID()
		{
			this.curCampIDSpecified = false;
		}

		// Token: 0x17000C18 RID: 3096
		// (get) Token: 0x060026DF RID: 9951 RVA: 0x0004BA0C File Offset: 0x00049C0C
		// (set) Token: 0x060026E0 RID: 9952 RVA: 0x0004BA38 File Offset: 0x00049C38
		[ProtoMember(4, IsRequired = false, Name = "nextCampID", DataFormat = DataFormat.TwosComplement)]
		public int nextCampID
		{
			get
			{
				return this._nextCampID ?? 0;
			}
			set
			{
				this._nextCampID = new int?(value);
			}
		}

		// Token: 0x17000C19 RID: 3097
		// (get) Token: 0x060026E1 RID: 9953 RVA: 0x0004BA48 File Offset: 0x00049C48
		// (set) Token: 0x060026E2 RID: 9954 RVA: 0x0004BA68 File Offset: 0x00049C68
		[XmlIgnore]
		[Browsable(false)]
		public bool nextCampIDSpecified
		{
			get
			{
				return this._nextCampID != null;
			}
			set
			{
				bool flag = value == (this._nextCampID == null);
				if (flag)
				{
					this._nextCampID = (value ? new int?(this.nextCampID) : null);
				}
			}
		}

		// Token: 0x060026E3 RID: 9955 RVA: 0x0004BAAC File Offset: 0x00049CAC
		private bool ShouldSerializenextCampID()
		{
			return this.nextCampIDSpecified;
		}

		// Token: 0x060026E4 RID: 9956 RVA: 0x0004BAC4 File Offset: 0x00049CC4
		private void ResetnextCampID()
		{
			this.nextCampIDSpecified = false;
		}

		// Token: 0x17000C1A RID: 3098
		// (get) Token: 0x060026E5 RID: 9957 RVA: 0x0004BAD0 File Offset: 0x00049CD0
		// (set) Token: 0x060026E6 RID: 9958 RVA: 0x0004BAFC File Offset: 0x00049CFC
		[ProtoMember(5, IsRequired = false, Name = "leftCount", DataFormat = DataFormat.TwosComplement)]
		public int leftCount
		{
			get
			{
				return this._leftCount ?? 0;
			}
			set
			{
				this._leftCount = new int?(value);
			}
		}

		// Token: 0x17000C1B RID: 3099
		// (get) Token: 0x060026E7 RID: 9959 RVA: 0x0004BB0C File Offset: 0x00049D0C
		// (set) Token: 0x060026E8 RID: 9960 RVA: 0x0004BB2C File Offset: 0x00049D2C
		[XmlIgnore]
		[Browsable(false)]
		public bool leftCountSpecified
		{
			get
			{
				return this._leftCount != null;
			}
			set
			{
				bool flag = value == (this._leftCount == null);
				if (flag)
				{
					this._leftCount = (value ? new int?(this.leftCount) : null);
				}
			}
		}

		// Token: 0x060026E9 RID: 9961 RVA: 0x0004BB70 File Offset: 0x00049D70
		private bool ShouldSerializeleftCount()
		{
			return this.leftCountSpecified;
		}

		// Token: 0x060026EA RID: 9962 RVA: 0x0004BB88 File Offset: 0x00049D88
		private void ResetleftCount()
		{
			this.leftCountSpecified = false;
		}

		// Token: 0x060026EB RID: 9963 RVA: 0x0004BB94 File Offset: 0x00049D94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009A4 RID: 2468
		private ErrorCode? _error;

		// Token: 0x040009A5 RID: 2469
		private readonly List<GuildCampRankInfo> _rankInfos = new List<GuildCampRankInfo>();

		// Token: 0x040009A6 RID: 2470
		private int? _curCampID;

		// Token: 0x040009A7 RID: 2471
		private int? _nextCampID;

		// Token: 0x040009A8 RID: 2472
		private int? _leftCount;

		// Token: 0x040009A9 RID: 2473
		private IExtension extensionObject;
	}
}
