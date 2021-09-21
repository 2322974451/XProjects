using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002FF RID: 767
	[ProtoContract(Name = "HorseRank")]
	[Serializable]
	public class HorseRank : IExtensible
	{
		// Token: 0x17000D04 RID: 3332
		// (get) Token: 0x060029FA RID: 10746 RVA: 0x00051654 File Offset: 0x0004F854
		// (set) Token: 0x060029FB RID: 10747 RVA: 0x00051680 File Offset: 0x0004F880
		[ProtoMember(1, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17000D05 RID: 3333
		// (get) Token: 0x060029FC RID: 10748 RVA: 0x00051690 File Offset: 0x0004F890
		// (set) Token: 0x060029FD RID: 10749 RVA: 0x000516B0 File Offset: 0x0004F8B0
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x060029FE RID: 10750 RVA: 0x000516F4 File Offset: 0x0004F8F4
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060029FF RID: 10751 RVA: 0x0005170C File Offset: 0x0004F90C
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17000D06 RID: 3334
		// (get) Token: 0x06002A00 RID: 10752 RVA: 0x00051718 File Offset: 0x0004F918
		// (set) Token: 0x06002A01 RID: 10753 RVA: 0x00051744 File Offset: 0x0004F944
		[ProtoMember(2, IsRequired = false, Name = "turns", DataFormat = DataFormat.TwosComplement)]
		public uint turns
		{
			get
			{
				return this._turns ?? 0U;
			}
			set
			{
				this._turns = new uint?(value);
			}
		}

		// Token: 0x17000D07 RID: 3335
		// (get) Token: 0x06002A02 RID: 10754 RVA: 0x00051754 File Offset: 0x0004F954
		// (set) Token: 0x06002A03 RID: 10755 RVA: 0x00051774 File Offset: 0x0004F974
		[XmlIgnore]
		[Browsable(false)]
		public bool turnsSpecified
		{
			get
			{
				return this._turns != null;
			}
			set
			{
				bool flag = value == (this._turns == null);
				if (flag)
				{
					this._turns = (value ? new uint?(this.turns) : null);
				}
			}
		}

		// Token: 0x06002A04 RID: 10756 RVA: 0x000517B8 File Offset: 0x0004F9B8
		private bool ShouldSerializeturns()
		{
			return this.turnsSpecified;
		}

		// Token: 0x06002A05 RID: 10757 RVA: 0x000517D0 File Offset: 0x0004F9D0
		private void Resetturns()
		{
			this.turnsSpecified = false;
		}

		// Token: 0x06002A06 RID: 10758 RVA: 0x000517DC File Offset: 0x0004F9DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A6E RID: 2670
		private uint? _rank;

		// Token: 0x04000A6F RID: 2671
		private uint? _turns;

		// Token: 0x04000A70 RID: 2672
		private IExtension extensionObject;
	}
}
