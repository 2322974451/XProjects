using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipLoadTask
	{

		public EquipLoadTask(EPartType p)
		{
			this.part = p;
			this.fpi.Reset();
		}

		public bool IsSamePart(ref FashionPositionInfo newFpi)
		{
			return this.fpi.Equals(newFpi) && this.processStatus >= EProcessStatus.EPreProcess;
		}

		public bool MakePath(ref FashionPositionInfo newFpi, HashSet<string> loadedPath)
		{
			this.fpi = newFpi;
			bool flag = this.fpi.presentID > 0U;
			if (flag)
			{
				this.location = "Prefabs/" + XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(this.fpi.presentID).Prefab;
				this.processStatus = EProcessStatus.EProcessing;
			}
			else
			{
				bool flag2 = !string.IsNullOrEmpty(this.fpi.fashionName);
				if (flag2)
				{
					bool flag3 = this.fpi.fashionName.StartsWith("/");
					if (flag3)
					{
						this.location = "Equipments" + this.fpi.fashionName;
					}
					else
					{
						this.location = "Equipments/" + this.fpi.fashionName;
					}
					this.processStatus = EProcessStatus.EProcessing;
				}
			}
			bool flag4 = loadedPath != null;
			bool result;
			if (flag4)
			{
				bool flag5 = !string.IsNullOrEmpty(this.location) && !loadedPath.Contains(this.location);
				if (flag5)
				{
					loadedPath.Add(this.location);
					result = true;
				}
				else
				{
					this.processStatus = EProcessStatus.EProcessed;
					result = false;
				}
			}
			else
			{
				result = !string.IsNullOrEmpty(this.location);
			}
			return result;
		}

		public virtual void Load(XEntity e, int prefessionID, ref FashionPositionInfo newFpi, bool async, HashSet<string> loadedPath)
		{
			bool flag = loadedPath != null;
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(this.location) && !loadedPath.Contains(this.location);
				if (flag2)
				{
					loadedPath.Add(this.location);
				}
				else
				{
					this.processStatus = EProcessStatus.EProcessed;
				}
			}
		}

		public virtual void Reset(XEntity e)
		{
			this.processStatus = EProcessStatus.ENotProcess;
			this.location = "";
		}

		public EPartType part = EPartType.ENum;

		public FashionPositionInfo fpi;

		public EProcessStatus processStatus = EProcessStatus.ENotProcess;

		protected string location = "";
	}
}
