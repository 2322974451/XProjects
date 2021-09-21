using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000652 RID: 1618
	[ProtoContract(Name = "LevelSealRecord")]
	[Serializable]
	public class LevelSealRecord : IExtensible
	{
		// Token: 0x17001FC1 RID: 8129
		// (get) Token: 0x060064A9 RID: 25769 RVA: 0x000C0230 File Offset: 0x000BE430
		// (set) Token: 0x060064AA RID: 25770 RVA: 0x000C025C File Offset: 0x000BE45C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17001FC2 RID: 8130
		// (get) Token: 0x060064AB RID: 25771 RVA: 0x000C026C File Offset: 0x000BE46C
		// (set) Token: 0x060064AC RID: 25772 RVA: 0x000C028C File Offset: 0x000BE48C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060064AD RID: 25773 RVA: 0x000C02D0 File Offset: 0x000BE4D0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060064AE RID: 25774 RVA: 0x000C02E8 File Offset: 0x000BE4E8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001FC3 RID: 8131
		// (get) Token: 0x060064AF RID: 25775 RVA: 0x000C02F4 File Offset: 0x000BE4F4
		// (set) Token: 0x060064B0 RID: 25776 RVA: 0x000C0320 File Offset: 0x000BE520
		[ProtoMember(2, IsRequired = false, Name = "selfCollectCount", DataFormat = DataFormat.TwosComplement)]
		public uint selfCollectCount
		{
			get
			{
				return this._selfCollectCount ?? 0U;
			}
			set
			{
				this._selfCollectCount = new uint?(value);
			}
		}

		// Token: 0x17001FC4 RID: 8132
		// (get) Token: 0x060064B1 RID: 25777 RVA: 0x000C0330 File Offset: 0x000BE530
		// (set) Token: 0x060064B2 RID: 25778 RVA: 0x000C0350 File Offset: 0x000BE550
		[XmlIgnore]
		[Browsable(false)]
		public bool selfCollectCountSpecified
		{
			get
			{
				return this._selfCollectCount != null;
			}
			set
			{
				bool flag = value == (this._selfCollectCount == null);
				if (flag)
				{
					this._selfCollectCount = (value ? new uint?(this.selfCollectCount) : null);
				}
			}
		}

		// Token: 0x060064B3 RID: 25779 RVA: 0x000C0394 File Offset: 0x000BE594
		private bool ShouldSerializeselfCollectCount()
		{
			return this.selfCollectCountSpecified;
		}

		// Token: 0x060064B4 RID: 25780 RVA: 0x000C03AC File Offset: 0x000BE5AC
		private void ResetselfCollectCount()
		{
			this.selfCollectCountSpecified = false;
		}

		// Token: 0x17001FC5 RID: 8133
		// (get) Token: 0x060064B5 RID: 25781 RVA: 0x000C03B8 File Offset: 0x000BE5B8
		// (set) Token: 0x060064B6 RID: 25782 RVA: 0x000C03E4 File Offset: 0x000BE5E4
		[ProtoMember(3, IsRequired = false, Name = "selfAwardCountIndex", DataFormat = DataFormat.TwosComplement)]
		public int selfAwardCountIndex
		{
			get
			{
				return this._selfAwardCountIndex ?? 0;
			}
			set
			{
				this._selfAwardCountIndex = new int?(value);
			}
		}

		// Token: 0x17001FC6 RID: 8134
		// (get) Token: 0x060064B7 RID: 25783 RVA: 0x000C03F4 File Offset: 0x000BE5F4
		// (set) Token: 0x060064B8 RID: 25784 RVA: 0x000C0414 File Offset: 0x000BE614
		[XmlIgnore]
		[Browsable(false)]
		public bool selfAwardCountIndexSpecified
		{
			get
			{
				return this._selfAwardCountIndex != null;
			}
			set
			{
				bool flag = value == (this._selfAwardCountIndex == null);
				if (flag)
				{
					this._selfAwardCountIndex = (value ? new int?(this.selfAwardCountIndex) : null);
				}
			}
		}

		// Token: 0x060064B9 RID: 25785 RVA: 0x000C0458 File Offset: 0x000BE658
		private bool ShouldSerializeselfAwardCountIndex()
		{
			return this.selfAwardCountIndexSpecified;
		}

		// Token: 0x060064BA RID: 25786 RVA: 0x000C0470 File Offset: 0x000BE670
		private void ResetselfAwardCountIndex()
		{
			this.selfAwardCountIndexSpecified = false;
		}

		// Token: 0x17001FC7 RID: 8135
		// (get) Token: 0x060064BB RID: 25787 RVA: 0x000C047C File Offset: 0x000BE67C
		// (set) Token: 0x060064BC RID: 25788 RVA: 0x000C04A8 File Offset: 0x000BE6A8
		[ProtoMember(4, IsRequired = false, Name = "LevelSealButtonStatus", DataFormat = DataFormat.TwosComplement)]
		public uint LevelSealButtonStatus
		{
			get
			{
				return this._LevelSealButtonStatus ?? 0U;
			}
			set
			{
				this._LevelSealButtonStatus = new uint?(value);
			}
		}

		// Token: 0x17001FC8 RID: 8136
		// (get) Token: 0x060064BD RID: 25789 RVA: 0x000C04B8 File Offset: 0x000BE6B8
		// (set) Token: 0x060064BE RID: 25790 RVA: 0x000C04D8 File Offset: 0x000BE6D8
		[XmlIgnore]
		[Browsable(false)]
		public bool LevelSealButtonStatusSpecified
		{
			get
			{
				return this._LevelSealButtonStatus != null;
			}
			set
			{
				bool flag = value == (this._LevelSealButtonStatus == null);
				if (flag)
				{
					this._LevelSealButtonStatus = (value ? new uint?(this.LevelSealButtonStatus) : null);
				}
			}
		}

		// Token: 0x060064BF RID: 25791 RVA: 0x000C051C File Offset: 0x000BE71C
		private bool ShouldSerializeLevelSealButtonStatus()
		{
			return this.LevelSealButtonStatusSpecified;
		}

		// Token: 0x060064C0 RID: 25792 RVA: 0x000C0534 File Offset: 0x000BE734
		private void ResetLevelSealButtonStatus()
		{
			this.LevelSealButtonStatusSpecified = false;
		}

		// Token: 0x17001FC9 RID: 8137
		// (get) Token: 0x060064C1 RID: 25793 RVA: 0x000C0540 File Offset: 0x000BE740
		// (set) Token: 0x060064C2 RID: 25794 RVA: 0x000C056C File Offset: 0x000BE76C
		[ProtoMember(5, IsRequired = false, Name = "lastLevelSealStatus", DataFormat = DataFormat.Default)]
		public bool lastLevelSealStatus
		{
			get
			{
				return this._lastLevelSealStatus ?? false;
			}
			set
			{
				this._lastLevelSealStatus = new bool?(value);
			}
		}

		// Token: 0x17001FCA RID: 8138
		// (get) Token: 0x060064C3 RID: 25795 RVA: 0x000C057C File Offset: 0x000BE77C
		// (set) Token: 0x060064C4 RID: 25796 RVA: 0x000C059C File Offset: 0x000BE79C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastLevelSealStatusSpecified
		{
			get
			{
				return this._lastLevelSealStatus != null;
			}
			set
			{
				bool flag = value == (this._lastLevelSealStatus == null);
				if (flag)
				{
					this._lastLevelSealStatus = (value ? new bool?(this.lastLevelSealStatus) : null);
				}
			}
		}

		// Token: 0x060064C5 RID: 25797 RVA: 0x000C05E0 File Offset: 0x000BE7E0
		private bool ShouldSerializelastLevelSealStatus()
		{
			return this.lastLevelSealStatusSpecified;
		}

		// Token: 0x060064C6 RID: 25798 RVA: 0x000C05F8 File Offset: 0x000BE7F8
		private void ResetlastLevelSealStatus()
		{
			this.lastLevelSealStatusSpecified = false;
		}

		// Token: 0x060064C7 RID: 25799 RVA: 0x000C0604 File Offset: 0x000BE804
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001868 RID: 6248
		private uint? _type;

		// Token: 0x04001869 RID: 6249
		private uint? _selfCollectCount;

		// Token: 0x0400186A RID: 6250
		private int? _selfAwardCountIndex;

		// Token: 0x0400186B RID: 6251
		private uint? _LevelSealButtonStatus;

		// Token: 0x0400186C RID: 6252
		private bool? _lastLevelSealStatus;

		// Token: 0x0400186D RID: 6253
		private IExtension extensionObject;
	}
}
