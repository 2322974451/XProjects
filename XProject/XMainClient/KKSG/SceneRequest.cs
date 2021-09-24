using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneRequest")]
	[Serializable]
	public class SceneRequest : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "fortID", DataFormat = DataFormat.TwosComplement)]
		public uint fortID
		{
			get
			{
				return this._fortID ?? 0U;
			}
			set
			{
				this._fortID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fortIDSpecified
		{
			get
			{
				return this._fortID != null;
			}
			set
			{
				bool flag = value == (this._fortID == null);
				if (flag)
				{
					this._fortID = (value ? new uint?(this.fortID) : null);
				}
			}
		}

		private bool ShouldSerializefortID()
		{
			return this.fortIDSpecified;
		}

		private void ResetfortID()
		{
			this.fortIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _sceneID;

		private ulong? _roleID;

		private uint? _fortID;

		private IExtension extensionObject;
	}
}
