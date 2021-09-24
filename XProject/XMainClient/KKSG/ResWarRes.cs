using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarRes")]
	[Serializable]
	public class ResWarRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "baseinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarAllTeamBaseInfo baseinfo
		{
			get
			{
				return this._baseinfo;
			}
			set
			{
				this._baseinfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "allinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarAllInfo allinfo
		{
			get
			{
				return this._allinfo;
			}
			set
			{
				this._allinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ResWarAllTeamBaseInfo _baseinfo = null;

		private ResWarAllInfo _allinfo = null;

		private IExtension extensionObject;
	}
}
