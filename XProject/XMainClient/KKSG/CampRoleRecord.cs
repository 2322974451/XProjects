using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampRoleRecord")]
	[Serializable]
	public class CampRoleRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastCampID", DataFormat = DataFormat.TwosComplement)]
		public uint lastCampID
		{
			get
			{
				return this._lastCampID ?? 0U;
			}
			set
			{
				this._lastCampID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastCampIDSpecified
		{
			get
			{
				return this._lastCampID != null;
			}
			set
			{
				bool flag = value == (this._lastCampID == null);
				if (flag)
				{
					this._lastCampID = (value ? new uint?(this.lastCampID) : null);
				}
			}
		}

		private bool ShouldSerializelastCampID()
		{
			return this.lastCampIDSpecified;
		}

		private void ResetlastCampID()
		{
			this.lastCampIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "taskInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CampTaskInfo2DB taskInfo
		{
			get
			{
				return this._taskInfo;
			}
			set
			{
				this._taskInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastCampID;

		private CampTaskInfo2DB _taskInfo = null;

		private IExtension extensionObject;
	}
}
