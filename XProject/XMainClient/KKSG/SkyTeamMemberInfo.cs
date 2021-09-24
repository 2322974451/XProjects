using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyTeamMemberInfo")]
	[Serializable]
	public class SkyTeamMemberInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "brief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleOutLookBrief brief
		{
			get
			{
				return this._brief;
			}
			set
			{
				this._brief = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleOutLookBrief _brief = null;

		private IExtension extensionObject;
	}
}
