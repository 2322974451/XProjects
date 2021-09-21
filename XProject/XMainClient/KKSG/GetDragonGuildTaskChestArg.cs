using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C0 RID: 1216
	[ProtoContract(Name = "GetDragonGuildTaskChestArg")]
	[Serializable]
	public class GetDragonGuildTaskChestArg : IExtensible
	{
		// Token: 0x17001369 RID: 4969
		// (get) Token: 0x06003F58 RID: 16216 RVA: 0x00078C38 File Offset: 0x00076E38
		// (set) Token: 0x06003F59 RID: 16217 RVA: 0x00078C64 File Offset: 0x00076E64
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public DragonGuildTaskType type
		{
			get
			{
				return this._type ?? DragonGuildTaskType.TASK_NORMAL;
			}
			set
			{
				this._type = new DragonGuildTaskType?(value);
			}
		}

		// Token: 0x1700136A RID: 4970
		// (get) Token: 0x06003F5A RID: 16218 RVA: 0x00078C74 File Offset: 0x00076E74
		// (set) Token: 0x06003F5B RID: 16219 RVA: 0x00078C94 File Offset: 0x00076E94
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new DragonGuildTaskType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003F5C RID: 16220 RVA: 0x00078CD8 File Offset: 0x00076ED8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003F5D RID: 16221 RVA: 0x00078CF0 File Offset: 0x00076EF0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700136B RID: 4971
		// (get) Token: 0x06003F5E RID: 16222 RVA: 0x00078CFC File Offset: 0x00076EFC
		// (set) Token: 0x06003F5F RID: 16223 RVA: 0x00078D28 File Offset: 0x00076F28
		[ProtoMember(2, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		// Token: 0x1700136C RID: 4972
		// (get) Token: 0x06003F60 RID: 16224 RVA: 0x00078D38 File Offset: 0x00076F38
		// (set) Token: 0x06003F61 RID: 16225 RVA: 0x00078D58 File Offset: 0x00076F58
		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		// Token: 0x06003F62 RID: 16226 RVA: 0x00078D9C File Offset: 0x00076F9C
		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		// Token: 0x06003F63 RID: 16227 RVA: 0x00078DB4 File Offset: 0x00076FB4
		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		// Token: 0x06003F64 RID: 16228 RVA: 0x00078DC0 File Offset: 0x00076FC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FC4 RID: 4036
		private DragonGuildTaskType? _type;

		// Token: 0x04000FC5 RID: 4037
		private uint? _taskid;

		// Token: 0x04000FC6 RID: 4038
		private IExtension extensionObject;
	}
}
