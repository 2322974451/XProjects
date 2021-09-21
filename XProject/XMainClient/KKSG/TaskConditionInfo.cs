using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000639 RID: 1593
	[ProtoContract(Name = "TaskConditionInfo")]
	[Serializable]
	public class TaskConditionInfo : IExtensible
	{
		// Token: 0x17001EF7 RID: 7927
		// (get) Token: 0x06006251 RID: 25169 RVA: 0x000BB998 File Offset: 0x000B9B98
		// (set) Token: 0x06006252 RID: 25170 RVA: 0x000BB9C4 File Offset: 0x000B9BC4
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public TaskConnType type
		{
			get
			{
				return this._type ?? TaskConnType.TaskConn_ItemID;
			}
			set
			{
				this._type = new TaskConnType?(value);
			}
		}

		// Token: 0x17001EF8 RID: 7928
		// (get) Token: 0x06006253 RID: 25171 RVA: 0x000BB9D4 File Offset: 0x000B9BD4
		// (set) Token: 0x06006254 RID: 25172 RVA: 0x000BB9F4 File Offset: 0x000B9BF4
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
					this._type = (value ? new TaskConnType?(this.type) : null);
				}
			}
		}

		// Token: 0x06006255 RID: 25173 RVA: 0x000BBA38 File Offset: 0x000B9C38
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06006256 RID: 25174 RVA: 0x000BBA50 File Offset: 0x000B9C50
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001EF9 RID: 7929
		// (get) Token: 0x06006257 RID: 25175 RVA: 0x000BBA5C File Offset: 0x000B9C5C
		// (set) Token: 0x06006258 RID: 25176 RVA: 0x000BBA88 File Offset: 0x000B9C88
		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17001EFA RID: 7930
		// (get) Token: 0x06006259 RID: 25177 RVA: 0x000BBA98 File Offset: 0x000B9C98
		// (set) Token: 0x0600625A RID: 25178 RVA: 0x000BBAB8 File Offset: 0x000B9CB8
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x0600625B RID: 25179 RVA: 0x000BBAFC File Offset: 0x000B9CFC
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x0600625C RID: 25180 RVA: 0x000BBB14 File Offset: 0x000B9D14
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001EFB RID: 7931
		// (get) Token: 0x0600625D RID: 25181 RVA: 0x000BBB20 File Offset: 0x000B9D20
		// (set) Token: 0x0600625E RID: 25182 RVA: 0x000BBB4C File Offset: 0x000B9D4C
		[ProtoMember(3, IsRequired = false, Name = "step", DataFormat = DataFormat.TwosComplement)]
		public uint step
		{
			get
			{
				return this._step ?? 0U;
			}
			set
			{
				this._step = new uint?(value);
			}
		}

		// Token: 0x17001EFC RID: 7932
		// (get) Token: 0x0600625F RID: 25183 RVA: 0x000BBB5C File Offset: 0x000B9D5C
		// (set) Token: 0x06006260 RID: 25184 RVA: 0x000BBB7C File Offset: 0x000B9D7C
		[XmlIgnore]
		[Browsable(false)]
		public bool stepSpecified
		{
			get
			{
				return this._step != null;
			}
			set
			{
				bool flag = value == (this._step == null);
				if (flag)
				{
					this._step = (value ? new uint?(this.step) : null);
				}
			}
		}

		// Token: 0x06006261 RID: 25185 RVA: 0x000BBBC0 File Offset: 0x000B9DC0
		private bool ShouldSerializestep()
		{
			return this.stepSpecified;
		}

		// Token: 0x06006262 RID: 25186 RVA: 0x000BBBD8 File Offset: 0x000B9DD8
		private void Resetstep()
		{
			this.stepSpecified = false;
		}

		// Token: 0x17001EFD RID: 7933
		// (get) Token: 0x06006263 RID: 25187 RVA: 0x000BBBE4 File Offset: 0x000B9DE4
		// (set) Token: 0x06006264 RID: 25188 RVA: 0x000BBC10 File Offset: 0x000B9E10
		[ProtoMember(4, IsRequired = false, Name = "max_step", DataFormat = DataFormat.TwosComplement)]
		public uint max_step
		{
			get
			{
				return this._max_step ?? 0U;
			}
			set
			{
				this._max_step = new uint?(value);
			}
		}

		// Token: 0x17001EFE RID: 7934
		// (get) Token: 0x06006265 RID: 25189 RVA: 0x000BBC20 File Offset: 0x000B9E20
		// (set) Token: 0x06006266 RID: 25190 RVA: 0x000BBC40 File Offset: 0x000B9E40
		[XmlIgnore]
		[Browsable(false)]
		public bool max_stepSpecified
		{
			get
			{
				return this._max_step != null;
			}
			set
			{
				bool flag = value == (this._max_step == null);
				if (flag)
				{
					this._max_step = (value ? new uint?(this.max_step) : null);
				}
			}
		}

		// Token: 0x06006267 RID: 25191 RVA: 0x000BBC84 File Offset: 0x000B9E84
		private bool ShouldSerializemax_step()
		{
			return this.max_stepSpecified;
		}

		// Token: 0x06006268 RID: 25192 RVA: 0x000BBC9C File Offset: 0x000B9E9C
		private void Resetmax_step()
		{
			this.max_stepSpecified = false;
		}

		// Token: 0x06006269 RID: 25193 RVA: 0x000BBCA8 File Offset: 0x000B9EA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017D9 RID: 6105
		private TaskConnType? _type;

		// Token: 0x040017DA RID: 6106
		private uint? _id;

		// Token: 0x040017DB RID: 6107
		private uint? _step;

		// Token: 0x040017DC RID: 6108
		private uint? _max_step;

		// Token: 0x040017DD RID: 6109
		private IExtension extensionObject;
	}
}
