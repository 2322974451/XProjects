using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamSynRift")]
	[Serializable]
	public class TeamSynRift : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "riftid", DataFormat = DataFormat.TwosComplement)]
		public uint riftid
		{
			get
			{
				return this._riftid ?? 0U;
			}
			set
			{
				this._riftid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool riftidSpecified
		{
			get
			{
				return this._riftid != null;
			}
			set
			{
				bool flag = value == (this._riftid == null);
				if (flag)
				{
					this._riftid = (value ? new uint?(this.riftid) : null);
				}
			}
		}

		private bool ShouldSerializeriftid()
		{
			return this.riftidSpecified;
		}

		private void Resetriftid()
		{
			this.riftidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "floorinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GlobalRiftFloorInfo floorinfo
		{
			get
			{
				return this._floorinfo;
			}
			set
			{
				this._floorinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _riftid;

		private GlobalRiftFloorInfo _floorinfo = null;

		private IExtension extensionObject;
	}
}
