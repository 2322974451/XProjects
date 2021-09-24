using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityRes")]
	[Serializable]
	public class SkyCityRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "baseinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCityAllTeamBaseInfo baseinfo
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
		public SkyCityAllInfo allinfo
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

		private SkyCityAllTeamBaseInfo _baseinfo = null;

		private SkyCityAllInfo _allinfo = null;

		private IExtension extensionObject;
	}
}
