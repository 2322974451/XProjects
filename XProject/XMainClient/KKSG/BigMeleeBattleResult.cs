using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BigMeleeBattleResult")]
	[Serializable]
	public class BigMeleeBattleResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "kill", DataFormat = DataFormat.TwosComplement)]
		public uint kill
		{
			get
			{
				return this._kill ?? 0U;
			}
			set
			{
				this._kill = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killSpecified
		{
			get
			{
				return this._kill != null;
			}
			set
			{
				bool flag = value == (this._kill == null);
				if (flag)
				{
					this._kill = (value ? new uint?(this.kill) : null);
				}
			}
		}

		private bool ShouldSerializekill()
		{
			return this.killSpecified;
		}

		private void Resetkill()
		{
			this.killSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "death", DataFormat = DataFormat.TwosComplement)]
		public uint death
		{
			get
			{
				return this._death ?? 0U;
			}
			set
			{
				this._death = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deathSpecified
		{
			get
			{
				return this._death != null;
			}
			set
			{
				bool flag = value == (this._death == null);
				if (flag)
				{
					this._death = (value ? new uint?(this.death) : null);
				}
			}
		}

		private bool ShouldSerializedeath()
		{
			return this.deathSpecified;
		}

		private void Resetdeath()
		{
			this.deathSpecified = false;
		}

		[ProtoMember(6, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _rank;

		private uint? _score;

		private uint? _kill;

		private uint? _death;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
