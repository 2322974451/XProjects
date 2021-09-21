using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001E0 RID: 480
	public class XEngineCommandMgr : XSingleton<XEngineCommandMgr>
	{
		// Token: 0x06000AE7 RID: 2791 RVA: 0x0003A314 File Offset: 0x00038514
		private SimpleQueue GetCurrentQueue()
		{
			bool flag = this.m_currentQueue == null;
			if (flag)
			{
				this.m_currentQueue = this.m_commandQueue0;
			}
			return this.m_currentQueue;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0003A348 File Offset: 0x00038548
		private SimpleQueue GeBackQueue(SimpleQueue queue)
		{
			bool flag = queue == this.m_commandQueue0;
			SimpleQueue result;
			if (flag)
			{
				result = this.m_commandQueue1;
			}
			else
			{
				result = this.m_commandQueue0;
			}
			return result;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0003A378 File Offset: 0x00038578
		private void SwapQueue()
		{
			bool flag = this.m_currentQueue != null;
			if (flag)
			{
				bool flag2 = this.m_currentQueue == this.m_commandQueue0;
				if (flag2)
				{
					this.m_currentQueue = this.m_commandQueue1;
				}
				else
				{
					this.m_currentQueue = this.m_commandQueue0;
				}
			}
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0003A3C8 File Offset: 0x000385C8
		public XEngineCommand CreateCommand(ExecuteCommandHandler handler, XGameObject gameObject, int commandID = -1)
		{
			bool hasData = this.m_commandQueue.HasData;
			XEngineCommand xengineCommand;
			if (hasData)
			{
				xengineCommand = this.m_commandQueue.Dequeue<XEngineCommand>();
			}
			else
			{
				xengineCommand = new XEngineCommand();
			}
			xengineCommand.gameObject = gameObject;
			xengineCommand.handler = handler;
			xengineCommand.objID = gameObject.objID;
			xengineCommand.commandID = commandID;
			xengineCommand.id = XEngineCommand.debugid++;
			return xengineCommand;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0003A434 File Offset: 0x00038634
		public void AppendCommand(XEngineCommand command)
		{
			bool flag = command.CanExecute();
			if (flag)
			{
				command.Execute();
				this.ReturnCommand(command);
			}
			else
			{
				bool flag2 = XEngineCommand.debug && command.debugHandler != null;
				if (flag2)
				{
					command.debugHandler(command.gameObject, command, "append", command.id);
				}
				SimpleQueue currentQueue = this.GetCurrentQueue();
				currentQueue.Enqueue(command);
			}
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0003A4A8 File Offset: 0x000386A8
		public XObjAsyncData GetObjAsyncData()
		{
			bool hasData = this.m_objAsyncDataQueue.HasData;
			XObjAsyncData result;
			if (hasData)
			{
				result = this.m_objAsyncDataQueue.Dequeue<XObjAsyncData>();
			}
			else
			{
				result = new XObjAsyncData();
			}
			return result;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0003A4DC File Offset: 0x000386DC
		public void ReturnCommand(XEngineCommand command)
		{
			bool flag = command.data != null;
			if (flag)
			{
				command.data.Reset();
				this.m_objAsyncDataQueue.Enqueue(command.data);
			}
			command.Reset();
			this.m_commandQueue.Enqueue(command);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0003A52C File Offset: 0x0003872C
		public GameObject GetGameObject()
		{
			bool flag = this.m_gameObjectQueue.Count > 0;
			GameObject result;
			if (flag)
			{
				result = this.m_gameObjectQueue.Dequeue();
			}
			else
			{
				result = new GameObject("EmptyObject");
			}
			return result;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0003A568 File Offset: 0x00038768
		public void ReturnGameObject(GameObject go)
		{
			bool flag = go != null;
			if (flag)
			{
				Transform transform = go.transform;
				transform.parent = null;
				transform.position = XResourceLoaderMgr.Far_Far_Away;
				transform.rotation = Quaternion.identity;
				transform.localScale = Vector3.one;
				go.name = "EmptyObject";
				this.m_gameObjectQueue.Enqueue(go);
			}
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0003A5D0 File Offset: 0x000387D0
		public void Update()
		{
			SimpleQueue currentQueue = this.GetCurrentQueue();
			bool flag = currentQueue != null && currentQueue.HasData;
			if (flag)
			{
				SimpleQueue simpleQueue = this.GeBackQueue(currentQueue);
				while (currentQueue.HasData)
				{
					XEngineCommand xengineCommand = currentQueue.Dequeue<XEngineCommand>();
					bool flag2 = xengineCommand.IsValid();
					if (flag2)
					{
						bool flag3 = xengineCommand.CanExecute();
						if (flag3)
						{
							bool flag4 = XEngineCommand.debug && xengineCommand.debugHandler != null;
							if (flag4)
							{
								xengineCommand.debugHandler(xengineCommand.gameObject, xengineCommand, "execute", xengineCommand.id);
							}
							xengineCommand.Execute();
							this.ReturnCommand(xengineCommand);
						}
						else
						{
							simpleQueue.Enqueue(xengineCommand);
						}
					}
					else
					{
						bool flag5 = XEngineCommand.debug && xengineCommand.debugHandler != null;
						if (flag5)
						{
							xengineCommand.debugHandler(xengineCommand.gameObject, xengineCommand, "invalid", xengineCommand.id);
						}
						this.ReturnCommand(xengineCommand);
					}
				}
				this.SwapQueue();
			}
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0003A6DC File Offset: 0x000388DC
		public void Clear()
		{
			while (this.m_commandQueue0.HasData)
			{
				XEngineCommand command = this.m_commandQueue0.Dequeue<XEngineCommand>();
				this.ReturnCommand(command);
			}
			while (this.m_commandQueue1.HasData)
			{
				XEngineCommand command2 = this.m_commandQueue1.Dequeue<XEngineCommand>();
				this.ReturnCommand(command2);
			}
			this.m_currentQueue = this.m_commandQueue0;
			this.m_gameObjectQueue.Clear();
			XEngineCommand.debugid = 0;
			bool debug = XEngineCommand.debug;
			if (debug)
			{
				XSingleton<XDebug>.singleton.AddWarningLog("[EngineCommand] Clear", null, null, null, null, null);
			}
		}

		// Token: 0x0400056E RID: 1390
		private SimpleQueue m_currentQueue = null;

		// Token: 0x0400056F RID: 1391
		private SimpleQueue m_commandQueue0 = new SimpleQueue();

		// Token: 0x04000570 RID: 1392
		private SimpleQueue m_commandQueue1 = new SimpleQueue();

		// Token: 0x04000571 RID: 1393
		private SimpleQueue m_commandQueue = new SimpleQueue();

		// Token: 0x04000572 RID: 1394
		private SimpleQueue m_objAsyncDataQueue = new SimpleQueue();

		// Token: 0x04000573 RID: 1395
		private Queue<GameObject> m_gameObjectQueue = new Queue<GameObject>();
	}
}
