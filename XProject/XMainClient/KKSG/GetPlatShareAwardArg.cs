using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPlatShareAwardArg")]
	[Serializable]
	public class GetPlatShareAwardArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "scene_id", DataFormat = DataFormat.TwosComplement)]
		public uint scene_id
		{
			get
			{
				return this._scene_id ?? 0U;
			}
			set
			{
				this._scene_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scene_idSpecified
		{
			get
			{
				return this._scene_id != null;
			}
			set
			{
				bool flag = value == (this._scene_id == null);
				if (flag)
				{
					this._scene_id = (value ? new uint?(this.scene_id) : null);
				}
			}
		}

		private bool ShouldSerializescene_id()
		{
			return this.scene_idSpecified;
		}

		private void Resetscene_id()
		{
			this.scene_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _scene_id;

		private IExtension extensionObject;
	}
}
