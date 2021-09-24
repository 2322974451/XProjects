using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleOneGame")]
	[Serializable]
	public class HeroBattleOneGame : IExtensible
	{

		[ProtoMember(1, Name = "team1", DataFormat = DataFormat.Default)]
		public List<RoleSmallInfo> team1
		{
			get
			{
				return this._team1;
			}
		}

		[ProtoMember(2, Name = "team2", DataFormat = DataFormat.Default)]
		public List<RoleSmallInfo> team2
		{
			get
			{
				return this._team2;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "over", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "exploit", DataFormat = DataFormat.TwosComplement)]
		public uint exploit
		{
			get
			{
				return this._exploit ?? 0U;
			}
			set
			{
				this._exploit = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool exploitSpecified
		{
			get
			{
				return this._exploit != null;
			}
			set
			{
				bool flag = value == (this._exploit == null);
				if (flag)
				{
					this._exploit = (value ? new uint?(this.exploit) : null);
				}
			}
		}

		private bool ShouldSerializeexploit()
		{
			return this.exploitSpecified;
		}

		private void Resetexploit()
		{
			this.exploitSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RoleSmallInfo> _team1 = new List<RoleSmallInfo>();

		private readonly List<RoleSmallInfo> _team2 = new List<RoleSmallInfo>();

		private HeroBattleOver? _over;

		private ulong? _mvpid;

		private uint? _exploit;

		private IExtension extensionObject;
	}
}
