using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GlobalRiftFloorInfo")]
	[Serializable]
	public class GlobalRiftFloorInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public int floor
		{
			get
			{
				return this._floor ?? 0;
			}
			set
			{
				this._floor = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new int?(this.floor) : null);
				}
			}
		}

		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		[ProtoMember(3, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<MapIntItem> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _floor;

		private uint? _sceneid;

		private readonly List<MapIntItem> _buffs = new List<MapIntItem>();

		private IExtension extensionObject;
	}
}
