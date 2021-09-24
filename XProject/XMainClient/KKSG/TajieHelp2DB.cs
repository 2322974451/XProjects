using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TajieHelp2DB")]
	[Serializable]
	public class TajieHelp2DB : IExtensible
	{

		[ProtoMember(1, Name = "taJieHelpSceneData", DataFormat = DataFormat.Default)]
		public List<TajieHelpSceneData> taJieHelpSceneData
		{
			get
			{
				return this._taJieHelpSceneData;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public int updateTime
		{
			get
			{
				return this._updateTime ?? 0;
			}
			set
			{
				this._updateTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new int?(this.updateTime) : null);
				}
			}
		}

		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<TajieHelpSceneData> _taJieHelpSceneData = new List<TajieHelpSceneData>();

		private int? _updateTime;

		private IExtension extensionObject;
	}
}
