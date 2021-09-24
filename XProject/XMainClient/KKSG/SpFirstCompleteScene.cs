using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpFirstCompleteScene")]
	[Serializable]
	public class SpFirstCompleteScene : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "scenetype", DataFormat = DataFormat.TwosComplement)]
		public uint scenetype
		{
			get
			{
				return this._scenetype ?? 0U;
			}
			set
			{
				this._scenetype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scenetypeSpecified
		{
			get
			{
				return this._scenetype != null;
			}
			set
			{
				bool flag = value == (this._scenetype == null);
				if (flag)
				{
					this._scenetype = (value ? new uint?(this.scenetype) : null);
				}
			}
		}

		private bool ShouldSerializescenetype()
		{
			return this.scenetypeSpecified;
		}

		private void Resetscenetype()
		{
			this.scenetypeSpecified = false;
		}

		[ProtoMember(2, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> sceneid
		{
			get
			{
				return this._sceneid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _scenetype;

		private readonly List<uint> _sceneid = new List<uint>();

		private IExtension extensionObject;
	}
}
