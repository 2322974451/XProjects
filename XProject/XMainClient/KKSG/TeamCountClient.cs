using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamCountClient")]
	[Serializable]
	public class TeamCountClient : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamtype", DataFormat = DataFormat.TwosComplement)]
		public int teamtype
		{
			get
			{
				return this._teamtype ?? 0;
			}
			set
			{
				this._teamtype = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamtypeSpecified
		{
			get
			{
				return this._teamtype != null;
			}
			set
			{
				bool flag = value == (this._teamtype == null);
				if (flag)
				{
					this._teamtype = (value ? new int?(this.teamtype) : null);
				}
			}
		}

		private bool ShouldSerializeteamtype()
		{
			return this.teamtypeSpecified;
		}

		private void Resetteamtype()
		{
			this.teamtypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public int buycount
		{
			get
			{
				return this._buycount ?? 0;
			}
			set
			{
				this._buycount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new int?(this.buycount) : null);
				}
			}
		}

		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "maxcount", DataFormat = DataFormat.TwosComplement)]
		public int maxcount
		{
			get
			{
				return this._maxcount ?? 0;
			}
			set
			{
				this._maxcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxcountSpecified
		{
			get
			{
				return this._maxcount != null;
			}
			set
			{
				bool flag = value == (this._maxcount == null);
				if (flag)
				{
					this._maxcount = (value ? new int?(this.maxcount) : null);
				}
			}
		}

		private bool ShouldSerializemaxcount()
		{
			return this.maxcountSpecified;
		}

		private void Resetmaxcount()
		{
			this.maxcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _teamtype;

		private int? _leftcount;

		private int? _buycount;

		private int? _maxcount;

		private IExtension extensionObject;
	}
}
