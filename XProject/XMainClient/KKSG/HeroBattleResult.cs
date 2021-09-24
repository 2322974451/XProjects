using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleResult")]
	[Serializable]
	public class HeroBattleResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "over", DataFormat = DataFormat.TwosComplement)]
		public HeroBattleOver over
		{
			get
			{
				return this._over ?? HeroBattleOver.HeroBattleOver_Win;
			}
			set
			{
				this._over = new HeroBattleOver?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool overSpecified
		{
			get
			{
				return this._over != null;
			}
			set
			{
				bool flag = value == (this._over == null);
				if (flag)
				{
					this._over = (value ? new HeroBattleOver?(this.over) : null);
				}
			}
		}

		private bool ShouldSerializeover()
		{
			return this.overSpecified;
		}

		private void Resetover()
		{
			this.overSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpid
		{
			get
			{
				return this._mvpid ?? 0UL;
			}
			set
			{
				this._mvpid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mvpidSpecified
		{
			get
			{
				return this._mvpid != null;
			}
			set
			{
				bool flag = value == (this._mvpid == null);
				if (flag)
				{
					this._mvpid = (value ? new ulong?(this.mvpid) : null);
				}
			}
		}

		private bool ShouldSerializemvpid()
		{
			return this.mvpidSpecified;
		}

		private void Resetmvpid()
		{
			this.mvpidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "mvpheroid", DataFormat = DataFormat.TwosComplement)]
		public uint mvpheroid
		{
			get
			{
				return this._mvpheroid ?? 0U;
			}
			set
			{
				this._mvpheroid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mvpheroidSpecified
		{
			get
			{
				return this._mvpheroid != null;
			}
			set
			{
				bool flag = value == (this._mvpheroid == null);
				if (flag)
				{
					this._mvpheroid = (value ? new uint?(this.mvpheroid) : null);
				}
			}
		}

		private bool ShouldSerializemvpheroid()
		{
			return this.mvpheroidSpecified;
		}

		private void Resetmvpheroid()
		{
			this.mvpheroidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		[ProtoMember(5, Name = "dayjoinreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dayjoinreward
		{
			get
			{
				return this._dayjoinreward;
			}
		}

		[ProtoMember(6, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "losemvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong losemvpid
		{
			get
			{
				return this._losemvpid ?? 0UL;
			}
			set
			{
				this._losemvpid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losemvpidSpecified
		{
			get
			{
				return this._losemvpid != null;
			}
			set
			{
				bool flag = value == (this._losemvpid == null);
				if (flag)
				{
					this._losemvpid = (value ? new ulong?(this.losemvpid) : null);
				}
			}
		}

		private bool ShouldSerializelosemvpid()
		{
			return this.losemvpidSpecified;
		}

		private void Resetlosemvpid()
		{
			this.losemvpidSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "kda", DataFormat = DataFormat.FixedSize)]
		public float kda
		{
			get
			{
				return this._kda ?? 0f;
			}
			set
			{
				this._kda = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool kdaSpecified
		{
			get
			{
				return this._kda != null;
			}
			set
			{
				bool flag = value == (this._kda == null);
				if (flag)
				{
					this._kda = (value ? new float?(this.kda) : null);
				}
			}
		}

		private bool ShouldSerializekda()
		{
			return this.kdaSpecified;
		}

		private void Resetkda()
		{
			this.kdaSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private HeroBattleOver? _over;

		private ulong? _mvpid;

		private uint? _mvpheroid;

		private uint? _teamid;

		private readonly List<ItemBrief> _dayjoinreward = new List<ItemBrief>();

		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		private ulong? _losemvpid;

		private float? _kda;

		private IExtension extensionObject;
	}
}
