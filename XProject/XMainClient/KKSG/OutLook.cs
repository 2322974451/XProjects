using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000570 RID: 1392
	[ProtoContract(Name = "OutLook")]
	[Serializable]
	public class OutLook : IExtensible
	{
		// Token: 0x170015FA RID: 5626
		// (get) Token: 0x060047C3 RID: 18371 RVA: 0x00088668 File Offset: 0x00086868
		// (set) Token: 0x060047C4 RID: 18372 RVA: 0x00088680 File Offset: 0x00086880
		[ProtoMember(1, IsRequired = false, Name = "guild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookGuild guild
		{
			get
			{
				return this._guild;
			}
			set
			{
				this._guild = value;
			}
		}

		// Token: 0x170015FB RID: 5627
		// (get) Token: 0x060047C5 RID: 18373 RVA: 0x0008868C File Offset: 0x0008688C
		// (set) Token: 0x060047C6 RID: 18374 RVA: 0x000886A4 File Offset: 0x000868A4
		[ProtoMember(2, IsRequired = false, Name = "designation", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookDesignation designation
		{
			get
			{
				return this._designation;
			}
			set
			{
				this._designation = value;
			}
		}

		// Token: 0x170015FC RID: 5628
		// (get) Token: 0x060047C7 RID: 18375 RVA: 0x000886B0 File Offset: 0x000868B0
		// (set) Token: 0x060047C8 RID: 18376 RVA: 0x000886C8 File Offset: 0x000868C8
		[ProtoMember(3, IsRequired = false, Name = "equips", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookEquip equips
		{
			get
			{
				return this._equips;
			}
			set
			{
				this._equips = value;
			}
		}

		// Token: 0x170015FD RID: 5629
		// (get) Token: 0x060047C9 RID: 18377 RVA: 0x000886D4 File Offset: 0x000868D4
		// (set) Token: 0x060047CA RID: 18378 RVA: 0x000886EC File Offset: 0x000868EC
		[ProtoMember(4, IsRequired = false, Name = "title", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookTitle title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}

		// Token: 0x170015FE RID: 5630
		// (get) Token: 0x060047CB RID: 18379 RVA: 0x000886F8 File Offset: 0x000868F8
		// (set) Token: 0x060047CC RID: 18380 RVA: 0x00088710 File Offset: 0x00086910
		[ProtoMember(5, IsRequired = false, Name = "op", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookOp op
		{
			get
			{
				return this._op;
			}
			set
			{
				this._op = value;
			}
		}

		// Token: 0x170015FF RID: 5631
		// (get) Token: 0x060047CD RID: 18381 RVA: 0x0008871C File Offset: 0x0008691C
		// (set) Token: 0x060047CE RID: 18382 RVA: 0x00088734 File Offset: 0x00086934
		[ProtoMember(6, IsRequired = false, Name = "sprite", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookSprite sprite
		{
			get
			{
				return this._sprite;
			}
			set
			{
				this._sprite = value;
			}
		}

		// Token: 0x17001600 RID: 5632
		// (get) Token: 0x060047CF RID: 18383 RVA: 0x00088740 File Offset: 0x00086940
		// (set) Token: 0x060047D0 RID: 18384 RVA: 0x00088758 File Offset: 0x00086958
		[ProtoMember(7, IsRequired = false, Name = "state", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookState state
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
			}
		}

		// Token: 0x17001601 RID: 5633
		// (get) Token: 0x060047D1 RID: 18385 RVA: 0x00088764 File Offset: 0x00086964
		// (set) Token: 0x060047D2 RID: 18386 RVA: 0x0008877C File Offset: 0x0008697C
		[ProtoMember(8, IsRequired = false, Name = "military", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookMilitaryRank military
		{
			get
			{
				return this._military;
			}
			set
			{
				this._military = value;
			}
		}

		// Token: 0x17001602 RID: 5634
		// (get) Token: 0x060047D3 RID: 18387 RVA: 0x00088788 File Offset: 0x00086988
		// (set) Token: 0x060047D4 RID: 18388 RVA: 0x000887A0 File Offset: 0x000869A0
		[ProtoMember(9, IsRequired = false, Name = "display_fashion", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookDisplayFashion display_fashion
		{
			get
			{
				return this._display_fashion;
			}
			set
			{
				this._display_fashion = value;
			}
		}

		// Token: 0x17001603 RID: 5635
		// (get) Token: 0x060047D5 RID: 18389 RVA: 0x000887AC File Offset: 0x000869AC
		// (set) Token: 0x060047D6 RID: 18390 RVA: 0x000887C4 File Offset: 0x000869C4
		[ProtoMember(10, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookConsumePre pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		// Token: 0x060047D7 RID: 18391 RVA: 0x000887D0 File Offset: 0x000869D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011EC RID: 4588
		private OutLookGuild _guild = null;

		// Token: 0x040011ED RID: 4589
		private OutLookDesignation _designation = null;

		// Token: 0x040011EE RID: 4590
		private OutLookEquip _equips = null;

		// Token: 0x040011EF RID: 4591
		private OutLookTitle _title = null;

		// Token: 0x040011F0 RID: 4592
		private OutLookOp _op = null;

		// Token: 0x040011F1 RID: 4593
		private OutLookSprite _sprite = null;

		// Token: 0x040011F2 RID: 4594
		private OutLookState _state = null;

		// Token: 0x040011F3 RID: 4595
		private OutLookMilitaryRank _military = null;

		// Token: 0x040011F4 RID: 4596
		private OutLookDisplayFashion _display_fashion = null;

		// Token: 0x040011F5 RID: 4597
		private OutLookConsumePre _pre = null;

		// Token: 0x040011F6 RID: 4598
		private IExtension extensionObject;
	}
}
