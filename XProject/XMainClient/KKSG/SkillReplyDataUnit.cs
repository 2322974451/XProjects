using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000013 RID: 19
	[ProtoContract(Name = "SkillReplyDataUnit")]
	[Serializable]
	public class SkillReplyDataUnit : IExtensible
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000179 RID: 377 RVA: 0x000057C0 File Offset: 0x000039C0
		// (set) Token: 0x0600017A RID: 378 RVA: 0x000057EC File Offset: 0x000039EC
		[ProtoMember(1, IsRequired = false, Name = "SkillID", DataFormat = DataFormat.TwosComplement)]
		public uint SkillID
		{
			get
			{
				return this._SkillID ?? 0U;
			}
			set
			{
				this._SkillID = new uint?(value);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600017B RID: 379 RVA: 0x000057FC File Offset: 0x000039FC
		// (set) Token: 0x0600017C RID: 380 RVA: 0x0000581C File Offset: 0x00003A1C
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIDSpecified
		{
			get
			{
				return this._SkillID != null;
			}
			set
			{
				bool flag = value == (this._SkillID == null);
				if (flag)
				{
					this._SkillID = (value ? new uint?(this.SkillID) : null);
				}
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00005860 File Offset: 0x00003A60
		private bool ShouldSerializeSkillID()
		{
			return this.SkillIDSpecified;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00005878 File Offset: 0x00003A78
		private void ResetSkillID()
		{
			this.SkillIDSpecified = false;
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00005884 File Offset: 0x00003A84
		// (set) Token: 0x06000180 RID: 384 RVA: 0x000058B0 File Offset: 0x00003AB0
		[ProtoMember(2, IsRequired = false, Name = "PIndex", DataFormat = DataFormat.TwosComplement)]
		public uint PIndex
		{
			get
			{
				return this._PIndex ?? 0U;
			}
			set
			{
				this._PIndex = new uint?(value);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000181 RID: 385 RVA: 0x000058C0 File Offset: 0x00003AC0
		// (set) Token: 0x06000182 RID: 386 RVA: 0x000058E0 File Offset: 0x00003AE0
		[XmlIgnore]
		[Browsable(false)]
		public bool PIndexSpecified
		{
			get
			{
				return this._PIndex != null;
			}
			set
			{
				bool flag = value == (this._PIndex == null);
				if (flag)
				{
					this._PIndex = (value ? new uint?(this.PIndex) : null);
				}
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00005924 File Offset: 0x00003B24
		private bool ShouldSerializePIndex()
		{
			return this.PIndexSpecified;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000593C File Offset: 0x00003B3C
		private void ResetPIndex()
		{
			this.PIndexSpecified = false;
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00005948 File Offset: 0x00003B48
		[ProtoMember(3, Name = "TargetList", DataFormat = DataFormat.Default)]
		public List<TargetHurtInfo> TargetList
		{
			get
			{
				return this._TargetList;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00005960 File Offset: 0x00003B60
		// (set) Token: 0x06000187 RID: 391 RVA: 0x0000598D File Offset: 0x00003B8D
		[ProtoMember(4, IsRequired = false, Name = "FirerID", DataFormat = DataFormat.TwosComplement)]
		public ulong FirerID
		{
			get
			{
				return this._FirerID ?? 0UL;
			}
			set
			{
				this._FirerID = new ulong?(value);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000188 RID: 392 RVA: 0x0000599C File Offset: 0x00003B9C
		// (set) Token: 0x06000189 RID: 393 RVA: 0x000059BC File Offset: 0x00003BBC
		[XmlIgnore]
		[Browsable(false)]
		public bool FirerIDSpecified
		{
			get
			{
				return this._FirerID != null;
			}
			set
			{
				bool flag = value == (this._FirerID == null);
				if (flag)
				{
					this._FirerID = (value ? new ulong?(this.FirerID) : null);
				}
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00005A00 File Offset: 0x00003C00
		private bool ShouldSerializeFirerID()
		{
			return this.FirerIDSpecified;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00005A18 File Offset: 0x00003C18
		private void ResetFirerID()
		{
			this.FirerIDSpecified = false;
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00005A24 File Offset: 0x00003C24
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00005A51 File Offset: 0x00003C51
		[ProtoMember(5, IsRequired = false, Name = "BulletID", DataFormat = DataFormat.TwosComplement)]
		public ulong BulletID
		{
			get
			{
				return this._BulletID ?? 0UL;
			}
			set
			{
				this._BulletID = new ulong?(value);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00005A60 File Offset: 0x00003C60
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00005A80 File Offset: 0x00003C80
		[XmlIgnore]
		[Browsable(false)]
		public bool BulletIDSpecified
		{
			get
			{
				return this._BulletID != null;
			}
			set
			{
				bool flag = value == (this._BulletID == null);
				if (flag)
				{
					this._BulletID = (value ? new ulong?(this.BulletID) : null);
				}
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00005AC4 File Offset: 0x00003CC4
		private bool ShouldSerializeBulletID()
		{
			return this.BulletIDSpecified;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005ADC File Offset: 0x00003CDC
		private void ResetBulletID()
		{
			this.BulletIDSpecified = false;
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00005AE8 File Offset: 0x00003CE8
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00005B15 File Offset: 0x00003D15
		[ProtoMember(6, IsRequired = false, Name = "BulletExtraID", DataFormat = DataFormat.TwosComplement)]
		public ulong BulletExtraID
		{
			get
			{
				return this._BulletExtraID ?? 0UL;
			}
			set
			{
				this._BulletExtraID = new ulong?(value);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00005B24 File Offset: 0x00003D24
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00005B44 File Offset: 0x00003D44
		[XmlIgnore]
		[Browsable(false)]
		public bool BulletExtraIDSpecified
		{
			get
			{
				return this._BulletExtraID != null;
			}
			set
			{
				bool flag = value == (this._BulletExtraID == null);
				if (flag)
				{
					this._BulletExtraID = (value ? new ulong?(this.BulletExtraID) : null);
				}
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00005B88 File Offset: 0x00003D88
		private bool ShouldSerializeBulletExtraID()
		{
			return this.BulletExtraIDSpecified;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00005BA0 File Offset: 0x00003DA0
		private void ResetBulletExtraID()
		{
			this.BulletExtraIDSpecified = false;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00005BAC File Offset: 0x00003DAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000063 RID: 99
		private uint? _SkillID;

		// Token: 0x04000064 RID: 100
		private uint? _PIndex;

		// Token: 0x04000065 RID: 101
		private readonly List<TargetHurtInfo> _TargetList = new List<TargetHurtInfo>();

		// Token: 0x04000066 RID: 102
		private ulong? _FirerID;

		// Token: 0x04000067 RID: 103
		private ulong? _BulletID;

		// Token: 0x04000068 RID: 104
		private ulong? _BulletExtraID;

		// Token: 0x04000069 RID: 105
		private IExtension extensionObject;
	}
}
