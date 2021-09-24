using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcFeelingRecord")]
	[Serializable]
	public class NpcFeelingRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastupdaytime", DataFormat = DataFormat.TwosComplement)]
		public uint lastupdaytime
		{
			get
			{
				return this._lastupdaytime ?? 0U;
			}
			set
			{
				this._lastupdaytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastupdaytimeSpecified
		{
			get
			{
				return this._lastupdaytime != null;
			}
			set
			{
				bool flag = value == (this._lastupdaytime == null);
				if (flag)
				{
					this._lastupdaytime = (value ? new uint?(this.lastupdaytime) : null);
				}
			}
		}

		private bool ShouldSerializelastupdaytime()
		{
			return this.lastupdaytimeSpecified;
		}

		private void Resetlastupdaytime()
		{
			this.lastupdaytimeSpecified = false;
		}

		[ProtoMember(2, Name = "npclist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingOneNpc> npclist
		{
			get
			{
				return this._npclist;
			}
		}

		[ProtoMember(3, Name = "unitelist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingUnite> unitelist
		{
			get
			{
				return this._unitelist;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "exchangecount", DataFormat = DataFormat.TwosComplement)]
		public uint exchangecount
		{
			get
			{
				return this._exchangecount ?? 0U;
			}
			set
			{
				this._exchangecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool exchangecountSpecified
		{
			get
			{
				return this._exchangecount != null;
			}
			set
			{
				bool flag = value == (this._exchangecount == null);
				if (flag)
				{
					this._exchangecount = (value ? new uint?(this.exchangecount) : null);
				}
			}
		}

		private bool ShouldSerializeexchangecount()
		{
			return this.exchangecountSpecified;
		}

		private void Resetexchangecount()
		{
			this.exchangecountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "returncount", DataFormat = DataFormat.TwosComplement)]
		public uint returncount
		{
			get
			{
				return this._returncount ?? 0U;
			}
			set
			{
				this._returncount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool returncountSpecified
		{
			get
			{
				return this._returncount != null;
			}
			set
			{
				bool flag = value == (this._returncount == null);
				if (flag)
				{
					this._returncount = (value ? new uint?(this.returncount) : null);
				}
			}
		}

		private bool ShouldSerializereturncount()
		{
			return this.returncountSpecified;
		}

		private void Resetreturncount()
		{
			this.returncountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "givecount", DataFormat = DataFormat.TwosComplement)]
		public uint givecount
		{
			get
			{
				return this._givecount ?? 0U;
			}
			set
			{
				this._givecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool givecountSpecified
		{
			get
			{
				return this._givecount != null;
			}
			set
			{
				bool flag = value == (this._givecount == null);
				if (flag)
				{
					this._givecount = (value ? new uint?(this.givecount) : null);
				}
			}
		}

		private bool ShouldSerializegivecount()
		{
			return this.givecountSpecified;
		}

		private void Resetgivecount()
		{
			this.givecountSpecified = false;
		}

		[ProtoMember(7, Name = "nouse", DataFormat = DataFormat.Default)]
		public List<ItemBrief> nouse
		{
			get
			{
				return this._nouse;
			}
		}

		[ProtoMember(8, Name = "returndrop", DataFormat = DataFormat.Default)]
		public List<NpcFlReturn> returndrop
		{
			get
			{
				return this._returndrop;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
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
					this._buycount = (value ? new uint?(this.buycount) : null);
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

		[ProtoMember(10, IsRequired = false, Name = "triggerfavorcount", DataFormat = DataFormat.TwosComplement)]
		public uint triggerfavorcount
		{
			get
			{
				return this._triggerfavorcount ?? 0U;
			}
			set
			{
				this._triggerfavorcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool triggerfavorcountSpecified
		{
			get
			{
				return this._triggerfavorcount != null;
			}
			set
			{
				bool flag = value == (this._triggerfavorcount == null);
				if (flag)
				{
					this._triggerfavorcount = (value ? new uint?(this.triggerfavorcount) : null);
				}
			}
		}

		private bool ShouldSerializetriggerfavorcount()
		{
			return this.triggerfavorcountSpecified;
		}

		private void Resettriggerfavorcount()
		{
			this.triggerfavorcountSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "giveleftaddcount", DataFormat = DataFormat.TwosComplement)]
		public uint giveleftaddcount
		{
			get
			{
				return this._giveleftaddcount ?? 0U;
			}
			set
			{
				this._giveleftaddcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool giveleftaddcountSpecified
		{
			get
			{
				return this._giveleftaddcount != null;
			}
			set
			{
				bool flag = value == (this._giveleftaddcount == null);
				if (flag)
				{
					this._giveleftaddcount = (value ? new uint?(this.giveleftaddcount) : null);
				}
			}
		}

		private bool ShouldSerializegiveleftaddcount()
		{
			return this.giveleftaddcountSpecified;
		}

		private void Resetgiveleftaddcount()
		{
			this.giveleftaddcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastupdaytime;

		private readonly List<NpcFeelingOneNpc> _npclist = new List<NpcFeelingOneNpc>();

		private readonly List<NpcFeelingUnite> _unitelist = new List<NpcFeelingUnite>();

		private uint? _exchangecount;

		private uint? _returncount;

		private uint? _givecount;

		private readonly List<ItemBrief> _nouse = new List<ItemBrief>();

		private readonly List<NpcFlReturn> _returndrop = new List<NpcFlReturn>();

		private uint? _buycount;

		private uint? _triggerfavorcount;

		private uint? _giveleftaddcount;

		private IExtension extensionObject;
	}
}
