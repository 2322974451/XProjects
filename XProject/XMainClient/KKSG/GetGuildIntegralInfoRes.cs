using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B8 RID: 696
	[ProtoContract(Name = "GetGuildIntegralInfoRes")]
	[Serializable]
	public class GetGuildIntegralInfoRes : IExtensible
	{
		// Token: 0x17000BFC RID: 3068
		// (get) Token: 0x06002689 RID: 9865 RVA: 0x0004AF60 File Offset: 0x00049160
		// (set) Token: 0x0600268A RID: 9866 RVA: 0x0004AF8C File Offset: 0x0004918C
		[ProtoMember(1, IsRequired = false, Name = "battletype", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaType battletype
		{
			get
			{
				return this._battletype ?? GuildArenaType.battleone;
			}
			set
			{
				this._battletype = new GuildArenaType?(value);
			}
		}

		// Token: 0x17000BFD RID: 3069
		// (get) Token: 0x0600268B RID: 9867 RVA: 0x0004AF9C File Offset: 0x0004919C
		// (set) Token: 0x0600268C RID: 9868 RVA: 0x0004AFBC File Offset: 0x000491BC
		[XmlIgnore]
		[Browsable(false)]
		public bool battletypeSpecified
		{
			get
			{
				return this._battletype != null;
			}
			set
			{
				bool flag = value == (this._battletype == null);
				if (flag)
				{
					this._battletype = (value ? new GuildArenaType?(this.battletype) : null);
				}
			}
		}

		// Token: 0x0600268D RID: 9869 RVA: 0x0004B000 File Offset: 0x00049200
		private bool ShouldSerializebattletype()
		{
			return this.battletypeSpecified;
		}

		// Token: 0x0600268E RID: 9870 RVA: 0x0004B018 File Offset: 0x00049218
		private void Resetbattletype()
		{
			this.battletypeSpecified = false;
		}

		// Token: 0x17000BFE RID: 3070
		// (get) Token: 0x0600268F RID: 9871 RVA: 0x0004B024 File Offset: 0x00049224
		// (set) Token: 0x06002690 RID: 9872 RVA: 0x0004B050 File Offset: 0x00049250
		[ProtoMember(2, IsRequired = false, Name = "applytime", DataFormat = DataFormat.TwosComplement)]
		public uint applytime
		{
			get
			{
				return this._applytime ?? 0U;
			}
			set
			{
				this._applytime = new uint?(value);
			}
		}

		// Token: 0x17000BFF RID: 3071
		// (get) Token: 0x06002691 RID: 9873 RVA: 0x0004B060 File Offset: 0x00049260
		// (set) Token: 0x06002692 RID: 9874 RVA: 0x0004B080 File Offset: 0x00049280
		[XmlIgnore]
		[Browsable(false)]
		public bool applytimeSpecified
		{
			get
			{
				return this._applytime != null;
			}
			set
			{
				bool flag = value == (this._applytime == null);
				if (flag)
				{
					this._applytime = (value ? new uint?(this.applytime) : null);
				}
			}
		}

		// Token: 0x06002693 RID: 9875 RVA: 0x0004B0C4 File Offset: 0x000492C4
		private bool ShouldSerializeapplytime()
		{
			return this.applytimeSpecified;
		}

		// Token: 0x06002694 RID: 9876 RVA: 0x0004B0DC File Offset: 0x000492DC
		private void Resetapplytime()
		{
			this.applytimeSpecified = false;
		}

		// Token: 0x17000C00 RID: 3072
		// (get) Token: 0x06002695 RID: 9877 RVA: 0x0004B0E8 File Offset: 0x000492E8
		// (set) Token: 0x06002696 RID: 9878 RVA: 0x0004B114 File Offset: 0x00049314
		[ProtoMember(3, IsRequired = false, Name = "isapply", DataFormat = DataFormat.Default)]
		public bool isapply
		{
			get
			{
				return this._isapply ?? false;
			}
			set
			{
				this._isapply = new bool?(value);
			}
		}

		// Token: 0x17000C01 RID: 3073
		// (get) Token: 0x06002697 RID: 9879 RVA: 0x0004B124 File Offset: 0x00049324
		// (set) Token: 0x06002698 RID: 9880 RVA: 0x0004B144 File Offset: 0x00049344
		[XmlIgnore]
		[Browsable(false)]
		public bool isapplySpecified
		{
			get
			{
				return this._isapply != null;
			}
			set
			{
				bool flag = value == (this._isapply == null);
				if (flag)
				{
					this._isapply = (value ? new bool?(this.isapply) : null);
				}
			}
		}

		// Token: 0x06002699 RID: 9881 RVA: 0x0004B188 File Offset: 0x00049388
		private bool ShouldSerializeisapply()
		{
			return this.isapplySpecified;
		}

		// Token: 0x0600269A RID: 9882 RVA: 0x0004B1A0 File Offset: 0x000493A0
		private void Resetisapply()
		{
			this.isapplySpecified = false;
		}

		// Token: 0x17000C02 RID: 3074
		// (get) Token: 0x0600269B RID: 9883 RVA: 0x0004B1AC File Offset: 0x000493AC
		// (set) Token: 0x0600269C RID: 9884 RVA: 0x0004B1D8 File Offset: 0x000493D8
		[ProtoMember(4, IsRequired = false, Name = "curturn", DataFormat = DataFormat.TwosComplement)]
		public uint curturn
		{
			get
			{
				return this._curturn ?? 0U;
			}
			set
			{
				this._curturn = new uint?(value);
			}
		}

		// Token: 0x17000C03 RID: 3075
		// (get) Token: 0x0600269D RID: 9885 RVA: 0x0004B1E8 File Offset: 0x000493E8
		// (set) Token: 0x0600269E RID: 9886 RVA: 0x0004B208 File Offset: 0x00049408
		[XmlIgnore]
		[Browsable(false)]
		public bool curturnSpecified
		{
			get
			{
				return this._curturn != null;
			}
			set
			{
				bool flag = value == (this._curturn == null);
				if (flag)
				{
					this._curturn = (value ? new uint?(this.curturn) : null);
				}
			}
		}

		// Token: 0x0600269F RID: 9887 RVA: 0x0004B24C File Offset: 0x0004944C
		private bool ShouldSerializecurturn()
		{
			return this.curturnSpecified;
		}

		// Token: 0x060026A0 RID: 9888 RVA: 0x0004B264 File Offset: 0x00049464
		private void Resetcurturn()
		{
			this.curturnSpecified = false;
		}

		// Token: 0x060026A1 RID: 9889 RVA: 0x0004B270 File Offset: 0x00049470
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000995 RID: 2453
		private GuildArenaType? _battletype;

		// Token: 0x04000996 RID: 2454
		private uint? _applytime;

		// Token: 0x04000997 RID: 2455
		private bool? _isapply;

		// Token: 0x04000998 RID: 2456
		private uint? _curturn;

		// Token: 0x04000999 RID: 2457
		private IExtension extensionObject;
	}
}
