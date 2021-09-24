using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TajieHelpSceneData")]
	[Serializable]
	public class TajieHelpSceneData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "intervalContinueFailTimes", DataFormat = DataFormat.TwosComplement)]
		public int intervalContinueFailTimes
		{
			get
			{
				return this._intervalContinueFailTimes ?? 0;
			}
			set
			{
				this._intervalContinueFailTimes = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool intervalContinueFailTimesSpecified
		{
			get
			{
				return this._intervalContinueFailTimes != null;
			}
			set
			{
				bool flag = value == (this._intervalContinueFailTimes == null);
				if (flag)
				{
					this._intervalContinueFailTimes = (value ? new int?(this.intervalContinueFailTimes) : null);
				}
			}
		}

		private bool ShouldSerializeintervalContinueFailTimes()
		{
			return this.intervalContinueFailTimesSpecified;
		}

		private void ResetintervalContinueFailTimes()
		{
			this.intervalContinueFailTimesSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "intervalFailNoticeTimes", DataFormat = DataFormat.TwosComplement)]
		public int intervalFailNoticeTimes
		{
			get
			{
				return this._intervalFailNoticeTimes ?? 0;
			}
			set
			{
				this._intervalFailNoticeTimes = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool intervalFailNoticeTimesSpecified
		{
			get
			{
				return this._intervalFailNoticeTimes != null;
			}
			set
			{
				bool flag = value == (this._intervalFailNoticeTimes == null);
				if (flag)
				{
					this._intervalFailNoticeTimes = (value ? new int?(this.intervalFailNoticeTimes) : null);
				}
			}
		}

		private bool ShouldSerializeintervalFailNoticeTimes()
		{
			return this.intervalFailNoticeTimesSpecified;
		}

		private void ResetintervalFailNoticeTimes()
		{
			this.intervalFailNoticeTimesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _sceneID;

		private int? _intervalContinueFailTimes;

		private int? _intervalFailNoticeTimes;

		private IExtension extensionObject;
	}
}
