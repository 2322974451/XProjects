using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftSceneInfoNtfData")]
	[Serializable]
	public class RiftSceneInfoNtfData : IExtensible
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

		[ProtoMember(2, Name = "buffIDs", DataFormat = DataFormat.Default)]
		public List<Buff> buffIDs
		{
			get
			{
				return this._buffIDs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _floor;

		private readonly List<Buff> _buffIDs = new List<Buff>();

		private IExtension extensionObject;
	}
}
