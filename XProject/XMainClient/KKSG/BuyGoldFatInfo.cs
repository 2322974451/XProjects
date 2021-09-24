using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyGoldFatInfo")]
	[Serializable]
	public class BuyGoldFatInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public uint day
		{
			get
			{
				return this._day ?? 0U;
			}
			set
			{
				this._day = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new uint?(this.day) : null);
				}
			}
		}

		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		private void Resetday()
		{
			this.daySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "BuyGoldCount", DataFormat = DataFormat.TwosComplement)]
		public int BuyGoldCount
		{
			get
			{
				return this._BuyGoldCount ?? 0;
			}
			set
			{
				this._BuyGoldCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BuyGoldCountSpecified
		{
			get
			{
				return this._BuyGoldCount != null;
			}
			set
			{
				bool flag = value == (this._BuyGoldCount == null);
				if (flag)
				{
					this._BuyGoldCount = (value ? new int?(this.BuyGoldCount) : null);
				}
			}
		}

		private bool ShouldSerializeBuyGoldCount()
		{
			return this.BuyGoldCountSpecified;
		}

		private void ResetBuyGoldCount()
		{
			this.BuyGoldCountSpecified = false;
		}

		[ProtoMember(3, Name = "BuyFatigueCount", DataFormat = DataFormat.TwosComplement)]
		public List<int> BuyFatigueCount
		{
			get
			{
				return this._BuyFatigueCount;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "BuyDragonCount", DataFormat = DataFormat.TwosComplement)]
		public int BuyDragonCount
		{
			get
			{
				return this._BuyDragonCount ?? 0;
			}
			set
			{
				this._BuyDragonCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BuyDragonCountSpecified
		{
			get
			{
				return this._BuyDragonCount != null;
			}
			set
			{
				bool flag = value == (this._BuyDragonCount == null);
				if (flag)
				{
					this._BuyDragonCount = (value ? new int?(this.BuyDragonCount) : null);
				}
			}
		}

		private bool ShouldSerializeBuyDragonCount()
		{
			return this.BuyDragonCountSpecified;
		}

		private void ResetBuyDragonCount()
		{
			this.BuyDragonCountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "backflow", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowBuy backflow
		{
			get
			{
				return this._backflow;
			}
			set
			{
				this._backflow = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _day;

		private int? _BuyGoldCount;

		private readonly List<int> _BuyFatigueCount = new List<int>();

		private int? _BuyDragonCount;

		private BackFlowBuy _backflow = null;

		private IExtension extensionObject;
	}
}
