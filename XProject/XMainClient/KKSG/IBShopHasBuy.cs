using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000370 RID: 880
	[ProtoContract(Name = "IBShopHasBuy")]
	[Serializable]
	public class IBShopHasBuy : IExtensible
	{
		// Token: 0x17000EC6 RID: 3782
		// (get) Token: 0x06002FBC RID: 12220 RVA: 0x0005C160 File Offset: 0x0005A360
		// (set) Token: 0x06002FBD RID: 12221 RVA: 0x0005C18C File Offset: 0x0005A38C
		[ProtoMember(1, IsRequired = false, Name = "goodsid", DataFormat = DataFormat.TwosComplement)]
		public uint goodsid
		{
			get
			{
				return this._goodsid ?? 0U;
			}
			set
			{
				this._goodsid = new uint?(value);
			}
		}

		// Token: 0x17000EC7 RID: 3783
		// (get) Token: 0x06002FBE RID: 12222 RVA: 0x0005C19C File Offset: 0x0005A39C
		// (set) Token: 0x06002FBF RID: 12223 RVA: 0x0005C1BC File Offset: 0x0005A3BC
		[XmlIgnore]
		[Browsable(false)]
		public bool goodsidSpecified
		{
			get
			{
				return this._goodsid != null;
			}
			set
			{
				bool flag = value == (this._goodsid == null);
				if (flag)
				{
					this._goodsid = (value ? new uint?(this.goodsid) : null);
				}
			}
		}

		// Token: 0x06002FC0 RID: 12224 RVA: 0x0005C200 File Offset: 0x0005A400
		private bool ShouldSerializegoodsid()
		{
			return this.goodsidSpecified;
		}

		// Token: 0x06002FC1 RID: 12225 RVA: 0x0005C218 File Offset: 0x0005A418
		private void Resetgoodsid()
		{
			this.goodsidSpecified = false;
		}

		// Token: 0x17000EC8 RID: 3784
		// (get) Token: 0x06002FC2 RID: 12226 RVA: 0x0005C224 File Offset: 0x0005A424
		// (set) Token: 0x06002FC3 RID: 12227 RVA: 0x0005C250 File Offset: 0x0005A450
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000EC9 RID: 3785
		// (get) Token: 0x06002FC4 RID: 12228 RVA: 0x0005C260 File Offset: 0x0005A460
		// (set) Token: 0x06002FC5 RID: 12229 RVA: 0x0005C280 File Offset: 0x0005A480
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06002FC6 RID: 12230 RVA: 0x0005C2C4 File Offset: 0x0005A4C4
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06002FC7 RID: 12231 RVA: 0x0005C2DC File Offset: 0x0005A4DC
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06002FC8 RID: 12232 RVA: 0x0005C2E8 File Offset: 0x0005A4E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BDC RID: 3036
		private uint? _goodsid;

		// Token: 0x04000BDD RID: 3037
		private uint? _count;

		// Token: 0x04000BDE RID: 3038
		private IExtension extensionObject;
	}
}
