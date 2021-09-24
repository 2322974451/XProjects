using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowShopData")]
	[Serializable]
	public class BackFlowShopData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		[ProtoMember(2, Name = "goods", DataFormat = DataFormat.Default)]
		public List<BackFlowShopGood> goods
		{
			get
			{
				return this._goods;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "freshCount", DataFormat = DataFormat.TwosComplement)]
		public uint freshCount
		{
			get
			{
				return this._freshCount ?? 0U;
			}
			set
			{
				this._freshCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freshCountSpecified
		{
			get
			{
				return this._freshCount != null;
			}
			set
			{
				bool flag = value == (this._freshCount == null);
				if (flag)
				{
					this._freshCount = (value ? new uint?(this.freshCount) : null);
				}
			}
		}

		private bool ShouldSerializefreshCount()
		{
			return this.freshCountSpecified;
		}

		private void ResetfreshCount()
		{
			this.freshCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastUpdateTime;

		private readonly List<BackFlowShopGood> _goods = new List<BackFlowShopGood>();

		private uint? _freshCount;

		private IExtension extensionObject;
	}
}
