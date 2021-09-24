using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleOneRole")]
	[Serializable]
	public class LeagueBattleOneRole : IExtensible
	{

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

		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleRoleState state
		{
			get
			{
				return this._state ?? LeagueBattleRoleState.LBRoleState_None;
			}
			set
			{
				this._state = new LeagueBattleRoleState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new LeagueBattleRoleState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

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
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LeagueBattleRoleBrief _basedata = null;

		private LeagueBattleRoleState? _state;

		private int? _index;

		private IExtension extensionObject;
	}
}
