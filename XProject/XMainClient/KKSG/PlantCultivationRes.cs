using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlantCultivationRes")]
	[Serializable]
	public class PlantCultivationRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "growup_amount", DataFormat = DataFormat.FixedSize)]
		public float growup_amount
		{
			get
			{
				return this._growup_amount ?? 0f;
			}
			set
			{
				this._growup_amount = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool growup_amountSpecified
		{
			get
			{
				return this._growup_amount != null;
			}
			set
			{
				bool flag = value == (this._growup_amount == null);
				if (flag)
				{
					this._growup_amount = (value ? new float?(this.growup_amount) : null);
				}
			}
		}

		private bool ShouldSerializegrowup_amount()
		{
			return this.growup_amountSpecified;
		}

		private void Resetgrowup_amount()
		{
			this.growup_amountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "notice_times", DataFormat = DataFormat.TwosComplement)]
		public uint notice_times
		{
			get
			{
				return this._notice_times ?? 0U;
			}
			set
			{
				this._notice_times = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool notice_timesSpecified
		{
			get
			{
				return this._notice_times != null;
			}
			set
			{
				bool flag = value == (this._notice_times == null);
				if (flag)
				{
					this._notice_times = (value ? new uint?(this.notice_times) : null);
				}
			}
		}

		private bool ShouldSerializenotice_times()
		{
			return this.notice_timesSpecified;
		}

		private void Resetnotice_times()
		{
			this.notice_timesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private float? _growup_amount;

		private uint? _notice_times;

		private IExtension extensionObject;
	}
}
