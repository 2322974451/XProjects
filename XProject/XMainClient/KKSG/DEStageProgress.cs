using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DEStageProgress")]
	[Serializable]
	public class DEStageProgress : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, Name = "bossids", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bossids
		{
			get
			{
				return this._bossids;
			}
		}

		[ProtoMember(3, Name = "bosshppercenet", DataFormat = DataFormat.TwosComplement)]
		public List<int> bosshppercenet
		{
			get
			{
				return this._bosshppercenet;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _sceneid;

		private readonly List<uint> _bossids = new List<uint>();

		private readonly List<int> _bosshppercenet = new List<int>();

		private IExtension extensionObject;
	}
}
