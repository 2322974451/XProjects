using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200059E RID: 1438
	[ProtoContract(Name = "TeamCountClient")]
	[Serializable]
	public class TeamCountClient : IExtensible
	{
		// Token: 0x170017D8 RID: 6104
		// (get) Token: 0x06004D5F RID: 19807 RVA: 0x00093368 File Offset: 0x00091568
		// (set) Token: 0x06004D60 RID: 19808 RVA: 0x00093394 File Offset: 0x00091594
		[ProtoMember(1, IsRequired = false, Name = "teamtype", DataFormat = DataFormat.TwosComplement)]
		public int teamtype
		{
			get
			{
				return this._teamtype ?? 0;
			}
			set
			{
				this._teamtype = new int?(value);
			}
		}

		// Token: 0x170017D9 RID: 6105
		// (get) Token: 0x06004D61 RID: 19809 RVA: 0x000933A4 File Offset: 0x000915A4
		// (set) Token: 0x06004D62 RID: 19810 RVA: 0x000933C4 File Offset: 0x000915C4
		[XmlIgnore]
		[Browsable(false)]
		public bool teamtypeSpecified
		{
			get
			{
				return this._teamtype != null;
			}
			set
			{
				bool flag = value == (this._teamtype == null);
				if (flag)
				{
					this._teamtype = (value ? new int?(this.teamtype) : null);
				}
			}
		}

		// Token: 0x06004D63 RID: 19811 RVA: 0x00093408 File Offset: 0x00091608
		private bool ShouldSerializeteamtype()
		{
			return this.teamtypeSpecified;
		}

		// Token: 0x06004D64 RID: 19812 RVA: 0x00093420 File Offset: 0x00091620
		private void Resetteamtype()
		{
			this.teamtypeSpecified = false;
		}

		// Token: 0x170017DA RID: 6106
		// (get) Token: 0x06004D65 RID: 19813 RVA: 0x0009342C File Offset: 0x0009162C
		// (set) Token: 0x06004D66 RID: 19814 RVA: 0x00093458 File Offset: 0x00091658
		[ProtoMember(2, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		// Token: 0x170017DB RID: 6107
		// (get) Token: 0x06004D67 RID: 19815 RVA: 0x00093468 File Offset: 0x00091668
		// (set) Token: 0x06004D68 RID: 19816 RVA: 0x00093488 File Offset: 0x00091688
		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		// Token: 0x06004D69 RID: 19817 RVA: 0x000934CC File Offset: 0x000916CC
		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		// Token: 0x06004D6A RID: 19818 RVA: 0x000934E4 File Offset: 0x000916E4
		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		// Token: 0x170017DC RID: 6108
		// (get) Token: 0x06004D6B RID: 19819 RVA: 0x000934F0 File Offset: 0x000916F0
		// (set) Token: 0x06004D6C RID: 19820 RVA: 0x0009351C File Offset: 0x0009171C
		[ProtoMember(3, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public int buycount
		{
			get
			{
				return this._buycount ?? 0;
			}
			set
			{
				this._buycount = new int?(value);
			}
		}

		// Token: 0x170017DD RID: 6109
		// (get) Token: 0x06004D6D RID: 19821 RVA: 0x0009352C File Offset: 0x0009172C
		// (set) Token: 0x06004D6E RID: 19822 RVA: 0x0009354C File Offset: 0x0009174C
		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new int?(this.buycount) : null);
				}
			}
		}

		// Token: 0x06004D6F RID: 19823 RVA: 0x00093590 File Offset: 0x00091790
		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		// Token: 0x06004D70 RID: 19824 RVA: 0x000935A8 File Offset: 0x000917A8
		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		// Token: 0x170017DE RID: 6110
		// (get) Token: 0x06004D71 RID: 19825 RVA: 0x000935B4 File Offset: 0x000917B4
		// (set) Token: 0x06004D72 RID: 19826 RVA: 0x000935E0 File Offset: 0x000917E0
		[ProtoMember(4, IsRequired = false, Name = "maxcount", DataFormat = DataFormat.TwosComplement)]
		public int maxcount
		{
			get
			{
				return this._maxcount ?? 0;
			}
			set
			{
				this._maxcount = new int?(value);
			}
		}

		// Token: 0x170017DF RID: 6111
		// (get) Token: 0x06004D73 RID: 19827 RVA: 0x000935F0 File Offset: 0x000917F0
		// (set) Token: 0x06004D74 RID: 19828 RVA: 0x00093610 File Offset: 0x00091810
		[XmlIgnore]
		[Browsable(false)]
		public bool maxcountSpecified
		{
			get
			{
				return this._maxcount != null;
			}
			set
			{
				bool flag = value == (this._maxcount == null);
				if (flag)
				{
					this._maxcount = (value ? new int?(this.maxcount) : null);
				}
			}
		}

		// Token: 0x06004D75 RID: 19829 RVA: 0x00093654 File Offset: 0x00091854
		private bool ShouldSerializemaxcount()
		{
			return this.maxcountSpecified;
		}

		// Token: 0x06004D76 RID: 19830 RVA: 0x0009366C File Offset: 0x0009186C
		private void Resetmaxcount()
		{
			this.maxcountSpecified = false;
		}

		// Token: 0x06004D77 RID: 19831 RVA: 0x00093678 File Offset: 0x00091878
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001326 RID: 4902
		private int? _teamtype;

		// Token: 0x04001327 RID: 4903
		private int? _leftcount;

		// Token: 0x04001328 RID: 4904
		private int? _buycount;

		// Token: 0x04001329 RID: 4905
		private int? _maxcount;

		// Token: 0x0400132A RID: 4906
		private IExtension extensionObject;
	}
}
