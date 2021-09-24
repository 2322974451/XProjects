using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyPlatShareResultArg")]
	[Serializable]
	public class NotifyPlatShareResultArg : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "redpoint_disappear", DataFormat = DataFormat.Default)]
		public bool redpoint_disappear
		{
			get
			{
				return this._redpoint_disappear ?? false;
			}
			set
			{
				this._redpoint_disappear = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool redpoint_disappearSpecified
		{
			get
			{
				return this._redpoint_disappear != null;
			}
			set
			{
				bool flag = value == (this._redpoint_disappear == null);
				if (flag)
				{
					this._redpoint_disappear = (value ? new bool?(this.redpoint_disappear) : null);
				}
			}
		}

		private bool ShouldSerializeredpoint_disappear()
		{
			return this.redpoint_disappearSpecified;
		}

		private void Resetredpoint_disappear()
		{
			this.redpoint_disappearSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _scene_id;

		private bool? _redpoint_disappear;

		private IExtension extensionObject;
	}
}
