using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000566 RID: 1382
	[ProtoContract(Name = "CircleDrawData")]
	[Serializable]
	public class CircleDrawData : IExtensible
	{
		// Token: 0x170015C0 RID: 5568
		// (get) Token: 0x06004718 RID: 18200 RVA: 0x00087130 File Offset: 0x00085330
		// (set) Token: 0x06004719 RID: 18201 RVA: 0x0008715C File Offset: 0x0008535C
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x170015C1 RID: 5569
		// (get) Token: 0x0600471A RID: 18202 RVA: 0x0008716C File Offset: 0x0008536C
		// (set) Token: 0x0600471B RID: 18203 RVA: 0x0008718C File Offset: 0x0008538C
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x0600471C RID: 18204 RVA: 0x000871D0 File Offset: 0x000853D0
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x0600471D RID: 18205 RVA: 0x000871E8 File Offset: 0x000853E8
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x170015C2 RID: 5570
		// (get) Token: 0x0600471E RID: 18206 RVA: 0x000871F4 File Offset: 0x000853F4
		// (set) Token: 0x0600471F RID: 18207 RVA: 0x00087220 File Offset: 0x00085420
		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x170015C3 RID: 5571
		// (get) Token: 0x06004720 RID: 18208 RVA: 0x00087230 File Offset: 0x00085430
		// (set) Token: 0x06004721 RID: 18209 RVA: 0x00087250 File Offset: 0x00085450
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06004722 RID: 18210 RVA: 0x00087294 File Offset: 0x00085494
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06004723 RID: 18211 RVA: 0x000872AC File Offset: 0x000854AC
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x170015C4 RID: 5572
		// (get) Token: 0x06004724 RID: 18212 RVA: 0x000872B8 File Offset: 0x000854B8
		// (set) Token: 0x06004725 RID: 18213 RVA: 0x000872E4 File Offset: 0x000854E4
		[ProtoMember(3, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		// Token: 0x170015C5 RID: 5573
		// (get) Token: 0x06004726 RID: 18214 RVA: 0x000872F4 File Offset: 0x000854F4
		// (set) Token: 0x06004727 RID: 18215 RVA: 0x00087314 File Offset: 0x00085514
		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		// Token: 0x06004728 RID: 18216 RVA: 0x00087358 File Offset: 0x00085558
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x06004729 RID: 18217 RVA: 0x00087370 File Offset: 0x00085570
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x170015C6 RID: 5574
		// (get) Token: 0x0600472A RID: 18218 RVA: 0x0008737C File Offset: 0x0008557C
		// (set) Token: 0x0600472B RID: 18219 RVA: 0x000873A8 File Offset: 0x000855A8
		[ProtoMember(4, IsRequired = false, Name = "prob", DataFormat = DataFormat.TwosComplement)]
		public uint prob
		{
			get
			{
				return this._prob ?? 0U;
			}
			set
			{
				this._prob = new uint?(value);
			}
		}

		// Token: 0x170015C7 RID: 5575
		// (get) Token: 0x0600472C RID: 18220 RVA: 0x000873B8 File Offset: 0x000855B8
		// (set) Token: 0x0600472D RID: 18221 RVA: 0x000873D8 File Offset: 0x000855D8
		[XmlIgnore]
		[Browsable(false)]
		public bool probSpecified
		{
			get
			{
				return this._prob != null;
			}
			set
			{
				bool flag = value == (this._prob == null);
				if (flag)
				{
					this._prob = (value ? new uint?(this.prob) : null);
				}
			}
		}

		// Token: 0x0600472E RID: 18222 RVA: 0x0008741C File Offset: 0x0008561C
		private bool ShouldSerializeprob()
		{
			return this.probSpecified;
		}

		// Token: 0x0600472F RID: 18223 RVA: 0x00087434 File Offset: 0x00085634
		private void Resetprob()
		{
			this.probSpecified = false;
		}

		// Token: 0x06004730 RID: 18224 RVA: 0x00087440 File Offset: 0x00085640
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011BF RID: 4543
		private uint? _index;

		// Token: 0x040011C0 RID: 4544
		private uint? _itemid;

		// Token: 0x040011C1 RID: 4545
		private uint? _itemcount;

		// Token: 0x040011C2 RID: 4546
		private uint? _prob;

		// Token: 0x040011C3 RID: 4547
		private IExtension extensionObject;
	}
}
