using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200018C RID: 396
	[ProtoContract(Name = "WatchBattleData")]
	[Serializable]
	public class WatchBattleData : IExtensible
	{
		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x060017FF RID: 6143 RVA: 0x0002FDE8 File Offset: 0x0002DFE8
		// (set) Token: 0x06001800 RID: 6144 RVA: 0x0002FE14 File Offset: 0x0002E014
		[ProtoMember(1, IsRequired = false, Name = "watchNum", DataFormat = DataFormat.TwosComplement)]
		public int watchNum
		{
			get
			{
				return this._watchNum ?? 0;
			}
			set
			{
				this._watchNum = new int?(value);
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06001801 RID: 6145 RVA: 0x0002FE24 File Offset: 0x0002E024
		// (set) Token: 0x06001802 RID: 6146 RVA: 0x0002FE44 File Offset: 0x0002E044
		[XmlIgnore]
		[Browsable(false)]
		public bool watchNumSpecified
		{
			get
			{
				return this._watchNum != null;
			}
			set
			{
				bool flag = value == (this._watchNum == null);
				if (flag)
				{
					this._watchNum = (value ? new int?(this.watchNum) : null);
				}
			}
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x0002FE88 File Offset: 0x0002E088
		private bool ShouldSerializewatchNum()
		{
			return this.watchNumSpecified;
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x0002FEA0 File Offset: 0x0002E0A0
		private void ResetwatchNum()
		{
			this.watchNumSpecified = false;
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06001805 RID: 6149 RVA: 0x0002FEAC File Offset: 0x0002E0AC
		// (set) Token: 0x06001806 RID: 6150 RVA: 0x0002FED8 File Offset: 0x0002E0D8
		[ProtoMember(2, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06001807 RID: 6151 RVA: 0x0002FEE8 File Offset: 0x0002E0E8
		// (set) Token: 0x06001808 RID: 6152 RVA: 0x0002FF08 File Offset: 0x0002E108
		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0002FF4C File Offset: 0x0002E14C
		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		// Token: 0x0600180A RID: 6154 RVA: 0x0002FF64 File Offset: 0x0002E164
		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0002FF70 File Offset: 0x0002E170
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005ED RID: 1517
		private int? _watchNum;

		// Token: 0x040005EE RID: 1518
		private int? _commendNum;

		// Token: 0x040005EF RID: 1519
		private IExtension extensionObject;
	}
}
