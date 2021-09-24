using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArgentaPreData")]
	[Serializable]
	public class ArgentaPreData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		[ProtoMember(2, Name = "activityPoint", DataFormat = DataFormat.TwosComplement)]
		public List<uint> activityPoint
		{
			get
			{
				return this._activityPoint;
			}
		}

		[ProtoMember(3, Name = "finishNestCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> finishNestCount
		{
			get
			{
				return this._finishNestCount;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastUpdateTime;

		private readonly List<uint> _activityPoint = new List<uint>();

		private readonly List<uint> _finishNestCount = new List<uint>();

		private IExtension extensionObject;
	}
}
