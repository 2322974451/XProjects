using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000422 RID: 1058
	[ProtoContract(Name = "HeroKillNotifyData")]
	[Serializable]
	public class HeroKillNotifyData : IExtensible
	{
		// Token: 0x1700113B RID: 4411
		// (get) Token: 0x0600381E RID: 14366 RVA: 0x0006B6F4 File Offset: 0x000698F4
		// (set) Token: 0x0600381F RID: 14367 RVA: 0x0006B70C File Offset: 0x0006990C
		[ProtoMember(1, IsRequired = false, Name = "killer", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroKillUnit killer
		{
			get
			{
				return this._killer;
			}
			set
			{
				this._killer = value;
			}
		}

		// Token: 0x1700113C RID: 4412
		// (get) Token: 0x06003820 RID: 14368 RVA: 0x0006B718 File Offset: 0x00069918
		// (set) Token: 0x06003821 RID: 14369 RVA: 0x0006B730 File Offset: 0x00069930
		[ProtoMember(2, IsRequired = false, Name = "dead", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroKillUnit dead
		{
			get
			{
				return this._dead;
			}
			set
			{
				this._dead = value;
			}
		}

		// Token: 0x1700113D RID: 4413
		// (get) Token: 0x06003822 RID: 14370 RVA: 0x0006B73C File Offset: 0x0006993C
		[ProtoMember(3, Name = "assists", DataFormat = DataFormat.Default)]
		public List<HeroKillUnit> assists
		{
			get
			{
				return this._assists;
			}
		}

		// Token: 0x1700113E RID: 4414
		// (get) Token: 0x06003823 RID: 14371 RVA: 0x0006B754 File Offset: 0x00069954
		// (set) Token: 0x06003824 RID: 14372 RVA: 0x0006B780 File Offset: 0x00069980
		[ProtoMember(4, IsRequired = false, Name = "multiKill", DataFormat = DataFormat.TwosComplement)]
		public uint multiKill
		{
			get
			{
				return this._multiKill ?? 0U;
			}
			set
			{
				this._multiKill = new uint?(value);
			}
		}

		// Token: 0x1700113F RID: 4415
		// (get) Token: 0x06003825 RID: 14373 RVA: 0x0006B790 File Offset: 0x00069990
		// (set) Token: 0x06003826 RID: 14374 RVA: 0x0006B7B0 File Offset: 0x000699B0
		[XmlIgnore]
		[Browsable(false)]
		public bool multiKillSpecified
		{
			get
			{
				return this._multiKill != null;
			}
			set
			{
				bool flag = value == (this._multiKill == null);
				if (flag)
				{
					this._multiKill = (value ? new uint?(this.multiKill) : null);
				}
			}
		}

		// Token: 0x06003827 RID: 14375 RVA: 0x0006B7F4 File Offset: 0x000699F4
		private bool ShouldSerializemultiKill()
		{
			return this.multiKillSpecified;
		}

		// Token: 0x06003828 RID: 14376 RVA: 0x0006B80C File Offset: 0x00069A0C
		private void ResetmultiKill()
		{
			this.multiKillSpecified = false;
		}

		// Token: 0x17001140 RID: 4416
		// (get) Token: 0x06003829 RID: 14377 RVA: 0x0006B818 File Offset: 0x00069A18
		// (set) Token: 0x0600382A RID: 14378 RVA: 0x0006B844 File Offset: 0x00069A44
		[ProtoMember(5, IsRequired = false, Name = "isFirstBlood", DataFormat = DataFormat.Default)]
		public bool isFirstBlood
		{
			get
			{
				return this._isFirstBlood ?? false;
			}
			set
			{
				this._isFirstBlood = new bool?(value);
			}
		}

		// Token: 0x17001141 RID: 4417
		// (get) Token: 0x0600382B RID: 14379 RVA: 0x0006B854 File Offset: 0x00069A54
		// (set) Token: 0x0600382C RID: 14380 RVA: 0x0006B874 File Offset: 0x00069A74
		[XmlIgnore]
		[Browsable(false)]
		public bool isFirstBloodSpecified
		{
			get
			{
				return this._isFirstBlood != null;
			}
			set
			{
				bool flag = value == (this._isFirstBlood == null);
				if (flag)
				{
					this._isFirstBlood = (value ? new bool?(this.isFirstBlood) : null);
				}
			}
		}

		// Token: 0x0600382D RID: 14381 RVA: 0x0006B8B8 File Offset: 0x00069AB8
		private bool ShouldSerializeisFirstBlood()
		{
			return this.isFirstBloodSpecified;
		}

		// Token: 0x0600382E RID: 14382 RVA: 0x0006B8D0 File Offset: 0x00069AD0
		private void ResetisFirstBlood()
		{
			this.isFirstBloodSpecified = false;
		}

		// Token: 0x0600382F RID: 14383 RVA: 0x0006B8DC File Offset: 0x00069ADC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DE7 RID: 3559
		private HeroKillUnit _killer = null;

		// Token: 0x04000DE8 RID: 3560
		private HeroKillUnit _dead = null;

		// Token: 0x04000DE9 RID: 3561
		private readonly List<HeroKillUnit> _assists = new List<HeroKillUnit>();

		// Token: 0x04000DEA RID: 3562
		private uint? _multiKill;

		// Token: 0x04000DEB RID: 3563
		private bool? _isFirstBlood;

		// Token: 0x04000DEC RID: 3564
		private IExtension extensionObject;
	}
}
