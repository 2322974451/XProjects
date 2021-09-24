using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneStateNtf")]
	[Serializable]
	public class SceneStateNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SSceneState state
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "rolespecialstate", DataFormat = DataFormat.TwosComplement)]
		public uint rolespecialstate
		{
			get
			{
				return this._rolespecialstate ?? 0U;
			}
			set
			{
				this._rolespecialstate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolespecialstateSpecified
		{
			get
			{
				return this._rolespecialstate != null;
			}
			set
			{
				bool flag = value == (this._rolespecialstate == null);
				if (flag)
				{
					this._rolespecialstate = (value ? new uint?(this.rolespecialstate) : null);
				}
			}
		}

		private bool ShouldSerializerolespecialstate()
		{
			return this.rolespecialstateSpecified;
		}

		private void Resetrolespecialstate()
		{
			this.rolespecialstateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private SSceneState _state = null;

		private uint? _rolespecialstate;

		private IExtension extensionObject;
	}
}
