using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFBattleField")]
	[Serializable]
	public class GCFBattleField : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public uint mapid
		{
			get
			{
				return this._mapid ?? 0U;
			}
			set
			{
				this._mapid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new uint?(this.mapid) : null);
				}
			}
		}

		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		[ProtoMember(2, Name = "jvdians", DataFormat = DataFormat.Default)]
		public List<GCFJvDianInfo> jvdians
		{
			get
			{
				return this._jvdians;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "zhanchinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFZhanChBriefInfo zhanchinfo
		{
			get
			{
				return this._zhanchinfo;
			}
			set
			{
				this._zhanchinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _mapid;

		private readonly List<GCFJvDianInfo> _jvdians = new List<GCFJvDianInfo>();

		private GCFZhanChBriefInfo _zhanchinfo = null;

		private IExtension extensionObject;
	}
}
