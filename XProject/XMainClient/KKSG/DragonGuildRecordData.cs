using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildRecordData")]
	[Serializable]
	public class DragonGuildRecordData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong dragonguildid
		{
			get
			{
				return this._dragonguildid ?? 0UL;
			}
			set
			{
				this._dragonguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildidSpecified
		{
			get
			{
				return this._dragonguildid != null;
			}
			set
			{
				bool flag = value == (this._dragonguildid == null);
				if (flag)
				{
					this._dragonguildid = (value ? new ulong?(this.dragonguildid) : null);
				}
			}
		}

		private bool ShouldSerializedragonguildid()
		{
			return this.dragonguildidSpecified;
		}

		private void Resetdragonguildid()
		{
			this.dragonguildidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "taked_chest", DataFormat = DataFormat.TwosComplement)]
		public uint taked_chest
		{
			get
			{
				return this._taked_chest ?? 0U;
			}
			set
			{
				this._taked_chest = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool taked_chestSpecified
		{
			get
			{
				return this._taked_chest != null;
			}
			set
			{
				bool flag = value == (this._taked_chest == null);
				if (flag)
				{
					this._taked_chest = (value ? new uint?(this.taked_chest) : null);
				}
			}
		}

		private bool ShouldSerializetaked_chest()
		{
			return this.taked_chestSpecified;
		}

		private void Resettaked_chest()
		{
			this.taked_chestSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "chest_redpoint", DataFormat = DataFormat.Default)]
		public bool chest_redpoint
		{
			get
			{
				return this._chest_redpoint ?? false;
			}
			set
			{
				this._chest_redpoint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chest_redpointSpecified
		{
			get
			{
				return this._chest_redpoint != null;
			}
			set
			{
				bool flag = value == (this._chest_redpoint == null);
				if (flag)
				{
					this._chest_redpoint = (value ? new bool?(this.chest_redpoint) : null);
				}
			}
		}

		private bool ShouldSerializechest_redpoint()
		{
			return this.chest_redpointSpecified;
		}

		private void Resetchest_redpoint()
		{
			this.chest_redpointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_time
		{
			get
			{
				return this._last_update_time ?? 0U;
			}
			set
			{
				this._last_update_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_timeSpecified
		{
			get
			{
				return this._last_update_time != null;
			}
			set
			{
				bool flag = value == (this._last_update_time == null);
				if (flag)
				{
					this._last_update_time = (value ? new uint?(this.last_update_time) : null);
				}
			}
		}

		private bool ShouldSerializelast_update_time()
		{
			return this.last_update_timeSpecified;
		}

		private void Resetlast_update_time()
		{
			this.last_update_timeSpecified = false;
		}

		[ProtoMember(5, Name = "tasks", DataFormat = DataFormat.Default)]
		public List<DragonGuildRoleTaskItem> tasks
		{
			get
			{
				return this._tasks;
			}
		}

		[ProtoMember(6, Name = "achivements", DataFormat = DataFormat.Default)]
		public List<DragonGuildRoleTaskItem> achivements
		{
			get
			{
				return this._achivements;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ReceiveCount", DataFormat = DataFormat.TwosComplement)]
		public uint ReceiveCount
		{
			get
			{
				return this._ReceiveCount ?? 0U;
			}
			set
			{
				this._ReceiveCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ReceiveCountSpecified
		{
			get
			{
				return this._ReceiveCount != null;
			}
			set
			{
				bool flag = value == (this._ReceiveCount == null);
				if (flag)
				{
					this._ReceiveCount = (value ? new uint?(this.ReceiveCount) : null);
				}
			}
		}

		private bool ShouldSerializeReceiveCount()
		{
			return this.ReceiveCountSpecified;
		}

		private void ResetReceiveCount()
		{
			this.ReceiveCountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "taskRefreshTime", DataFormat = DataFormat.TwosComplement)]
		public uint taskRefreshTime
		{
			get
			{
				return this._taskRefreshTime ?? 0U;
			}
			set
			{
				this._taskRefreshTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool taskRefreshTimeSpecified
		{
			get
			{
				return this._taskRefreshTime != null;
			}
			set
			{
				bool flag = value == (this._taskRefreshTime == null);
				if (flag)
				{
					this._taskRefreshTime = (value ? new uint?(this.taskRefreshTime) : null);
				}
			}
		}

		private bool ShouldSerializetaskRefreshTime()
		{
			return this.taskRefreshTimeSpecified;
		}

		private void ResettaskRefreshTime()
		{
			this.taskRefreshTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _dragonguildid;

		private uint? _taked_chest;

		private bool? _chest_redpoint;

		private uint? _last_update_time;

		private readonly List<DragonGuildRoleTaskItem> _tasks = new List<DragonGuildRoleTaskItem>();

		private readonly List<DragonGuildRoleTaskItem> _achivements = new List<DragonGuildRoleTaskItem>();

		private uint? _ReceiveCount;

		private uint? _taskRefreshTime;

		private IExtension extensionObject;
	}
}
