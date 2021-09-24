using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpActivity")]
	[Serializable]
	public class SpActivity : IExtensible
	{

		[ProtoMember(1, Name = "spActivity", DataFormat = DataFormat.Default)]
		public List<SpActivityOne> spActivity
		{
			get
			{
				return this._spActivity;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "lastBackFlowStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastBackFlowStartTime
		{
			get
			{
				return this._lastBackFlowStartTime ?? 0U;
			}
			set
			{
				this._lastBackFlowStartTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastBackFlowStartTimeSpecified
		{
			get
			{
				return this._lastBackFlowStartTime != null;
			}
			set
			{
				bool flag = value == (this._lastBackFlowStartTime == null);
				if (flag)
				{
					this._lastBackFlowStartTime = (value ? new uint?(this.lastBackFlowStartTime) : null);
				}
			}
		}

		private bool ShouldSerializelastBackFlowStartTime()
		{
			return this.lastBackFlowStartTimeSpecified;
		}

		private void ResetlastBackFlowStartTime()
		{
			this.lastBackFlowStartTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "argentaPreData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ArgentaPreData argentaPreData
		{
			get
			{
				return this._argentaPreData;
			}
			set
			{
				this._argentaPreData = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "lastArgentaStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastArgentaStartTime
		{
			get
			{
				return this._lastArgentaStartTime ?? 0U;
			}
			set
			{
				this._lastArgentaStartTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastArgentaStartTimeSpecified
		{
			get
			{
				return this._lastArgentaStartTime != null;
			}
			set
			{
				bool flag = value == (this._lastArgentaStartTime == null);
				if (flag)
				{
					this._lastArgentaStartTime = (value ? new uint?(this.lastArgentaStartTime) : null);
				}
			}
		}

		private bool ShouldSerializelastArgentaStartTime()
		{
			return this.lastArgentaStartTimeSpecified;
		}

		private void ResetlastArgentaStartTime()
		{
			this.lastArgentaStartTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "backflowPreData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowPreData backflowPreData
		{
			get
			{
				return this._backflowPreData;
			}
			set
			{
				this._backflowPreData = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SpActivityOne> _spActivity = new List<SpActivityOne>();

		private uint? _lastBackFlowStartTime;

		private ArgentaPreData _argentaPreData = null;

		private uint? _lastArgentaStartTime;

		private BackFlowPreData _backflowPreData = null;

		private IExtension extensionObject;
	}
}
