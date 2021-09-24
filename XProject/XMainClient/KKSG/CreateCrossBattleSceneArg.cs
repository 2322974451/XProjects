using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CreateCrossBattleSceneArg")]
	[Serializable]
	public class CreateCrossBattleSceneArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public uint mapID
		{
			get
			{
				return this._mapID ?? 0U;
			}
			set
			{
				this._mapID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new uint?(this.mapID) : null);
				}
			}
		}

		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		[ProtoMember(2, Name = "createInfos", DataFormat = DataFormat.Default)]
		public List<CreateCrossBattleSceneData> createInfos
		{
			get
			{
				return this._createInfos;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "smallInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public InvFightBefESpara smallInfo
		{
			get
			{
				return this._smallInfo;
			}
			set
			{
				this._smallInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _mapID;

		private readonly List<CreateCrossBattleSceneData> _createInfos = new List<CreateCrossBattleSceneData>();

		private InvFightBefESpara _smallInfo = null;

		private IExtension extensionObject;
	}
}
