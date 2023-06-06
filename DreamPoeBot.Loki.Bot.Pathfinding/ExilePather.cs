using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using log4net;

namespace DreamPoeBot.Loki.Bot.Pathfinding;

public static class ExilePather
{
	public delegate void ObstacleUpdateEvent();

	public delegate void ExilePatherReloadEvent();

	public delegate bool PlotFunction(int x, int y);

	private sealed class Class480
	{
		public Vector2i vector2i_0;

		public Vector2i vector2i_1;

		internal List<Vector2i> method_0()
		{
			Class481 @class = new Class481();
			@class.list_0 = new List<Vector2i>();
			PlotFunction plotFunction = @class.method_0;
			int gparam_ = vector2i_0.X;
			int gparam_2 = vector2i_0.Y;
			int gparam_3 = vector2i_1.X;
			int gparam_4 = vector2i_1.Y;
			bool flag;
			if (flag = Math.Abs(gparam_4 - gparam_2) > Math.Abs(gparam_3 - gparam_))
			{
				smethod_0(ref gparam_, ref gparam_2);
				smethod_0(ref gparam_3, ref gparam_4);
			}
			if (gparam_ > gparam_3)
			{
				smethod_0(ref gparam_, ref gparam_3);
				smethod_0(ref gparam_2, ref gparam_4);
			}
			int num = gparam_3 - gparam_;
			int num2 = Math.Abs(gparam_4 - gparam_2);
			int num3 = num / 2;
			int num4 = ((gparam_2 < gparam_4) ? 1 : (-1));
			int num5 = gparam_2;
			int num6 = gparam_;
			while (true)
			{
				if (num6 <= gparam_3)
				{
					if (!(flag ? plotFunction(num5, num6) : plotFunction(num6, num5)))
					{
						break;
					}
					num3 -= num2;
					if (num3 < 0)
					{
						num5 += num4;
						num3 += num;
					}
					num6++;
					continue;
				}
				if (@class.list_0[0] == vector2i_1)
				{
					@class.list_0.Reverse();
				}
				return @class.list_0;
			}
			return @class.list_0;
		}
	}

	private sealed class Class481
	{
		public List<Vector2i> list_0;

		internal bool method_0(int int_0, int int_1)
		{
			list_0.Add(new Vector2i(int_0, int_1));
			return true;
		}
	}

	private sealed class Class483
	{
		public Vector2i startPoint;

		public Vector2i endpoint;

		public CachedTerrainData cachedTerrainData_0;

		internal Tuple<bool, Vector2i> method_0(bool shouldUseFlyMap = false)
		{
			Class484 @class = new Class484();
			@class.class483_0 = this;
			@class.hitpoint = Vector2i.Zero;
			if (!(startPoint == endpoint))
			{
				PlotFunction plotFunction = null;
				plotFunction = ((!shouldUseFlyMap) ? new PlotFunction(@class.CheckWalkability) : new PlotFunction(@class.CheckWalkability_Fly));
				int gparam_ = startPoint.X;
				int gparam_2 = startPoint.Y;
				int gparam_3 = endpoint.X;
				int gparam_4 = endpoint.Y;
				bool flag;
				if (flag = Math.Abs(gparam_4 - gparam_2) > Math.Abs(gparam_3 - gparam_))
				{
					smethod_0(ref gparam_, ref gparam_2);
					smethod_0(ref gparam_3, ref gparam_4);
				}
				if (gparam_ > gparam_3)
				{
					smethod_0(ref gparam_, ref gparam_3);
					smethod_0(ref gparam_2, ref gparam_4);
				}
				int num = gparam_3 - gparam_;
				int num2 = Math.Abs(gparam_4 - gparam_2);
				int num3 = num / 2;
				int num4 = ((gparam_2 < gparam_4) ? 1 : (-1));
				int num5 = gparam_2;
				bool item = true;
				for (int i = gparam_; i <= gparam_3; i++)
				{
					if (!(flag ? plotFunction(num5, i) : plotFunction(i, num5)))
					{
						item = false;
					}
					num3 -= num2;
					if (num3 < 0)
					{
						num5 += num4;
						num3 += num;
					}
				}
				return new Tuple<bool, Vector2i>(item, @class.hitpoint);
			}
			return new Tuple<bool, Vector2i>(item1: true, @class.hitpoint);
		}
	}

	private sealed class Class484
	{
		public Vector2i hitpoint;

		public Class483 class483_0;

		internal bool CheckWalkability(int int_0, int int_1)
		{
			if (WalkabilityGrid.IsWalkable(class483_0.cachedTerrainData_0.Data, class483_0.cachedTerrainData_0.BPR, int_0, int_1, 2))
			{
				return true;
			}
			hitpoint = new Vector2i(int_0, int_1);
			return false;
		}

		internal bool CheckWalkability_Fly(int int_0, int int_1)
		{
			if (WalkabilityGrid.IsWalkable(class483_0.cachedTerrainData_0.FlyData, class483_0.cachedTerrainData_0.BPR, int_0, int_1, 2))
			{
				return true;
			}
			hitpoint = new Vector2i(int_0, int_1);
			return false;
		}
	}

	private sealed class Class486
	{
		public Vector2i pos;

		public CachedTerrainData cachedTerrainData_0;

		public int range;

		public int int_1;

		public Vector2i vector2i_1;

		internal void method_CheckPosX()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.X++;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}

		internal void method_CheckNegX()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.X--;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}

		internal void method_CheckNegY()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.Y--;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}

		internal void method_CheckPosY()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.Y++;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static readonly List<int> blockedObjectList = new List<int>();

	private static readonly List<int> blockedTriggerableBlockages = new List<int>();

	private static uint _areaHash;

	private static FeatureEnum blockTrialOfAscendancy = FeatureEnum.Unset;

	private static FeatureEnum blockLockedDoors = FeatureEnum.Unset;

	private static FeatureEnum blockLockedTempleDoors = FeatureEnum.Unset;

	private static bool CheckForTempleDoors;

	private static bool CheckForAscendancyDoor;

	private static bool BlockUndyingBlockage;

	private static bool BlockOssuary_HiddenDoor;

	private static readonly Dictionary<Vector2i, Vector2i> walkablePositionDictionary = new Dictionary<Vector2i, Vector2i>();

	public static List<string> JumpableTgt = new List<string>();

	public static bool IsReady = false;

	public static RDPathfinder PolyPathfinder { get; private set; }

	public static bool ShouldBlockNPC { get; set; } = true;


	public static bool ShouldBlockChest { get; set; } = false;


	public static uint AreaHash => _areaHash;

	public static int AscendancyDoorRadiusOverride { get; set; } = 0;


	public static int LabyrinthLockedDoorRadiusOverride { get; set; } = 0;


	public static int TempleLockedDoorRadiusOverride { get; set; } = 0;


	public static bool AutoSavePathfindingData { get; set; } = false;


	public static FeatureEnum BlockTrialOfAscendancy
	{
		get
		{
			return blockTrialOfAscendancy;
		}
		set
		{
			if (blockTrialOfAscendancy != value)
			{
				blockTrialOfAscendancy = value;
				ilog_0.InfoFormat($"[ExilePather] BlockTrialOfAscendancy = {value}.", Array.Empty<object>());
			}
		}
	}

	public static FeatureEnum BlockLockedDoors
	{
		get
		{
			return blockLockedDoors;
		}
		set
		{
			if (blockLockedDoors != value)
			{
				blockLockedDoors = value;
				ilog_0.InfoFormat($"[ExilePather] BlockLockedDoors = {value}.", Array.Empty<object>());
			}
		}
	}

	public static FeatureEnum BlockLockedTempleDoors
	{
		get
		{
			return blockLockedTempleDoors;
		}
		set
		{
			if (blockLockedTempleDoors != value)
			{
				blockLockedTempleDoors = value;
				ilog_0.InfoFormat($"[ExilePather] BlockLockedTempleDoors = {value}.", Array.Empty<object>());
			}
		}
	}

	public static bool UseWalkableCheck { get; set; } = true;


	public static event ObstacleUpdateEvent OnObstacleUpdate;

	public static event ExilePatherReloadEvent OnExilePatherReload;

	public static List<Vector2i> GetPointsOnSegment(Vector2i start, Vector2i end, bool dontLeaveFrame)
	{
		Class480 @class = new Class480();
		@class.vector2i_0 = start;
		@class.vector2i_1 = end;
		return @class.method_0();
	}

	public static bool CanObjectSee(Vector2i start, Vector2i end, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Vector2i hitPoint;
		return Raycast(start, end, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, NetworkObject other, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Vector2i hitPoint;
		return Raycast(obj.Position, other.Position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, NetworkObject other, out Vector2i hitPoint, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		return Raycast(obj.Position, other.Position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, Vector2i position, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Vector2i hitPoint;
		return Raycast(obj.Position, position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, Vector2i position, out Vector2i hitPoint, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		return Raycast(obj.Position, position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	private static void smethod_0<T>(ref T gparam_0, ref T gparam_1)
	{
		T val = gparam_0;
		gparam_0 = gparam_1;
		gparam_1 = val;
	}

	public static bool Raycast(Vector2i start, Vector2i end, out Vector2i hitPoint, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Class483 @class = new Class483();
		@class.startPoint = start;
		@class.endpoint = end;
		@class.cachedTerrainData_0 = LokiPoe.TerrainData.Cache;
		Tuple<bool, Vector2i> tuple = @class.method_0(shouldUseRangedMap);
		hitPoint = tuple.Item2;
		Utility.BroadcastMessage(null, "Raycast_Result", start, end, tuple.Item1, tuple.Item2);
		return tuple.Item1;
	}

	private static bool ShouldBlock(NetworkObject triggerableBlockage_0)
	{
		return true;
	}

	private static void CheckForUpdates()
	{
		bool flag = false;
		List<NetworkObject> list = new List<NetworkObject>();
		if ((BlockLockedTempleDoors == FeatureEnum.Enabled && CheckForTempleDoors) || BlockLockedDoors == FeatureEnum.Enabled || (BlockTrialOfAscendancy == FeatureEnum.Enabled && CheckForAscendancyDoor) || BlockUndyingBlockage || (ShouldBlockNPC && LokiPoe.CurrentWorldArea.IsTown) || ShouldBlockChest || LokiPoe.LocalData.WorldArea.Id.StartsWith("Expedition") || BlockOssuary_HiddenDoor)
		{
			list = LokiPoe.ObjectManager.Objects;
		}
		if (LokiPoe.LocalData.WorldArea.Id.StartsWith("Expedition"))
		{
			byte[] data = LokiPoe.TerrainData.Cache.Data;
			BlockTriggerableBlockages(ref data, LokiPoe.TerrainData.Cache.BPR, ShouldBlock, list);
			LokiPoe.TerrainData.Cache.Data = data;
			flag = true;
		}
		if (BlockLockedTempleDoors == FeatureEnum.Enabled && CheckForTempleDoors)
		{
			IEnumerable<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> enumerable = from x in list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>()
				where x.Name == "Place Explosives"
				select x;
			foreach (DreamPoeBot.Loki.Game.Objects.TriggerableBlockage item in enumerable)
			{
				if (!blockedObjectList.Contains(item.Id))
				{
					if (!item.IsOpened)
					{
						int num = 8;
						if (TempleLockedDoorRadiusOverride != 0)
						{
							num = TempleLockedDoorRadiusOverride;
						}
						PolyPathfinder.AddObstacle(item.Position, num);
						blockedObjectList.Add(item.Id);
						flag = true;
						ilog_0.InfoFormat($"[CheckForUpdates] Now adding obstacle [{item.Id}] {item.Name} at position {item.Position.X},{item.Position.Y} with radius {num}.", Array.Empty<object>());
					}
				}
				else if (item.IsOpened)
				{
					PolyPathfinder.RemoveObstacle(item.Position);
					blockedObjectList.Remove(item.Id);
					flag = true;
					ilog_0.InfoFormat($"[CheckForUpdates] Now removing the obstacle [{item.Id}] {item.Name} at position {item.Position.X},{item.Position.Y}.", Array.Empty<object>());
				}
			}
		}
		if (BlockLockedDoors == FeatureEnum.Enabled)
		{
			IEnumerable<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> enumerable2 = from x in list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>()
				where x.IsLockedDoor || x.IsGoldenDoor || x.IsSilverDoor
				select x;
			foreach (DreamPoeBot.Loki.Game.Objects.TriggerableBlockage item2 in enumerable2)
			{
				if (!blockedObjectList.Contains(item2.Id))
				{
					if (item2.IsOpened)
					{
						continue;
					}
					if (!item2.IsGoldenDoor)
					{
						if (item2.IsSilverDoor && LokiPoe.InstanceInfo.GetPlayerInventoryItemsBySlot(InventorySlot.Main).FirstOrDefault((Item x) => x.FullName == "Silver Key") != null)
						{
							continue;
						}
					}
					else if (LokiPoe.InstanceInfo.GetPlayerInventoryItemsBySlot(InventorySlot.Main).FirstOrDefault((Item x) => x.FullName == "Golden Key") != null)
					{
						continue;
					}
					int num2 = 8;
					if (LabyrinthLockedDoorRadiusOverride != 0)
					{
						num2 = LabyrinthLockedDoorRadiusOverride;
					}
					PolyPathfinder.AddObstacle(item2.Position, num2);
					blockedObjectList.Add(item2.Id);
					flag = true;
					ilog_0.InfoFormat($"[CheckForUpdates] Now adding obstacle [{item2.Id}] {item2.Name} at position {item2.Position.X},{item2.Position.Y} with radius {num2}.", Array.Empty<object>());
				}
				else if (item2.IsOpened)
				{
					PolyPathfinder.RemoveObstacle(item2.Position);
					blockedObjectList.Remove(item2.Id);
					flag = true;
					ilog_0.InfoFormat($"[CheckForUpdates] Now removing the obstacle [{item2.Id}] {item2.Name} at position {item2.Position.X},{item2.Position.Y}.", Array.Empty<object>());
				}
			}
		}
		if (BlockTrialOfAscendancy == FeatureEnum.Enabled && CheckForAscendancyDoor)
		{
			List<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> source = list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>().ToList();
			if (source.Any())
			{
				DreamPoeBot.Loki.Game.Objects.TriggerableBlockage triggerableBlockage = source.FirstOrDefault((DreamPoeBot.Loki.Game.Objects.TriggerableBlockage x) => x.Metadata == "Metadata/Terrain/Labyrinth/Objects/LabyrinthIntroDoor");
				if (triggerableBlockage != null && !blockedObjectList.Contains(triggerableBlockage.Id) && !triggerableBlockage.IsOpened)
				{
					int num3 = 8;
					if (AscendancyDoorRadiusOverride != 0)
					{
						num3 = AscendancyDoorRadiusOverride;
					}
					PolyPathfinder.AddObstacle(triggerableBlockage.Position, num3);
					blockedObjectList.Add(triggerableBlockage.Id);
					flag = true;
					ilog_0.InfoFormat($"[CheckForUpdates] Now adding obstacle {triggerableBlockage.Name} at position {triggerableBlockage.Position.X},{triggerableBlockage.Position.Y} with radius {num3}.", Array.Empty<object>());
					CheckForAscendancyDoor = false;
				}
			}
		}
		if (BlockUndyingBlockage)
		{
			NetworkObject undyingBlockage = LokiPoe.ObjectManager.UndyingBlockage;
			if (undyingBlockage != null && !blockedObjectList.Contains(undyingBlockage.Id) && undyingBlockage.IsTargetable)
			{
				PolyPathfinder.AddObstacle(undyingBlockage.Position, 12f);
				blockedObjectList.Add(undyingBlockage.Id);
				flag = true;
				ilog_0.InfoFormat($"[CheckForUpdates] Now adding obstacle {undyingBlockage.Name} at position {undyingBlockage.Position.X},{undyingBlockage.Position.Y} with radius {12}.", Array.Empty<object>());
				BlockUndyingBlockage = false;
			}
		}
		if (BlockOssuary_HiddenDoor)
		{
			List<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> source2 = list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>().ToList();
			if (source2.Any())
			{
				DreamPoeBot.Loki.Game.Objects.TriggerableBlockage triggerableBlockage2 = source2.FirstOrDefault((DreamPoeBot.Loki.Game.Objects.TriggerableBlockage x) => x.Metadata == "Metadata/Terrain/Act5/Area6/Objects/Ossuary_HiddenDoor");
				if (triggerableBlockage2 != null && !triggerableBlockage2.IsOpened && !blockedObjectList.Contains(triggerableBlockage2.Id))
				{
					Vector2i triggerableBlockagePosition = new Vector2i(triggerableBlockage2.Position.X, triggerableBlockage2.BoundsMin.Y);
					Vector2i triggerableBlockagePosition2 = new Vector2i(triggerableBlockage2.Position.X, triggerableBlockage2.BoundsMax.Y);
					PolyPathfinder.AddObstacle(triggerableBlockagePosition, 10f);
					PolyPathfinder.AddObstacle(triggerableBlockagePosition2, 10f);
					blockedObjectList.Add(triggerableBlockage2.Id);
					flag = true;
					ilog_0.InfoFormat($"[CheckForUpdates] Now adding obstacle {triggerableBlockage2.Name} at position {triggerableBlockagePosition.X},{triggerableBlockagePosition.Y} with radius {10}.", Array.Empty<object>());
					ilog_0.InfoFormat($"[CheckForUpdates] Now adding obstacle {triggerableBlockage2.Name} at position {triggerableBlockagePosition2.X},{triggerableBlockagePosition2.Y} with radius {10}.", Array.Empty<object>());
					BlockOssuary_HiddenDoor = false;
				}
			}
		}
		if (ShouldBlockNPC && LokiPoe.CurrentWorldArea.IsTown)
		{
			List<Npc> list2 = list.OfType<Npc>().ToList();
			if (list2.Any())
			{
				foreach (Npc item3 in list2)
				{
					if (!object.Equals(item3, null))
					{
						int id = item3.Id;
						Vector2i position = item3.Position;
						if (!blockedObjectList.Contains(id))
						{
							PolyPathfinder.AddObstacle(position, 6f);
							blockedObjectList.Add(id);
							flag = true;
						}
					}
				}
			}
		}
		if (ShouldBlockChest)
		{
			List<DreamPoeBot.Loki.Game.Objects.Chest> list3 = list.OfType<DreamPoeBot.Loki.Game.Objects.Chest>().ToList();
			if (list3.Any())
			{
				foreach (DreamPoeBot.Loki.Game.Objects.Chest item4 in list3)
				{
					if (object.Equals(item4, null))
					{
						continue;
					}
					int id2 = item4.Id;
					Vector2i position2 = item4.Position;
					if (!item4.IsOpened)
					{
						if (!blockedObjectList.Contains(id2))
						{
							PolyPathfinder.AddObstacle(position2, 3f);
							blockedObjectList.Add(id2);
							flag = true;
						}
					}
					else if (blockedObjectList.Contains(id2))
					{
						PolyPathfinder.RemoveObstacle(position2);
						blockedObjectList.Remove(id2);
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			PolyPathfinder.UpdateObstacles();
		}
	}

	public static void BlockTriggerableBlockages(ref byte[] data, int bytesPerRow, Func<NetworkObject, bool> shouldBlock, List<NetworkObject> obj)
	{
		if (!LokiPoe.CurrentWorldArea.Id.StartsWith("Expedition"))
		{
			return;
		}
		Thread.Sleep(5);
		List<NetworkObject> list = obj.Where((NetworkObject x) => x.Components.TriggerableBlockageComponent != null).ToList();
		foreach (NetworkObject item in list)
		{
			DreamPoeBot.Loki.Components.TriggerableBlockage triggerableBlockageComponent = item.Components.TriggerableBlockageComponent;
			StateMachine stateMachineComponent = item.Components.StateMachineComponent;
			if (stateMachineComponent == null)
			{
				continue;
			}
			StateMachine.StageState stageState = stateMachineComponent.StageStates.FirstOrDefault((StateMachine.StageState x) => x.Name == "expedition_detonated");
			if (stageState == null)
			{
				continue;
			}
			if (!stageState.IsActive)
			{
				if (blockedTriggerableBlockages.Contains(item.Id))
				{
					continue;
				}
				ilog_0.WarnFormat($"[BlockTriggerableBlockages] Blocking {item.Name}, IsDetonated: {stageState.IsActive} ", Array.Empty<object>());
				byte[] navData = triggerableBlockageComponent.NavData;
				int x2 = triggerableBlockageComponent.BoundsMin.X;
				int num = triggerableBlockageComponent.BoundsMax.X;
				if ((num - x2) % 2 == 1)
				{
					num++;
				}
				int num2 = (triggerableBlockageComponent.BoundsMax.X + 1) / 2 - triggerableBlockageComponent.BoundsMin.X / 2;
				for (int i = triggerableBlockageComponent.BoundsMin.Y; i < triggerableBlockageComponent.BoundsMax.Y; i++)
				{
					for (int j = x2; j < num; j++)
					{
						int num3 = (i - triggerableBlockageComponent.BoundsMin.Y) * num2 + (j - x2) / 2;
						int num4 = i * bytesPerRow + j / 2;
						if ((j & 1) == 0)
						{
							byte b = (byte)(navData[num3] & 0xFu);
							if (b > 5)
							{
								b = 5;
							}
							data[num4] = b;
						}
						else
						{
							byte b2 = (byte)(navData[num3] >> 4);
							if (b2 > 5)
							{
								b2 = 5;
							}
							data[num4] = b2;
						}
					}
				}
				blockedTriggerableBlockages.Add(item.Id);
			}
			else
			{
				if (!blockedTriggerableBlockages.Contains(item.Id))
				{
					continue;
				}
				ilog_0.WarnFormat($"[BlockTriggerableBlockages] Unblocking {item.Name}, IsOpen: {stageState.IsActive} ", Array.Empty<object>());
				byte[] navData2 = triggerableBlockageComponent.NavData;
				int x3 = triggerableBlockageComponent.BoundsMin.X;
				int num5 = triggerableBlockageComponent.BoundsMax.X;
				if ((num5 - x3) % 2 == 1)
				{
					num5++;
				}
				int num6 = (triggerableBlockageComponent.BoundsMax.X + 1) / 2 - triggerableBlockageComponent.BoundsMin.X / 2;
				for (int k = triggerableBlockageComponent.BoundsMin.Y; k < triggerableBlockageComponent.BoundsMax.Y; k++)
				{
					for (int l = x3; l < num5; l++)
					{
						int num7 = (k - triggerableBlockageComponent.BoundsMin.Y) * num6 + (l - x3) / 2;
						int num8 = k * bytesPerRow + l / 2;
						if (((uint)l & (true ? 1u : 0u)) != 0)
						{
							int num9 = (byte)(navData2[num7] >> 4);
							byte b3 = (byte)(data[num8] & 0xFu);
							byte b4 = (byte)(data[num8] >> 4);
							int num10 = num9 + b4;
							if (num10 > 5)
							{
								num10 = 5;
							}
							data[num8] = (byte)(b3 | (num10 << 4));
						}
						else
						{
							byte b5 = (byte)(navData2[num7] & 0xFu);
							byte b6 = (byte)(data[num8] & 0xFu);
							byte b7 = (byte)(data[num8] >> 4);
							int num11 = b5 + b6;
							if (num11 > 5)
							{
								num11 = 5;
							}
							data[num8] = (byte)(num11 | (b7 << 4));
						}
					}
				}
				blockedTriggerableBlockages.Remove(item.Id);
			}
		}
	}

	public static void Save(string filePath)
	{
	}

	public static void Load(string filePath)
	{
	}

	public static void Reload(bool force = false)
	{
		IsReady = false;
		try
		{
			if (GameStateController.IsInGameState)
			{
				uint num2 = default(uint);
				TimeSpan elapsed = default(TimeSpan);
				while (true)
				{
					Thread.Sleep(10);
					while (true)
					{
						IL_05e4:
						if (GameController.Instance.Game.IngameState.CurrentAreaMap.GrountMapStart != 0L)
						{
							while (true)
							{
								IL_05dc:
								uint areaHash = LokiPoe.LocalData.AreaHash;
								while (true)
								{
									IL_05d2:
									if (_areaHash == areaHash)
									{
										goto IL_05bb;
									}
									goto IL_05c1;
									IL_05c1:
									while (true)
									{
										IL_05c1_2:
										ClearWalkablePositionCache();
										blockedObjectList.Clear();
										while (true)
										{
											IL_05af:
											blockedTriggerableBlockages.Clear();
											while (true)
											{
												IL_05aa:
												if (force)
												{
													goto IL_0594;
												}
												goto IL_05a2;
												IL_05a2:
												CachedTerrainData cachedTerrainData = LokiPoe.TerrainData.Cache;
												goto IL_059a;
												IL_059a:
												while (true)
												{
													IL_059a_2:
													RDPathfinder polyPathfinder = PolyPathfinder;
													while (true)
													{
														IL_058f:
														if (polyPathfinder == null)
														{
															goto IL_0573;
														}
														goto IL_0587;
														IL_0587:
														polyPathfinder.Destroy();
														goto IL_0573;
														IL_0573:
														while (true)
														{
															IL_0573_2:
															Thread thread = new Thread(LokiPoe.ClientFunctions.GenerateHeightCache);
															while (true)
															{
																IL_0541:
																thread.Start();
																PolyPathfinder = new RDPathfinder();
																ilog_0.InfoFormat("[ExilePather] Now creating the navmesh.", Array.Empty<object>());
																PolyPathfinder.ProcessEntireZone(cachedTerrainData, multiThreadProcessing: true);
																while (true)
																{
																	IL_0539:
																	Thread.Sleep(1);
																	while (true)
																	{
																		IL_0523:
																		ilog_0.InfoFormat("[ExilePather] The navmesh has been created. Now waiting to be in game.", Array.Empty<object>());
																		while (true)
																		{
																			IL_051a:
																			Stopwatch stopwatch = Stopwatch.StartNew();
																			while (true)
																			{
																				IL_0512:
																				_areaHash = areaHash;
																				while (true)
																				{
																					IL_0504:
																					BlockUndyingBlockage = false;
																					BlockOssuary_HiddenDoor = false;
																					while (true)
																					{
																						IL_04f8:
																						if (LokiPoe.IsInGame)
																						{
																							while (true)
																							{
																								IL_04e6:
																								DatWorldAreaWrapper currentWorldArea = LokiPoe.CurrentWorldArea;
																								string name = currentWorldArea.Name;
																								while (true)
																								{
																									IL_04d2:
																									string id = currentWorldArea.Id;
																									bool isTempleOfAtzoatl = currentWorldArea.IsTempleOfAtzoatl;
																									while (true)
																									{
																										IL_0494:
																										ilog_0.InfoFormat("[ExilePather] We are in game now, waiting area generation to complete for: " + name + " (" + id + ").", Array.Empty<object>());
																										while (true)
																										{
																											IL_0487:
																											if (!thread.IsAlive)
																											{
																												while (true)
																												{
																													IL_0479:
																													if (PolyPathfinder.AreaGenerated)
																													{
																														while (true)
																														{
																															IL_0405:
																															if (id.Equals("1_3_10_1"))
																															{
																																goto IL_009f;
																															}
																															goto IL_03a8;
																															IL_009f:
																															if (LokiPoe.InstanceInfo.GetPlayerInventoryItemsBySlot(InventorySlot.Main).FirstOrDefault((Item x) => x.FullName == "Infernal Talc") == null)
																															{
																																goto IL_037b;
																															}
																															goto IL_03e1;
																															IL_037b:
																															BlockUndyingBlockage = true;
																															ilog_0.InfoFormat($"[ExilePather] _checkForUndyingBlockage = {BlockUndyingBlockage} [{id}].", Array.Empty<object>());
																															goto IL_03e1;
																															IL_03bc:
																															ilog_0.InfoFormat($"[ExilePather] _checkForHiddenDoor = {BlockOssuary_HiddenDoor} [{id}].", Array.Empty<object>());
																															goto IL_03e1;
																															IL_03e1:
																															while (true)
																															{
																																IL_03e1_2:
																																CheckForAscendancyDoor = false;
																																while (true)
																																{
																																	IL_036f:
																																	string[] labyrinthTrialAreaIds = LokiPoe.LabyrinthTrialAreaIds;
																																	int num = 0;
																																	while (true)
																																	{
																																		IL_0365:
																																		if (num >= labyrinthTrialAreaIds.Length)
																																		{
																																			while (true)
																																			{
																																				IL_0343:
																																				if (!isTempleOfAtzoatl)
																																				{
																																					goto IL_02f8;
																																				}
																																				goto IL_033b;
																																				IL_033b:
																																				CheckForTempleDoors = true;
																																				goto IL_0314;
																																				IL_0314:
																																				ilog_0.InfoFormat($"[ExilePather] _checkForTempleDoors = {CheckForTempleDoors} [{id}].", Array.Empty<object>());
																																				goto IL_02fe;
																																				IL_02fe:
																																				while (true)
																																				{
																																					IL_02fe_2:
																																					ilog_0.InfoFormat("[ExilePather] The pathfinder has been reloaded. Now calling 'CheckForUpdates'", Array.Empty<object>());
																																					while (true)
																																					{
																																						IL_02dd:
																																						CheckForUpdates();
																																						ilog_0.InfoFormat("[ExilePather] Now calling 'FastWalkablePositionFor' to prime the library.", Array.Empty<object>());
																																						while (true)
																																						{
																																							IL_02ba:
																																							FastWalkablePositionFor(LokiPoe.LocalData.MyPosition, 5);
																																							ilog_0.InfoFormat("[ExilePather] 'CheckForUpdates' has completed. ExilePather is now ready to use!", Array.Empty<object>());
																																							while (true)
																																							{
																																								IL_02af:
																																								_ = AutoSavePathfindingData;
																																								while (true)
																																								{
																																									IsReady = true;
																																									ExilePatherReloadEvent onExilePatherReload = ExilePather.OnExilePatherReload;
																																									if (onExilePatherReload != null)
																																									{
																																										onExilePatherReload();
																																										switch ((num2 = (num2 * 1646532816) ^ 0x28A8DD21u ^ 0xE3938E3u) % 108u)
																																										{
																																										case 40u:
																																											break;
																																										case 73u:
																																											goto IL_001f;
																																										case 70u:
																																											goto IL_002a;
																																										case 16u:
																																											goto IL_0039;
																																										case 96u:
																																											goto IL_0043;
																																										case 15u:
																																											goto IL_0058;
																																										case 11u:
																																											goto IL_0061;
																																										case 101u:
																																											goto IL_007f;
																																										case 63u:
																																											goto IL_0093;
																																										case 12u:
																																											goto IL_009f;
																																										case 30u:
																																											continue;
																																										default:
																																											return;
																																										case 9u:
																																											goto IL_02af;
																																										case 67u:
																																											goto IL_02ba;
																																										case 37u:
																																											goto IL_02dd;
																																										case 8u:
																																											goto IL_02f8;
																																										case 21u:
																																										case 60u:
																																											goto IL_02fe_2;
																																										case 47u:
																																											goto IL_0314;
																																										case 77u:
																																											goto IL_033b;
																																										case 81u:
																																											goto IL_0343;
																																										case 51u:
																																											goto IL_0349;
																																										case 46u:
																																											goto IL_035f;
																																										case 107u:
																																											goto IL_0365;
																																										case 88u:
																																											goto IL_036f;
																																										case 6u:
																																											goto IL_037b;
																																										case 13u:
																																											goto IL_03a8;
																																										case 7u:
																																											goto IL_03b6;
																																										case 105u:
																																											goto IL_03bc;
																																										case 41u:
																																										case 56u:
																																											goto IL_03e1_2;
																																										case 80u:
																																											goto IL_0405;
																																										case 74u:
																																											goto IL_0418;
																																										case 84u:
																																											goto IL_0422;
																																										case 23u:
																																											goto IL_0437;
																																										case 2u:
																																											goto IL_0440;
																																										case 95u:
																																											goto IL_045e;
																																										case 72u:
																																											goto IL_0472;
																																										case 27u:
																																										case 59u:
																																											goto IL_0479;
																																										case 55u:
																																										case 71u:
																																											goto IL_0487;
																																										case 22u:
																																											goto IL_0494;
																																										case 97u:
																																											goto IL_04d2;
																																										case 1u:
																																											goto IL_04e6;
																																										case 17u:
																																										case 62u:
																																											goto IL_04f8;
																																										case 42u:
																																											goto IL_0504;
																																										case 93u:
																																											goto IL_0512;
																																										case 61u:
																																											goto IL_051a;
																																										case 10u:
																																											goto IL_0523;
																																										case 52u:
																																											goto IL_0539;
																																										case 64u:
																																											goto IL_0541;
																																										case 0u:
																																											goto IL_0573_2;
																																										case 28u:
																																											goto IL_0587;
																																										case 76u:
																																											goto IL_058f;
																																										case 53u:
																																											goto IL_0594;
																																										case 86u:
																																											goto IL_059a_2;
																																										case 65u:
																																											goto IL_05a2;
																																										case 92u:
																																											goto IL_05aa;
																																										case 33u:
																																											goto IL_05af;
																																										case 45u:
																																											goto IL_05bb;
																																										case 31u:
																																											goto IL_05c1_2;
																																										case 3u:
																																											goto IL_05d2;
																																										case 19u:
																																											goto IL_05dc;
																																										case 90u:
																																											goto IL_05e4;
																																										case 20u:
																																											goto end_IL_05e4;
																																										case 68u:
																																											goto IL_060d;
																																										case 66u:
																																											goto IL_0613;
																																										case 32u:
																																											goto IL_063f;
																																										case 39u:
																																											goto IL_064a;
																																										case 57u:
																																											goto IL_0660;
																																										case 25u:
																																											goto IL_0683;
																																										case 44u:
																																											goto IL_0697;
																																										case 91u:
																																											goto IL_06ae;
																																										case 54u:
																																										case 94u:
																																											goto end_IL_0604;
																																										case 50u:
																																											return;
																																										case 98u:
																																											goto IL_06ca;
																																										case 5u:
																																											goto IL_06cf;
																																										case 78u:
																																											return;
																																										case 99u:
																																											goto IL_06da;
																																										case 87u:
																																											goto IL_06e0;
																																										case 82u:
																																											goto IL_0705;
																																										case 14u:
																																											goto IL_0719;
																																										case 43u:
																																											goto IL_071e;
																																										case 79u:
																																											goto IL_0732;
																																										case 103u:
																																											goto IL_073a;
																																										case 104u:
																																											goto IL_0750;
																																										case 106u:
																																											goto IL_075b;
																																										case 102u:
																																											return;
																																										case 26u:
																																											goto IL_0772;
																																										case 58u:
																																											goto IL_0788;
																																										case 18u:
																																											goto IL_079c;
																																										case 83u:
																																											goto IL_07a8;
																																										case 89u:
																																											goto IL_07b9;
																																										case 36u:
																																											goto IL_07cd;
																																										case 34u:
																																											goto IL_07d3;
																																										case 24u:
																																											return;
																																										case 69u:
																																											goto IL_07e8;
																																										case 48u:
																																											goto IL_0808;
																																										case 85u:
																																											return;
																																										case 35u:
																																											goto IL_0810;
																																										case 38u:
																																											goto IL_0816;
																																										case 100u:
																																											goto IL_081c;
																																										case 49u:
																																											return;
																																										case 29u:
																																											goto IL_082a;
																																										case 75u:
																																											goto IL_0830;
																																										case 4u:
																																											return;
																																										}
																																										break;
																																									}
																																									return;
																																								}
																																								break;
																																							}
																																							break;
																																						}
																																						break;
																																					}
																																					break;
																																				}
																																				break;
																																				IL_02f8:
																																				CheckForTempleDoors = false;
																																				goto IL_02fe;
																																			}
																																			break;
																																		}
																																		goto IL_0349;
																																		IL_0750:
																																		IsReady = true;
																																		return;
																																		IL_0349:
																																		string value = labyrinthTrialAreaIds[num];
																																		if (!id.Equals(value, StringComparison.OrdinalIgnoreCase))
																																		{
																																			goto IL_035f;
																																		}
																																		goto IL_060d;
																																		IL_035f:
																																		num++;
																																		continue;
																																		IL_060d:
																																		CheckForAscendancyDoor = true;
																																		goto IL_0613;
																																		IL_0613:
																																		ilog_0.InfoFormat($"[ExilePather] _checkForAscendancyDoor = {CheckForAscendancyDoor} [{id}].", Array.Empty<object>());
																																		if (!isTempleOfAtzoatl)
																																		{
																																			goto IL_063f;
																																		}
																																		goto IL_06da;
																																		IL_063f:
																																		CheckForTempleDoors = false;
																																		goto IL_0705;
																																		IL_06da:
																																		CheckForTempleDoors = true;
																																		goto IL_06e0;
																																		IL_06e0:
																																		ilog_0.InfoFormat($"[ExilePather] _checkForTempleDoors = {CheckForTempleDoors} [{id}].", Array.Empty<object>());
																																		goto IL_0705;
																																		IL_0705:
																																		ilog_0.InfoFormat("[ExilePather] The pathfinder has been reloaded. Now calling 'CheckForUpdates'", Array.Empty<object>());
																																		goto IL_0719;
																																		IL_0719:
																																		CheckForUpdates();
																																		goto IL_071e;
																																		IL_071e:
																																		ilog_0.InfoFormat("[ExilePather] 'CheckForUpdates' has completed. ExilePather is now ready to use!", Array.Empty<object>());
																																		goto IL_0732;
																																		IL_0732:
																																		_ = AutoSavePathfindingData;
																																		goto IL_0750;
																																	}
																																	break;
																																}
																																break;
																															}
																															break;
																															IL_03a8:
																															if (id.Equals("1_5_6"))
																															{
																																goto IL_03b6;
																															}
																															goto IL_03e1;
																															IL_03b6:
																															BlockOssuary_HiddenDoor = true;
																															goto IL_03bc;
																														}
																														break;
																													}
																													goto IL_0418;
																													IL_075b:
																													IsReady = false;
																													_areaHash = 0u;
																													return;
																													IL_0418:
																													if (GameStateController.IsInGameState)
																													{
																														goto IL_0422;
																													}
																													goto IL_073a;
																													IL_0422:
																													if (stopwatch.ElapsedMilliseconds <= 60000L)
																													{
																														goto IL_0437;
																													}
																													goto IL_064a;
																													IL_0437:
																													elapsed = stopwatch.Elapsed;
																													goto IL_0440;
																													IL_0440:
																													if (elapsed.TotalSeconds % 5.0 == 0.0)
																													{
																														goto IL_045e;
																													}
																													goto IL_0472;
																													IL_045e:
																													ilog_0.InfoFormat("[ExilePather] Generating Area map.", Array.Empty<object>());
																													goto IL_0472;
																													IL_0472:
																													Thread.Sleep(10);
																													continue;
																													IL_064a:
																													if (BotManager.Current.Name == "FollowBot")
																													{
																														goto IL_0660;
																													}
																													goto IL_0683;
																													IL_0660:
																													ilog_0.InfoFormat("[ExilePather] PolyPathfinder Generate Area is taking to long, The map data is corrupted, Pls Restart DPB.", Array.Empty<object>());
																													BotManager.Stop(force: true);
																													IsReady = false;
																													goto IL_06ae;
																													IL_06ae:
																													_areaHash = 0u;
																													return;
																													IL_0683:
																													ilog_0.InfoFormat("[ExilePather] PolyPathfinder Generate Area is taking to long, The map data is corrupted, Logging out.", Array.Empty<object>());
																													goto IL_0697;
																													IL_0697:
																													IsReady = false;
																													_areaHash = 0u;
																													LokiPoe.EscapeState.LogoutToTitleScreen();
																													return;
																													IL_073a:
																													ilog_0.InfoFormat("[ExilePather] Height map generator aborted becouse the InGameState returned false, this usually indicate a game server disconnection.", Array.Empty<object>());
																													goto IL_075b;
																												}
																												break;
																											}
																											goto IL_0039;
																											IL_0808:
																											_areaHash = 0u;
																											return;
																											IL_0039:
																											if (GameStateController.IsInGameState)
																											{
																												goto IL_0043;
																											}
																											goto IL_07e8;
																											IL_0043:
																											if (stopwatch.ElapsedMilliseconds <= 60000L)
																											{
																												goto IL_0058;
																											}
																											goto IL_0772;
																											IL_0058:
																											elapsed = stopwatch.Elapsed;
																											goto IL_0061;
																											IL_0061:
																											if (elapsed.TotalSeconds % 5.0 == 0.0)
																											{
																												goto IL_007f;
																											}
																											goto IL_0093;
																											IL_007f:
																											ilog_0.InfoFormat("[ExilePather] Generating Height map.", Array.Empty<object>());
																											goto IL_0093;
																											IL_0093:
																											Thread.Sleep(10);
																											continue;
																											IL_0772:
																											if (!(BotManager.Current.Name == "FollowBot"))
																											{
																												goto IL_0788;
																											}
																											goto IL_07b9;
																											IL_0788:
																											ilog_0.InfoFormat("[ExilePather] Height map generator is taking to long, The map data is corrupted, Logging out.", Array.Empty<object>());
																											goto IL_079c;
																											IL_079c:
																											thread.Abort();
																											IsReady = false;
																											goto IL_07a8;
																											IL_07a8:
																											_areaHash = 0u;
																											LokiPoe.EscapeState.LogoutToTitleScreen();
																											return;
																											IL_07b9:
																											ilog_0.InfoFormat("[ExilePather] Height map generator is taking to long, The map data is corrupted, Pls Restart DPB.", Array.Empty<object>());
																											goto IL_07cd;
																											IL_07cd:
																											thread.Abort();
																											goto IL_07d3;
																											IL_07d3:
																											BotManager.Stop(force: true);
																											IsReady = false;
																											_areaHash = 0u;
																											return;
																											IL_07e8:
																											ilog_0.InfoFormat("[ExilePather] Height map generator aborted becouse the InGameState returned false, this usually indicate a game server disconnection.", Array.Empty<object>());
																											thread.Abort();
																											IsReady = false;
																											goto IL_0808;
																										}
																										break;
																									}
																									break;
																								}
																								break;
																							}
																							break;
																						}
																						goto IL_002a;
																						IL_081c:
																						thread.Abort(false);
																						return;
																						IL_002a:
																						if (GameStateController.IsInGameState)
																						{
																							continue;
																						}
																						goto IL_0810;
																						IL_0810:
																						IsReady = false;
																						goto IL_0816;
																						IL_0816:
																						_areaHash = 0u;
																						goto IL_081c;
																					}
																					break;
																				}
																				break;
																			}
																			break;
																		}
																		break;
																	}
																	break;
																}
																break;
															}
															break;
														}
														break;
													}
													break;
												}
												break;
												IL_0594:
												cachedTerrainData = LokiPoe.TerrainData.Recache;
												goto IL_059a;
											}
											break;
										}
										break;
									}
									break;
									IL_05bb:
									if (force)
									{
										goto IL_05c1;
									}
									goto IL_06ca;
									IL_06ca:
									CheckForUpdates();
									goto IL_06cf;
									IL_06cf:
									IsReady = true;
									return;
								}
								break;
							}
						}
						if (GameStateController.IsInGameState)
						{
							goto IL_001f;
						}
						goto IL_082a;
						IL_0830:
						_areaHash = 0u;
						return;
						IL_082a:
						IsReady = false;
						goto IL_0830;
						IL_001f:
						Thread.Sleep(5);
						continue;
						end_IL_05e4:
						break;
					}
					continue;
					end_IL_0604:
					break;
				}
			}
			IsReady = false;
			_areaHash = 0u;
		}
		catch (Exception)
		{
			ilog_0.ErrorFormat("[ExilePather] Error during Reload, the function will run on next call.", Array.Empty<object>());
			_areaHash = 0u;
			IsReady = false;
		}
	}

	public static bool PathExistsBetween(Vector2i start, Vector2i end, bool dontLeaveFrame = false)
	{
		PathfindingCommand command = new PathfindingCommand(start, end, 15f, avoidWallHugging: false);
		return FindPath(ref command, dontLeaveFrame);
	}

	public static bool FindPath(ref PathfindingCommand command, bool dontLeaveFrame = false)
	{
		if (PolyPathfinder == null)
		{
			throw new Exception("[ExilePather] Cannot use FindPath before Reload is called.");
		}
		return PolyPathfinder.FindPath(ref command);
	}

	public static float PathDistance(Vector2i start, Vector2i end, bool avoidWallHugging = false, bool dontLeaveFrame = false)
	{
		if (PolyPathfinder == null)
		{
			throw new Exception("[ExilePather] Cannot use PathDistance before Reload is called.");
		}
		_ = LokiPoe.LocalData.MyPosition;
		PathfindingCommand command = new PathfindingCommand(start, end, 5f, avoidWallHugging);
		if (!FindPath(ref command, dontLeaveFrame))
		{
			return float.MaxValue;
		}
		float num = start.DistanceF(command.Path[0]);
		for (int i = 1; i < command.Path.Count; i++)
		{
			num += command.Path[i - 1].DistanceF(command.Path[i]);
		}
		return num;
	}

	public static bool IsWalkable(Vector2i arg)
	{
		if (PolyPathfinder == null || !PolyPathfinder.AreaGenerated)
		{
			throw new Exception("[ExilePather] Cannot use IsWalkable before Reload is called.");
		}
		return PolyPathfinder.LiesOnPoly(arg);
	}

	public static bool IsWalkable(int x, int y)
	{
		if (PolyPathfinder == null || !PolyPathfinder.AreaGenerated)
		{
			throw new Exception("[ExilePather] Cannot use IsWalkable before Reload is called.");
		}
		return PolyPathfinder.LiesOnPoly(new Vector2i(x, y));
	}

	public static void ClearWalkablePositionCache()
	{
		walkablePositionDictionary.Clear();
	}

	public static Vector2i FastWalkablePositionFor(NetworkObject obj, int range = 30, bool cache = true)
	{
		return FastWalkablePositionFor(obj.Position, range, cache);
	}

	private static bool smethod_2(CachedTerrainData cachedTerrainData_0, Vector2i vector2i_0)
	{
		if (vector2i_0.X >= 0 && vector2i_0.Y >= 0)
		{
			if (vector2i_0.X < cachedTerrainData_0.Cols * 23)
			{
				return vector2i_0.Y < cachedTerrainData_0.Rows * 23;
			}
			return false;
		}
		return false;
	}

	private static double getAngleBetweenPoints(Vector2 pt1, Vector2 pt2)
	{
		return Math.Atan2(pt2.Y - pt1.Y, pt2.X - pt1.X);
	}

	private static Vector2i GetPointOnCircle(Vector2i center, double radian, double radius)
	{
		Vector2i result = default(Vector2i);
		result.X = center.X + (int)(radius * Math.Cos(radian));
		result.Y = center.Y + (int)(radius * Math.Sin(radian));
		return result;
	}

	internal static Vector2i FindWalkableForAngle(Vector2i pos, double radiants, int range = 30)
	{
		_ = Vector2i.Zero;
		for (int i = 5; i < range; i++)
		{
			Vector2i pointOnCircle = GetPointOnCircle(pos, radiants, i);
			if (smethod_2(LokiPoe.TerrainData.Cache, pointOnCircle) && WalkabilityGrid.IsWalkable(LokiPoe.TerrainData.Cache, pointOnCircle.X, pointOnCircle.Y, 2) && (!UseWalkableCheck || IsWalkable(pointOnCircle.X, pointOnCircle.Y)))
			{
				return pointOnCircle;
			}
		}
		return Vector2i.Zero;
	}

	public static Vector2i FastWalkablePositionFor(Vector2i pos, int range = 30, bool cache = true)
	{
		if (cache && walkablePositionDictionary.TryGetValue(pos, out var value))
		{
			return value;
		}
		List<Vector2i> list = new List<Vector2i>();
		Vector2i position = LokiPoe.ObjectManager.Me.Position;
		double angleBetweenPoints = getAngleBetweenPoints(pos.ToVector2(), position.ToVector2());
		for (double num = 0.0; num <= 3.14; num += 0.628)
		{
			if (list.Count >= 3)
			{
				break;
			}
			double radiants = ((num + angleBetweenPoints > 6.28) ? (num + angleBetweenPoints - 6.28) : (num + angleBetweenPoints));
			Vector2i vector2i = FindWalkableForAngle(pos, radiants, range);
			if (vector2i != Vector2i.Zero)
			{
				list.Add(vector2i);
			}
			if (num != 0.0)
			{
				double radiants2 = ((num - angleBetweenPoints < 0.0) ? (num - angleBetweenPoints + 6.28) : (num - angleBetweenPoints));
				Vector2i vector2i2 = FindWalkableForAngle(pos, radiants2, range);
				if (vector2i2 != Vector2i.Zero)
				{
					list.Add(vector2i2);
				}
			}
		}
		if (list.Any())
		{
			list.Shuffle();
			Vector2i vector2i3 = list.First();
			if (!walkablePositionDictionary.ContainsKey(pos))
			{
				walkablePositionDictionary.Add(pos, vector2i3);
			}
			return vector2i3;
		}
		return Vector2i.Zero;
	}

	public static void SignalObstacleUpdate()
	{
		ExilePather.OnObstacleUpdate?.Invoke();
	}
}
