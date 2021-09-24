using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GoalAwardsGetAwards_C2M")]
	[Serializable]
	public class GoalAwardsGetAwards_C2M : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "goalAwardsID", DataFormat = DataFormat.TwosComplement)]
		public uint goalAwardsID
		{
			get
			{
				return this._goalAwardsID ?? 0U;
			}
			set
			{
				this._goalAwardsID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goalAwardsIDSpecified
		{
			get
			{
				return this._goalAwardsID != null;
			}
			set
			{
				bool flag = value == (this._goalAwardsID == null);
				if (flag)
				{
					this._goalAwardsID = (value ? new uint?(this.goalAwardsID) : null);
				}
			}
		}

		private bool ShouldSerializegoalAwardsID()
		{
			return this.goalAwardsIDSpecified;
		}

		private void ResetgoalAwardsID()
		{
			this.goalAwardsIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _goalAwardsID;

		private IExtension extensionObject;
	}
}
