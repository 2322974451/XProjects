using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMarriageLivenessRes")]
	[Serializable]
	public class GetMarriageLivenessRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "liveness", DataFormat = DataFormat.TwosComplement)]
		public uint liveness
		{
			get
			{
				return this._liveness ?? 0U;
			}
			set
			{
				this._liveness = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool livenessSpecified
		{
			get
			{
				return this._liveness != null;
			}
			set
			{
				bool flag = value == (this._liveness == null);
				if (flag)
				{
					this._liveness = (value ? new uint?(this.liveness) : null);
				}
			}
		}

		private bool ShouldSerializeliveness()
		{
			return this.livenessSpecified;
		}

		private void Resetliveness()
		{
			this.livenessSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "takedchest", DataFormat = DataFormat.TwosComplement)]
		public uint takedchest
		{
			get
			{
				return this._takedchest ?? 0U;
			}
			set
			{
				this._takedchest = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool takedchestSpecified
		{
			get
			{
				return this._takedchest != null;
			}
			set
			{
				bool flag = value == (this._takedchest == null);
				if (flag)
				{
					this._takedchest = (value ? new uint?(this.takedchest) : null);
				}
			}
		}

		private bool ShouldSerializetakedchest()
		{
			return this.takedchestSpecified;
		}

		private void Resettakedchest()
		{
			this.takedchestSpecified = false;
		}

		[ProtoMember(4, Name = "record", DataFormat = DataFormat.Default)]
		public List<PartnerLivenessItem> record
		{
			get
			{
				return this._record;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _liveness;

		private uint? _takedchest;

		private readonly List<PartnerLivenessItem> _record = new List<PartnerLivenessItem>();

		private IExtension extensionObject;
	}
}
