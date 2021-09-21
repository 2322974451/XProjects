using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200061D RID: 1565
	[ProtoContract(Name = "LiveRecord")]
	[Serializable]
	public class LiveRecord : IExtensible
	{
		// Token: 0x17001DEF RID: 7663
		// (get) Token: 0x06005F45 RID: 24389 RVA: 0x000B5B78 File Offset: 0x000B3D78
		// (set) Token: 0x06005F46 RID: 24390 RVA: 0x000B5B90 File Offset: 0x000B3D90
		[ProtoMember(1, IsRequired = false, Name = "mostViewedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo mostViewedRecord
		{
			get
			{
				return this._mostViewedRecord;
			}
			set
			{
				this._mostViewedRecord = value;
			}
		}

		// Token: 0x17001DF0 RID: 7664
		// (get) Token: 0x06005F47 RID: 24391 RVA: 0x000B5B9C File Offset: 0x000B3D9C
		// (set) Token: 0x06005F48 RID: 24392 RVA: 0x000B5BB4 File Offset: 0x000B3DB4
		[ProtoMember(2, IsRequired = false, Name = "mostCommendedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo mostCommendedRecord
		{
			get
			{
				return this._mostCommendedRecord;
			}
			set
			{
				this._mostCommendedRecord = value;
			}
		}

		// Token: 0x17001DF1 RID: 7665
		// (get) Token: 0x06005F49 RID: 24393 RVA: 0x000B5BC0 File Offset: 0x000B3DC0
		[ProtoMember(3, Name = "recentRecords", DataFormat = DataFormat.Default)]
		public List<OneLiveRecordInfo> recentRecords
		{
			get
			{
				return this._recentRecords;
			}
		}

		// Token: 0x17001DF2 RID: 7666
		// (get) Token: 0x06005F4A RID: 24394 RVA: 0x000B5BD8 File Offset: 0x000B3DD8
		// (set) Token: 0x06005F4B RID: 24395 RVA: 0x000B5C04 File Offset: 0x000B3E04
		[ProtoMember(4, IsRequired = false, Name = "myTotalCommendedNum", DataFormat = DataFormat.TwosComplement)]
		public uint myTotalCommendedNum
		{
			get
			{
				return this._myTotalCommendedNum ?? 0U;
			}
			set
			{
				this._myTotalCommendedNum = new uint?(value);
			}
		}

		// Token: 0x17001DF3 RID: 7667
		// (get) Token: 0x06005F4C RID: 24396 RVA: 0x000B5C14 File Offset: 0x000B3E14
		// (set) Token: 0x06005F4D RID: 24397 RVA: 0x000B5C34 File Offset: 0x000B3E34
		[XmlIgnore]
		[Browsable(false)]
		public bool myTotalCommendedNumSpecified
		{
			get
			{
				return this._myTotalCommendedNum != null;
			}
			set
			{
				bool flag = value == (this._myTotalCommendedNum == null);
				if (flag)
				{
					this._myTotalCommendedNum = (value ? new uint?(this.myTotalCommendedNum) : null);
				}
			}
		}

		// Token: 0x06005F4E RID: 24398 RVA: 0x000B5C78 File Offset: 0x000B3E78
		private bool ShouldSerializemyTotalCommendedNum()
		{
			return this.myTotalCommendedNumSpecified;
		}

		// Token: 0x06005F4F RID: 24399 RVA: 0x000B5C90 File Offset: 0x000B3E90
		private void ResetmyTotalCommendedNum()
		{
			this.myTotalCommendedNumSpecified = false;
		}

		// Token: 0x17001DF4 RID: 7668
		// (get) Token: 0x06005F50 RID: 24400 RVA: 0x000B5C9C File Offset: 0x000B3E9C
		// (set) Token: 0x06005F51 RID: 24401 RVA: 0x000B5CC8 File Offset: 0x000B3EC8
		[ProtoMember(5, IsRequired = false, Name = "myTotalViewedNum", DataFormat = DataFormat.TwosComplement)]
		public uint myTotalViewedNum
		{
			get
			{
				return this._myTotalViewedNum ?? 0U;
			}
			set
			{
				this._myTotalViewedNum = new uint?(value);
			}
		}

		// Token: 0x17001DF5 RID: 7669
		// (get) Token: 0x06005F52 RID: 24402 RVA: 0x000B5CD8 File Offset: 0x000B3ED8
		// (set) Token: 0x06005F53 RID: 24403 RVA: 0x000B5CF8 File Offset: 0x000B3EF8
		[XmlIgnore]
		[Browsable(false)]
		public bool myTotalViewedNumSpecified
		{
			get
			{
				return this._myTotalViewedNum != null;
			}
			set
			{
				bool flag = value == (this._myTotalViewedNum == null);
				if (flag)
				{
					this._myTotalViewedNum = (value ? new uint?(this.myTotalViewedNum) : null);
				}
			}
		}

		// Token: 0x06005F54 RID: 24404 RVA: 0x000B5D3C File Offset: 0x000B3F3C
		private bool ShouldSerializemyTotalViewedNum()
		{
			return this.myTotalViewedNumSpecified;
		}

		// Token: 0x06005F55 RID: 24405 RVA: 0x000B5D54 File Offset: 0x000B3F54
		private void ResetmyTotalViewedNum()
		{
			this.myTotalViewedNumSpecified = false;
		}

		// Token: 0x17001DF6 RID: 7670
		// (get) Token: 0x06005F56 RID: 24406 RVA: 0x000B5D60 File Offset: 0x000B3F60
		// (set) Token: 0x06005F57 RID: 24407 RVA: 0x000B5D8C File Offset: 0x000B3F8C
		[ProtoMember(6, IsRequired = false, Name = "livevisible", DataFormat = DataFormat.Default)]
		public bool livevisible
		{
			get
			{
				return this._livevisible ?? false;
			}
			set
			{
				this._livevisible = new bool?(value);
			}
		}

		// Token: 0x17001DF7 RID: 7671
		// (get) Token: 0x06005F58 RID: 24408 RVA: 0x000B5D9C File Offset: 0x000B3F9C
		// (set) Token: 0x06005F59 RID: 24409 RVA: 0x000B5DBC File Offset: 0x000B3FBC
		[XmlIgnore]
		[Browsable(false)]
		public bool livevisibleSpecified
		{
			get
			{
				return this._livevisible != null;
			}
			set
			{
				bool flag = value == (this._livevisible == null);
				if (flag)
				{
					this._livevisible = (value ? new bool?(this.livevisible) : null);
				}
			}
		}

		// Token: 0x06005F5A RID: 24410 RVA: 0x000B5E00 File Offset: 0x000B4000
		private bool ShouldSerializelivevisible()
		{
			return this.livevisibleSpecified;
		}

		// Token: 0x06005F5B RID: 24411 RVA: 0x000B5E18 File Offset: 0x000B4018
		private void Resetlivevisible()
		{
			this.livevisibleSpecified = false;
		}

		// Token: 0x06005F5C RID: 24412 RVA: 0x000B5E24 File Offset: 0x000B4024
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001724 RID: 5924
		private OneLiveRecordInfo _mostViewedRecord = null;

		// Token: 0x04001725 RID: 5925
		private OneLiveRecordInfo _mostCommendedRecord = null;

		// Token: 0x04001726 RID: 5926
		private readonly List<OneLiveRecordInfo> _recentRecords = new List<OneLiveRecordInfo>();

		// Token: 0x04001727 RID: 5927
		private uint? _myTotalCommendedNum;

		// Token: 0x04001728 RID: 5928
		private uint? _myTotalViewedNum;

		// Token: 0x04001729 RID: 5929
		private bool? _livevisible;

		// Token: 0x0400172A RID: 5930
		private IExtension extensionObject;
	}
}
