using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F5 RID: 1781
	[ProtoContract(Name = "LeagueBattleResultRole")]
	[Serializable]
	public class LeagueBattleResultRole : IExtensible
	{
		// Token: 0x170025F8 RID: 9720
		// (get) Token: 0x060077E2 RID: 30690 RVA: 0x000E556C File Offset: 0x000E376C
		// (set) Token: 0x060077E3 RID: 30691 RVA: 0x000E5584 File Offset: 0x000E3784
		[ProtoMember(1, IsRequired = false, Name = "basedata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleRoleBrief basedata
		{
			get
			{
				return this._basedata;
			}
			set
			{
				this._basedata = value;
			}
		}

		// Token: 0x170025F9 RID: 9721
		// (get) Token: 0x060077E4 RID: 30692 RVA: 0x000E5590 File Offset: 0x000E3790
		// (set) Token: 0x060077E5 RID: 30693 RVA: 0x000E55BC File Offset: 0x000E37BC
		[ProtoMember(2, IsRequired = false, Name = "killnum", DataFormat = DataFormat.TwosComplement)]
		public uint killnum
		{
			get
			{
				return this._killnum ?? 0U;
			}
			set
			{
				this._killnum = new uint?(value);
			}
		}

		// Token: 0x170025FA RID: 9722
		// (get) Token: 0x060077E6 RID: 30694 RVA: 0x000E55CC File Offset: 0x000E37CC
		// (set) Token: 0x060077E7 RID: 30695 RVA: 0x000E55EC File Offset: 0x000E37EC
		[XmlIgnore]
		[Browsable(false)]
		public bool killnumSpecified
		{
			get
			{
				return this._killnum != null;
			}
			set
			{
				bool flag = value == (this._killnum == null);
				if (flag)
				{
					this._killnum = (value ? new uint?(this.killnum) : null);
				}
			}
		}

		// Token: 0x060077E8 RID: 30696 RVA: 0x000E5630 File Offset: 0x000E3830
		private bool ShouldSerializekillnum()
		{
			return this.killnumSpecified;
		}

		// Token: 0x060077E9 RID: 30697 RVA: 0x000E5648 File Offset: 0x000E3848
		private void Resetkillnum()
		{
			this.killnumSpecified = false;
		}

		// Token: 0x170025FB RID: 9723
		// (get) Token: 0x060077EA RID: 30698 RVA: 0x000E5654 File Offset: 0x000E3854
		// (set) Token: 0x060077EB RID: 30699 RVA: 0x000E5680 File Offset: 0x000E3880
		[ProtoMember(3, IsRequired = false, Name = "is_up", DataFormat = DataFormat.Default)]
		public bool is_up
		{
			get
			{
				return this._is_up ?? false;
			}
			set
			{
				this._is_up = new bool?(value);
			}
		}

		// Token: 0x170025FC RID: 9724
		// (get) Token: 0x060077EC RID: 30700 RVA: 0x000E5690 File Offset: 0x000E3890
		// (set) Token: 0x060077ED RID: 30701 RVA: 0x000E56B0 File Offset: 0x000E38B0
		[XmlIgnore]
		[Browsable(false)]
		public bool is_upSpecified
		{
			get
			{
				return this._is_up != null;
			}
			set
			{
				bool flag = value == (this._is_up == null);
				if (flag)
				{
					this._is_up = (value ? new bool?(this.is_up) : null);
				}
			}
		}

		// Token: 0x060077EE RID: 30702 RVA: 0x000E56F4 File Offset: 0x000E38F4
		private bool ShouldSerializeis_up()
		{
			return this.is_upSpecified;
		}

		// Token: 0x060077EF RID: 30703 RVA: 0x000E570C File Offset: 0x000E390C
		private void Resetis_up()
		{
			this.is_upSpecified = false;
		}

		// Token: 0x060077F0 RID: 30704 RVA: 0x000E5718 File Offset: 0x000E3918
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C5C RID: 7260
		private LeagueBattleRoleBrief _basedata = null;

		// Token: 0x04001C5D RID: 7261
		private uint? _killnum;

		// Token: 0x04001C5E RID: 7262
		private bool? _is_up;

		// Token: 0x04001C5F RID: 7263
		private IExtension extensionObject;
	}
}
