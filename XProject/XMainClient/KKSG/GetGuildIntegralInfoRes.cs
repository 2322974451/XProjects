using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildIntegralInfoRes")]
	[Serializable]
	public class GetGuildIntegralInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "battletype", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaType battletype
		{
			get
			{
				return this._battletype ?? GuildArenaType.battleone;
			}
			set
			{
				this._battletype = new GuildArenaType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool battletypeSpecified
		{
			get
			{
				return this._battletype != null;
			}
			set
			{
				bool flag = value == (this._battletype == null);
				if (flag)
				{
					this._battletype = (value ? new GuildArenaType?(this.battletype) : null);
				}
			}
		}

		private bool ShouldSerializebattletype()
		{
			return this.battletypeSpecified;
		}

		private void Resetbattletype()
		{
			this.battletypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "applytime", DataFormat = DataFormat.TwosComplement)]
		public uint applytime
		{
			get
			{
				return this._applytime ?? 0U;
			}
			set
			{
				this._applytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool applytimeSpecified
		{
			get
			{
				return this._applytime != null;
			}
			set
			{
				bool flag = value == (this._applytime == null);
				if (flag)
				{
					this._applytime = (value ? new uint?(this.applytime) : null);
				}
			}
		}

		private bool ShouldSerializeapplytime()
		{
			return this.applytimeSpecified;
		}

		private void Resetapplytime()
		{
			this.applytimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isapply", DataFormat = DataFormat.Default)]
		public bool isapply
		{
			get
			{
				return this._isapply ?? false;
			}
			set
			{
				this._isapply = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isapplySpecified
		{
			get
			{
				return this._isapply != null;
			}
			set
			{
				bool flag = value == (this._isapply == null);
				if (flag)
				{
					this._isapply = (value ? new bool?(this.isapply) : null);
				}
			}
		}

		private bool ShouldSerializeisapply()
		{
			return this.isapplySpecified;
		}

		private void Resetisapply()
		{
			this.isapplySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "curturn", DataFormat = DataFormat.TwosComplement)]
		public uint curturn
		{
			get
			{
				return this._curturn ?? 0U;
			}
			set
			{
				this._curturn = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curturnSpecified
		{
			get
			{
				return this._curturn != null;
			}
			set
			{
				bool flag = value == (this._curturn == null);
				if (flag)
				{
					this._curturn = (value ? new uint?(this.curturn) : null);
				}
			}
		}

		private bool ShouldSerializecurturn()
		{
			return this.curturnSpecified;
		}

		private void Resetcurturn()
		{
			this.curturnSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GuildArenaType? _battletype;

		private uint? _applytime;

		private bool? _isapply;

		private uint? _curturn;

		private IExtension extensionObject;
	}
}
