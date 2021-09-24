using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AllyMatchRoleID")]
	[Serializable]
	public class AllyMatchRoleID : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "allyID", DataFormat = DataFormat.TwosComplement)]
		public ulong allyID
		{
			get
			{
				return this._allyID ?? 0UL;
			}
			set
			{
				this._allyID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allyIDSpecified
		{
			get
			{
				return this._allyID != null;
			}
			set
			{
				bool flag = value == (this._allyID == null);
				if (flag)
				{
					this._allyID = (value ? new ulong?(this.allyID) : null);
				}
			}
		}

		private bool ShouldSerializeallyID()
		{
			return this.allyIDSpecified;
		}

		private void ResetallyID()
		{
			this.allyIDSpecified = false;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _allyID;

		private ulong? _roleID;

		private IExtension extensionObject;
	}
}
