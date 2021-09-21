using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200017D RID: 381
	[ProtoContract(Name = "EnterWatchBattleArg")]
	[Serializable]
	public class EnterWatchBattleArg : IExtensible
	{
		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x0002E3B8 File Offset: 0x0002C5B8
		// (set) Token: 0x0600171D RID: 5917 RVA: 0x0002E3E4 File Offset: 0x0002C5E4
		[ProtoMember(1, IsRequired = false, Name = "liveID", DataFormat = DataFormat.TwosComplement)]
		public uint liveID
		{
			get
			{
				return this._liveID ?? 0U;
			}
			set
			{
				this._liveID = new uint?(value);
			}
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x0600171E RID: 5918 RVA: 0x0002E3F4 File Offset: 0x0002C5F4
		// (set) Token: 0x0600171F RID: 5919 RVA: 0x0002E414 File Offset: 0x0002C614
		[XmlIgnore]
		[Browsable(false)]
		public bool liveIDSpecified
		{
			get
			{
				return this._liveID != null;
			}
			set
			{
				bool flag = value == (this._liveID == null);
				if (flag)
				{
					this._liveID = (value ? new uint?(this.liveID) : null);
				}
			}
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x0002E458 File Offset: 0x0002C658
		private bool ShouldSerializeliveID()
		{
			return this.liveIDSpecified;
		}

		// Token: 0x06001721 RID: 5921 RVA: 0x0002E470 File Offset: 0x0002C670
		private void ResetliveID()
		{
			this.liveIDSpecified = false;
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x0002E47C File Offset: 0x0002C67C
		// (set) Token: 0x06001723 RID: 5923 RVA: 0x0002E4A8 File Offset: 0x0002C6A8
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LiveType type
		{
			get
			{
				return this._type ?? LiveType.LIVE_RECOMMEND;
			}
			set
			{
				this._type = new LiveType?(value);
			}
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x0002E4B8 File Offset: 0x0002C6B8
		// (set) Token: 0x06001725 RID: 5925 RVA: 0x0002E4D8 File Offset: 0x0002C6D8
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
					this._type = (value ? new LiveType?(this.type) : null);
				}
			}
		}

		// Token: 0x06001726 RID: 5926 RVA: 0x0002E51C File Offset: 0x0002C71C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001727 RID: 5927 RVA: 0x0002E534 File Offset: 0x0002C734
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x0002E540 File Offset: 0x0002C740
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005B7 RID: 1463
		private uint? _liveID;

		// Token: 0x040005B8 RID: 1464
		private LiveType? _type;

		// Token: 0x040005B9 RID: 1465
		private IExtension extensionObject;
	}
}
