using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlantHarvestRes")]
	[Serializable]
	public class PlantHarvestRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "harvest", DataFormat = DataFormat.Default)]
		public bool harvest
		{
			get
			{
				return this._harvest ?? false;
			}
			set
			{
				this._harvest = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool harvestSpecified
		{
			get
			{
				return this._harvest != null;
			}
			set
			{
				bool flag = value == (this._harvest == null);
				if (flag)
				{
					this._harvest = (value ? new bool?(this.harvest) : null);
				}
			}
		}

		private bool ShouldSerializeharvest()
		{
			return this.harvestSpecified;
		}

		private void Resetharvest()
		{
			this.harvestSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "extra", DataFormat = DataFormat.Default)]
		public bool extra
		{
			get
			{
				return this._extra ?? false;
			}
			set
			{
				this._extra = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extraSpecified
		{
			get
			{
				return this._extra != null;
			}
			set
			{
				bool flag = value == (this._extra == null);
				if (flag)
				{
					this._extra = (value ? new bool?(this.extra) : null);
				}
			}
		}

		private bool ShouldSerializeextra()
		{
			return this.extraSpecified;
		}

		private void Resetextra()
		{
			this.extraSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private bool? _harvest;

		private bool? _extra;

		private IExtension extensionObject;
	}
}
