using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpActivityOne")]
	[Serializable]
	public class SpActivityOne : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		[ProtoMember(2, Name = "task", DataFormat = DataFormat.Default)]
		public List<SpActivityTask> task
		{
			get
			{
				return this._task;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "getBigPrize", DataFormat = DataFormat.Default)]
		public bool getBigPrize
		{
			get
			{
				return this._getBigPrize ?? false;
			}
			set
			{
				this._getBigPrize = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getBigPrizeSpecified
		{
			get
			{
				return this._getBigPrize != null;
			}
			set
			{
				bool flag = value == (this._getBigPrize == null);
				if (flag)
				{
					this._getBigPrize = (value ? new bool?(this.getBigPrize) : null);
				}
			}
		}

		private bool ShouldSerializegetBigPrize()
		{
			return this.getBigPrizeSpecified;
		}

		private void ResetgetBigPrize()
		{
			this.getBigPrizeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "startTime", DataFormat = DataFormat.TwosComplement)]
		public uint startTime
		{
			get
			{
				return this._startTime ?? 0U;
			}
			set
			{
				this._startTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool startTimeSpecified
		{
			get
			{
				return this._startTime != null;
			}
			set
			{
				bool flag = value == (this._startTime == null);
				if (flag)
				{
					this._startTime = (value ? new uint?(this.startTime) : null);
				}
			}
		}

		private bool ShouldSerializestartTime()
		{
			return this.startTimeSpecified;
		}

		private void ResetstartTime()
		{
			this.startTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "actStage", DataFormat = DataFormat.TwosComplement)]
		public uint actStage
		{
			get
			{
				return this._actStage ?? 0U;
			}
			set
			{
				this._actStage = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool actStageSpecified
		{
			get
			{
				return this._actStage != null;
			}
			set
			{
				bool flag = value == (this._actStage == null);
				if (flag)
				{
					this._actStage = (value ? new uint?(this.actStage) : null);
				}
			}
		}

		private bool ShouldSerializeactStage()
		{
			return this.actStageSpecified;
		}

		private void ResetactStage()
		{
			this.actStageSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "argenta", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ArgentaData argenta
		{
			get
			{
				return this._argenta;
			}
			set
			{
				this._argenta = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ancient", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AncientTimes ancient
		{
			get
			{
				return this._ancient;
			}
			set
			{
				this._ancient = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "theme", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ThemeActivityData theme
		{
			get
			{
				return this._theme;
			}
			set
			{
				this._theme = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "backflow", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowData backflow
		{
			get
			{
				return this._backflow;
			}
			set
			{
				this._backflow = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "campduel", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CampDuelData campduel
		{
			get
			{
				return this._campduel;
			}
			set
			{
				this._campduel = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "festival520", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Festival520Data festival520
		{
			get
			{
				return this._festival520;
			}
			set
			{
				this._festival520 = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "shadowcat", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ShadowCatData shadowcat
		{
			get
			{
				return this._shadowcat;
			}
			set
			{
				this._shadowcat = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _actid;

		private readonly List<SpActivityTask> _task = new List<SpActivityTask>();

		private bool? _getBigPrize;

		private uint? _startTime;

		private uint? _actStage;

		private ArgentaData _argenta = null;

		private AncientTimes _ancient = null;

		private ThemeActivityData _theme = null;

		private BackFlowData _backflow = null;

		private CampDuelData _campduel = null;

		private Festival520Data _festival520 = null;

		private ShadowCatData _shadowcat = null;

		private IExtension extensionObject;
	}
}
