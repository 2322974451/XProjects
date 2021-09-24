using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OutLook")]
	[Serializable]
	public class OutLook : IExtensible
	{

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private OutLookGuild _guild = null;

		private OutLookDesignation _designation = null;

		private OutLookEquip _equips = null;

		private OutLookTitle _title = null;

		private OutLookOp _op = null;

		private OutLookSprite _sprite = null;

		private OutLookState _state = null;

		private OutLookMilitaryRank _military = null;

		private OutLookDisplayFashion _display_fashion = null;

		private OutLookConsumePre _pre = null;

		private IExtension extensionObject;
	}
}
