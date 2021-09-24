using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActivityRoleNotify")]
	[Serializable]
	public class ActivityRoleNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ActivityRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ActivityRecord ActivityRecord
		{
			get
			{
				return this._ActivityRecord;
			}
			set
			{
				this._ActivityRecord = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ActivityRecord _ActivityRecord = null;

		private IExtension extensionObject;
	}
}
