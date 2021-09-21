using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000347 RID: 839
	[ProtoContract(Name = "PandoraLotteryArg")]
	[Serializable]
	public class PandoraLotteryArg : IExtensible
	{
		// Token: 0x17000E3B RID: 3643
		// (get) Token: 0x06002DDD RID: 11741 RVA: 0x00058B8C File Offset: 0x00056D8C
		// (set) Token: 0x06002DDE RID: 11742 RVA: 0x00058BB8 File Offset: 0x00056DB8
		[ProtoMember(1, IsRequired = false, Name = "pandoraid", DataFormat = DataFormat.TwosComplement)]
		public uint pandoraid
		{
			get
			{
				return this._pandoraid ?? 0U;
			}
			set
			{
				this._pandoraid = new uint?(value);
			}
		}

		// Token: 0x17000E3C RID: 3644
		// (get) Token: 0x06002DDF RID: 11743 RVA: 0x00058BC8 File Offset: 0x00056DC8
		// (set) Token: 0x06002DE0 RID: 11744 RVA: 0x00058BE8 File Offset: 0x00056DE8
		[XmlIgnore]
		[Browsable(false)]
		public bool pandoraidSpecified
		{
			get
			{
				return this._pandoraid != null;
			}
			set
			{
				bool flag = value == (this._pandoraid == null);
				if (flag)
				{
					this._pandoraid = (value ? new uint?(this.pandoraid) : null);
				}
			}
		}

		// Token: 0x06002DE1 RID: 11745 RVA: 0x00058C2C File Offset: 0x00056E2C
		private bool ShouldSerializepandoraid()
		{
			return this.pandoraidSpecified;
		}

		// Token: 0x06002DE2 RID: 11746 RVA: 0x00058C44 File Offset: 0x00056E44
		private void Resetpandoraid()
		{
			this.pandoraidSpecified = false;
		}

		// Token: 0x17000E3D RID: 3645
		// (get) Token: 0x06002DE3 RID: 11747 RVA: 0x00058C50 File Offset: 0x00056E50
		// (set) Token: 0x06002DE4 RID: 11748 RVA: 0x00058C7C File Offset: 0x00056E7C
		[ProtoMember(2, IsRequired = false, Name = "isOneLottery", DataFormat = DataFormat.Default)]
		public bool isOneLottery
		{
			get
			{
				return this._isOneLottery ?? false;
			}
			set
			{
				this._isOneLottery = new bool?(value);
			}
		}

		// Token: 0x17000E3E RID: 3646
		// (get) Token: 0x06002DE5 RID: 11749 RVA: 0x00058C8C File Offset: 0x00056E8C
		// (set) Token: 0x06002DE6 RID: 11750 RVA: 0x00058CAC File Offset: 0x00056EAC
		[XmlIgnore]
		[Browsable(false)]
		public bool isOneLotterySpecified
		{
			get
			{
				return this._isOneLottery != null;
			}
			set
			{
				bool flag = value == (this._isOneLottery == null);
				if (flag)
				{
					this._isOneLottery = (value ? new bool?(this.isOneLottery) : null);
				}
			}
		}

		// Token: 0x06002DE7 RID: 11751 RVA: 0x00058CF0 File Offset: 0x00056EF0
		private bool ShouldSerializeisOneLottery()
		{
			return this.isOneLotterySpecified;
		}

		// Token: 0x06002DE8 RID: 11752 RVA: 0x00058D08 File Offset: 0x00056F08
		private void ResetisOneLottery()
		{
			this.isOneLotterySpecified = false;
		}

		// Token: 0x06002DE9 RID: 11753 RVA: 0x00058D14 File Offset: 0x00056F14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B68 RID: 2920
		private uint? _pandoraid;

		// Token: 0x04000B69 RID: 2921
		private bool? _isOneLottery;

		// Token: 0x04000B6A RID: 2922
		private IExtension extensionObject;
	}
}
