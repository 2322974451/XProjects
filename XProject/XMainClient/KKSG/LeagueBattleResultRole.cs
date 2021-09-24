using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleResultRole")]
	[Serializable]
	public class LeagueBattleResultRole : IExtensible
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

		private bool ShouldSerializekillnum()
		{
			return this.killnumSpecified;
		}

		private void Resetkillnum()
		{
			this.killnumSpecified = false;
		}

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

		private bool ShouldSerializeis_up()
		{
			return this.is_upSpecified;
		}

		private void Resetis_up()
		{
			this.is_upSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LeagueBattleRoleBrief _basedata = null;

		private uint? _killnum;

		private bool? _is_up;

		private IExtension extensionObject;
	}
}
