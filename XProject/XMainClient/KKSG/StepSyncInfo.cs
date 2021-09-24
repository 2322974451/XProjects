using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StepSyncInfo")]
	[Serializable]
	public class StepSyncInfo : IExtensible
	{

		[ProtoMember(1, Name = "DataList", DataFormat = DataFormat.Default)]
		public List<StepSyncData> DataList
		{
			get
			{
				return this._DataList;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "StepFrame", DataFormat = DataFormat.TwosComplement)]
		public uint StepFrame
		{
			get
			{
				return this._StepFrame ?? 0U;
			}
			set
			{
				this._StepFrame = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool StepFrameSpecified
		{
			get
			{
				return this._StepFrame != null;
			}
			set
			{
				bool flag = value == (this._StepFrame == null);
				if (flag)
				{
					this._StepFrame = (value ? new uint?(this.StepFrame) : null);
				}
			}
		}

		private bool ShouldSerializeStepFrame()
		{
			return this.StepFrameSpecified;
		}

		private void ResetStepFrame()
		{
			this.StepFrameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<StepSyncData> _DataList = new List<StepSyncData>();

		private uint? _StepFrame;

		private IExtension extensionObject;
	}
}
