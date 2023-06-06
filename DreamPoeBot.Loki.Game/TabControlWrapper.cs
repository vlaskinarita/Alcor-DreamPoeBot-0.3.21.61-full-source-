using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.NativeWrappers;
using DreamPoeBot.Loki.Game.Std;
using log4net;

namespace DreamPoeBot.Loki.Game;

public class TabControlWrapper : RemoteMemoryObject
{
	internal class ClassTabData
	{
		public long IntPtr_0 { get; }

		public long IntPtr_1 { get; }

		public string Name { get; }

		internal ClassTabData(Struct110 entry)
		{
			IntPtr_0 = entry.intptr_0;
			IntPtr_1 = entry.intptr_1;
			Name = Containers.StdStringWCustom(entry.nativeStringW_0);
		}

		public new virtual bool Equals(object obj)
		{
			if (obj is ClassTabData classTabData && IntPtr_1 == classTabData.IntPtr_1 && IntPtr_0 == classTabData.IntPtr_0)
			{
				return Name.Equals(classTabData.Name);
			}
			return false;
		}

		public bool method_0(ClassTabData class258_0)
		{
			if (class258_0 != null && IntPtr_1 == class258_0.IntPtr_1 && IntPtr_0 == class258_0.IntPtr_0)
			{
				return Name.Equals(class258_0.Name);
			}
			return false;
		}

		public new virtual int GetHashCode()
		{
			return IntPtr_0.GetHashCode() ^ IntPtr_1.GetHashCode() ^ Name.GetHashCode();
		}
	}

	private sealed class Class259
	{
		public static readonly Class259 Class9 = new Class259();

		public static Func<Struct110, ClassTabData> Method9__45_0;

		public static Func<ClassTabData, string> Method9__47_0;

		internal ClassTabData method_0(Struct110 struct110_0)
		{
			return new ClassTabData(struct110_0);
		}

		internal string method_1(ClassTabData class258_0)
		{
			return class258_0.Name;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct110
	{
		public readonly long intptr_0;

		public readonly long intptr_1;

		public readonly NativeStringWCustom nativeStringW_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Struct111
	{
		private readonly long vtable;

		private readonly long intptr_0;

		private readonly long intptr_1;

		private readonly long intptr_2;

		private readonly long intptr_3;

		private readonly long intptr_4;

		private readonly long intptr_5;

		private readonly long intptr_6;

		private readonly long intptr_7;

		private readonly long intptr_8;

		private readonly long intptr_9;

		private readonly long intptr_10;

		public readonly NativeVector List_0;

		public readonly int CurrentTabIndex;

		public readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		public readonly int int_1;

		public readonly byte byte_4;

		private readonly byte byte_5;

		private readonly byte byte_6;

		private readonly byte byte_7;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private TabControlType _tabControlType { get; set; }

	public int CurrentTabIndex
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return Struct111_0.CurrentTabIndex;
			}
			if (_tabControlType != TabControlType.Parchase)
			{
				if (_tabControlType == TabControlType.Social)
				{
					return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.IndexVisibleStash;
				}
				if (_tabControlType != TabControlType.ExpeditionDealer)
				{
					if (_tabControlType != TabControlType.BloodCrucible)
					{
						return Struct111_0.CurrentTabIndex;
					}
					return -1;
				}
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IndexVisibleStash;
			}
			return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash;
		}
	}

	public string CurrentTabName
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return Class258_0?.Name;
			}
			if (_tabControlType != TabControlType.Parchase)
			{
				if (_tabControlType != TabControlType.Social)
				{
					if (_tabControlType == TabControlType.ExpeditionDealer)
					{
						return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName;
					}
					return Class258_0?.Name;
				}
				return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.VisibleStashName;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName;
			}
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.VisibleStashName;
		}
	}

	public bool IsOnFirstTab
	{
		get
		{
			if (CurrentTabIndex == 0)
			{
				return true;
			}
			if (_tabControlType != 0)
			{
				return false;
			}
			if (!LokiPoe.InGameState.StashUi.HideRemoveOnlyTabs)
			{
				return false;
			}
			IEnumerable<StashTabInfo> source = LokiPoe.InstanceInfo.StashTabs.Where((StashTabInfo x) => !x.IsHiddenFlagged);
			int i;
			for (i = CurrentTabIndex - 1; i >= 0; i--)
			{
				StashTabInfo stashTabInfo = source.FirstOrDefault((StashTabInfo x) => x.DisplayIndex == i);
				if (stashTabInfo != null && !stashTabInfo.IsRemoveOnlyFlagged)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool IsOnLastTab
	{
		get
		{
			if (CurrentTabIndex == LastTabIndex)
			{
				return true;
			}
			if (_tabControlType == TabControlType.Stash)
			{
				if (LokiPoe.InGameState.StashUi.HideRemoveOnlyTabs)
				{
					IEnumerable<StashTabInfo> source = LokiPoe.InstanceInfo.StashTabs.Where((StashTabInfo x) => !x.IsHiddenFlagged);
					int i;
					for (i = CurrentTabIndex + 1; i <= LastTabIndex; i++)
					{
						StashTabInfo stashTabInfo = source.FirstOrDefault((StashTabInfo x) => x.DisplayIndex == i);
						if (stashTabInfo != null && !stashTabInfo.IsRemoveOnlyFlagged)
						{
							return false;
						}
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public int LastTabIndex
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return List_0.Count - 1;
			}
			if (_tabControlType == TabControlType.Parchase)
			{
				if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
				{
					return (int)GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.TotalStashes - 1;
				}
				return (int)GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.TotalStashes - 1;
			}
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType == TabControlType.ExpeditionDealer)
				{
					return (int)GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.TotalStashes - 1;
				}
				return List_0.Count - 1;
			}
			return (int)GameController.Instance.Game.IngameState.IngameUi.SocialPannel.TotalStashes - 1;
		}
	}

	public List<string> TabNames
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return List_1.Select(Class259.Class9.method_1).ToList();
			}
			if (_tabControlType == TabControlType.Parchase)
			{
				if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
				{
					return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.AllStashNames;
				}
				return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.AllStashNames;
			}
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType == TabControlType.ExpeditionDealer)
				{
					return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.AllStashNames;
				}
				return List_1.Select(Class259.Class9.method_1).ToList();
			}
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.AllStashNames;
		}
	}

	public bool IsTabsMenuVisible
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerElement.IsVisible;
			}
			return false;
		}
	}

	internal byte Byte_0 => Struct111_0.byte_0;

	internal int Int32_0 => Struct111_0.int_1;

	internal byte Byte_1 => Struct111_0.byte_4;

	internal ClassTabData Class258_0 => GetTabDataByIndex(CurrentTabIndex);

	internal List<Struct110> List_0 => Containers.StdStructTab110Vector<Struct110>(Struct111_0.List_0);

	private List<ClassTabData> List_1 => List_0.Select(Class259.Class9.method_0).ToList();

	public Struct111 Struct111_0 => base.M.FastIntPtrToStruct<Struct111>(base.Address + 2408L);

	public TabControlWrapper(TabControlType type)
	{
		_tabControlType = type;
	}

	internal void SpecialSetMousePosition(Vector2i pos)
	{
		MouseManager.SetMousePosition(pos, useRandomPos: false);
	}

	internal TabControlWrapper(long control, TabControlType type)
		: base(control)
	{
		_tabControlType = type;
	}

	public bool IsTabVisible(string name)
	{
		if (_tabControlType == TabControlType.Stash)
		{
			return CurrentTabName == name;
		}
		if (_tabControlType != TabControlType.Parchase)
		{
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType != TabControlType.ExpeditionDealer)
				{
					return CurrentTabName == name;
				}
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName == name;
			}
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.VisibleStashName == name;
		}
		if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
		{
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.VisibleStashName == name;
		}
		return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName == name;
	}

	public bool IsTabVisible(int index)
	{
		if (_tabControlType == TabControlType.Stash)
		{
			return CurrentTabIndex == index;
		}
		if (_tabControlType == TabControlType.Parchase)
		{
			if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash == index;
			}
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IndexVisibleStash == index;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (_tabControlType == TabControlType.ExpeditionDealer)
			{
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash == index;
			}
			return CurrentTabIndex == index;
		}
		return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.IndexVisibleStash == index;
	}

	public SwitchToTabResult NextTabKeyboard()
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (Hooking.IsInstalled)
			{
				HookManager.ResetKeyState();
				int currentTabIndex = CurrentTabIndex;
				if (currentTabIndex == LastTabIndex)
				{
					return SwitchToTabResult.NoMoreTabs;
				}
				LokiPoe.Input.SimulateKeyEvent(Keys.Right);
				Thread.Sleep(25);
				if (CurrentTabIndex != currentTabIndex)
				{
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.Failed;
			}
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		return SwitchToTabResult.NotSupported;
	}

	public SwitchToTabResult PreviousTabKeyboard()
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (!Hooking.IsInstalled)
		{
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		int currentTabIndex = CurrentTabIndex;
		if (currentTabIndex != 0)
		{
			LokiPoe.Input.SimulateKeyEvent(Keys.Left);
			Thread.Sleep(25);
			if (CurrentTabIndex == currentTabIndex)
			{
				return SwitchToTabResult.Failed;
			}
			return SwitchToTabResult.None;
		}
		return SwitchToTabResult.NoMoreTabs;
	}

	public SwitchToTabResult SwitchToTabKeyboard(int index)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (index >= 0 && index <= LastTabIndex)
		{
			if (CurrentTabIndex < index)
			{
				while (true)
				{
					if (CurrentTabIndex != index)
					{
						SwitchToTabResult switchToTabResult = NextTabKeyboard();
						Thread.Sleep(15);
						if (CurrentTabIndex == index)
						{
							break;
						}
						if (switchToTabResult != 0)
						{
							return switchToTabResult;
						}
						continue;
					}
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.None;
			}
			SwitchToTabResult switchToTabResult2;
			do
			{
				if (CurrentTabIndex != index)
				{
					switchToTabResult2 = PreviousTabKeyboard();
					Thread.Sleep(15);
					if (CurrentTabIndex == index)
					{
						return SwitchToTabResult.None;
					}
					continue;
				}
				return SwitchToTabResult.None;
			}
			while (switchToTabResult2 == SwitchToTabResult.None);
			return switchToTabResult2;
		}
		return SwitchToTabResult.Failed;
	}

	public SwitchToTabResult SwitchToTabKeyboard(string name)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (!TabNames.Contains(name))
		{
			return SwitchToTabResult.Failed;
		}
		ClassTabData tabDataByName = GetTabDataByName(name);
		if (tabDataByName != null)
		{
			int indexByTabData = GetIndexByTabData(tabDataByName);
			if (indexByTabData != -1)
			{
				if (CurrentTabIndex < indexByTabData)
				{
					SwitchToTabResult switchToTabResult;
					do
					{
						if (CurrentTabIndex != indexByTabData)
						{
							switchToTabResult = NextTabKeyboard();
							Thread.Sleep(15);
							if (CurrentTabIndex == indexByTabData)
							{
								return SwitchToTabResult.None;
							}
							continue;
						}
						return SwitchToTabResult.None;
					}
					while (switchToTabResult == SwitchToTabResult.None);
					return switchToTabResult;
				}
				while (true)
				{
					if (CurrentTabIndex != indexByTabData)
					{
						SwitchToTabResult switchToTabResult2 = PreviousTabKeyboard();
						Thread.Sleep(15);
						if (CurrentTabIndex == indexByTabData)
						{
							break;
						}
						if (switchToTabResult2 != 0)
						{
							return switchToTabResult2;
						}
						continue;
					}
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.None;
			}
			return SwitchToTabResult.TabNotFound;
		}
		return SwitchToTabResult.TabNotFound;
	}

	public SwitchToTabResult SwitchToTabMouse(int index)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (!Hooking.IsInstalled)
			{
				return SwitchToTabResult.ProcessHookManagerNotEnabled;
			}
			HookManager.ResetKeyState();
			ClassTabData tabDataByIndex = GetTabDataByIndex(index);
			if (tabDataByIndex != null)
			{
				return SwitchToTabMouse(tabDataByIndex.Name);
			}
			return SwitchToTabResult.Failed;
		}
		return SwitchToTabResult.NotSupported;
	}

	public SwitchToTabResult SwitchToTabMouse(string name)
	{
		if (_tabControlType != TabControlType.World)
		{
			if (_tabControlType == TabControlType.Social)
			{
				return SwitchToTabResult.NotSupported;
			}
			if (Hooking.IsInstalled)
			{
				HookManager.ResetKeyState();
				if (!TabNames.Contains(name))
				{
					return SwitchToTabResult.TabNotFound;
				}
				int num = 0;
				while (GameController.Instance.Game.IngameState.IngameUi.StashPannel.IsTabListButtonVisible && !IsTabsMenuVisible)
				{
					Vector2i pos = GameController.Instance.Game.IngameState.IngameUi.StashPannel.TabListButton.CenterClickLocation();
					SpecialSetMousePosition(pos);
					Thread.Sleep(50);
					MouseManager.ClickLMB(pos.X, pos.Y);
					Thread.Sleep(50);
					if (IsTabsMenuVisible || num >= 3)
					{
						break;
					}
					num++;
				}
				Vector2i pos2;
				if (!IsTabsMenuVisible)
				{
					Element element = GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabsContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name);
					if (element == null)
					{
						return SwitchToTabResult.TabNotFound;
					}
					pos2 = element.CenterClickLocation();
				}
				else
				{
					Element element2 = GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightButtonContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name);
					if (element2 == null)
					{
						return SwitchToTabResult.UnableToFindTabInScrollView;
					}
					int num2 = 0;
					while (true)
					{
						num2++;
						float num3 = element2.Parent.Parent.Y + element2.Parent.Parent.Height;
						if (num2 >= 50)
						{
							break;
						}
						if (num3 + GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset <= 0f)
						{
							MouseManager.SetMousePosition(LokiPoe.ElementClickLocation(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerScrollUp));
							Thread.Sleep(5);
							MouseManager.ClickLMB();
							Thread.Sleep(5);
							continue;
						}
						if (!(num3 + GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset > GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerHeight))
						{
							break;
						}
						MouseManager.SetMousePosition(LokiPoe.ElementClickLocation(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerScrollDown));
						Thread.Sleep(5);
						MouseManager.ClickLMB();
						Thread.Sleep(5);
					}
					pos2 = element2.CenterClickLocation() + new Vector2i(0, (int)(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset * element2.Scale));
				}
				SpecialSetMousePosition(pos2);
				Thread.Sleep(10);
				MouseManager.ClickLMB(pos2.X, pos2.Y);
				Thread.Sleep(50);
				if (CurrentTabName == name)
				{
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.Failed;
			}
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		return SwitchToTabResult.NotSupported;
	}

	public OpenPremiumStashSettingResult OpenPremiumStashSetting(string name)
	{
		string name2;
		uint num = default(uint);
		int num3 = default(int);
		Element element = default(Element);
		Vector2i vector2i = default(Vector2i);
		Vector2i pos = default(Vector2i);
		while (true)
		{
			name2 = name;
			while (true)
			{
				if (_tabControlType != TabControlType.World)
				{
					while (true)
					{
						if (_tabControlType != TabControlType.Social)
						{
							while (true)
							{
								if (Hooking.IsInstalled)
								{
									while (true)
									{
										HookManager.ResetKeyState();
										while (true)
										{
											if (TabNames.Contains(name2))
											{
												while (true)
												{
													IL_0112:
													SwitchToTabResult switchToTabResult = SwitchToTabKeyboard(name2);
													if (switchToTabResult != 0)
													{
														while (true)
														{
															switch (switchToTabResult)
															{
															case SwitchToTabResult.ProcessHookManagerNotEnabled:
																goto IL_0172;
															case SwitchToTabResult.Failed:
																goto IL_0174;
															case SwitchToTabResult.UiNotOpen:
																goto IL_0176;
															case SwitchToTabResult.TabListNotOpen:
																goto IL_0178;
															case SwitchToTabResult.TabNotFound:
																goto IL_017a;
															case SwitchToTabResult.FailedToOpenTabList:
																goto IL_017c;
															case SwitchToTabResult.UnableToFindTabInScrollView:
																goto IL_017e;
															case SwitchToTabResult.NoMoreTabs:
																goto IL_0181;
															case SwitchToTabResult.NotSupported:
																goto IL_0184;
															case SwitchToTabResult.None:
																goto end_IL_00df;
															}
															int num2 = (int)((num * 1777358890) ^ 0x227AD241);
															while (true)
															{
																switch ((num = (uint)num2 ^ 0xABF71F4Cu) % 40u)
																{
																case 19u:
																	num2 = (int)((num * 553622637) ^ 0x3007020E);
																	continue;
																case 11u:
																	break;
																case 9u:
																	goto IL_0112;
																case 2u:
																	goto end_IL_0112;
																case 18u:
																	goto end_IL_0124;
																case 26u:
																	goto end_IL_013c;
																case 25u:
																	goto end_IL_0143;
																case 33u:
																	goto end_IL_014c;
																case 3u:
																case 29u:
																	goto end_IL_015a;
																case 14u:
																	goto IL_016e;
																case 16u:
																	goto IL_0170;
																case 24u:
																	goto IL_0172;
																case 22u:
																	goto IL_0174;
																case 31u:
																	goto IL_0176;
																case 38u:
																	goto IL_0178;
																case 32u:
																	goto IL_017a;
																case 0u:
																	goto IL_017c;
																case 23u:
																	goto IL_017e;
																case 17u:
																	goto IL_0181;
																case 1u:
																	goto IL_0184;
																case 5u:
																	goto end_IL_00df;
																case 8u:
																	goto IL_018d;
																case 13u:
																	goto IL_0199;
																case 15u:
																	goto IL_01a5;
																case 36u:
																	goto IL_01a7;
																case 35u:
																	goto IL_01ae;
																case 27u:
																	goto IL_01ea;
																case 34u:
																	goto IL_01f2;
																case 7u:
																	goto IL_0227;
																case 28u:
																	goto IL_0236;
																case 20u:
																	goto IL_0257;
																case 12u:
																	goto IL_025b;
																case 4u:
																	goto IL_0262;
																case 39u:
																	goto IL_0269;
																case 10u:
																	goto IL_026b;
																default:
																	goto IL_026d;
																case 37u:
																	goto IL_026f;
																case 21u:
																	goto IL_0271;
																case 6u:
																	goto IL_0273;
																}
																break;
															}
															continue;
															IL_0174:
															return OpenPremiumStashSettingResult.Failed;
															IL_0172:
															return OpenPremiumStashSettingResult.ProcessHookManagerNotEnabled;
															IL_0184:
															return OpenPremiumStashSettingResult.NotSupported;
															IL_0181:
															return OpenPremiumStashSettingResult.NoMoreTabs;
															IL_017e:
															return OpenPremiumStashSettingResult.UnableToFindTabInScrollView;
															IL_017c:
															return OpenPremiumStashSettingResult.FailedToOpenTabList;
															IL_017a:
															return OpenPremiumStashSettingResult.TabNotFound;
															IL_0178:
															return OpenPremiumStashSettingResult.TabListNotOpen;
															IL_0176:
															return OpenPremiumStashSettingResult.UiNotOpen;
															continue;
															end_IL_00df:
															break;
														}
													}
													Thread.Sleep(100);
													goto IL_018d;
													IL_026f:
													return OpenPremiumStashSettingResult.TabNotFound;
													IL_026d:
													return OpenPremiumStashSettingResult.None;
													IL_018d:
													if (LokiPoe.InGameState.StashUi.StashTabInfo.IsNormalTab)
													{
														goto IL_0199;
													}
													goto IL_01a7;
													IL_0199:
													if (!LokiPoe.InGameState.StashUi.StashTabInfo.IsPremium)
													{
														goto IL_01a5;
													}
													goto IL_01a7;
													IL_01a5:
													return OpenPremiumStashSettingResult.NotPremiumStash;
													IL_01a7:
													num3 = 0;
													goto IL_025b;
													IL_025b:
													if (num3 <= 3)
													{
														goto IL_01ae;
													}
													goto IL_0262;
													IL_0262:
													if (!LokiPoe.InGameState.PremiumStashSettingsUi.IsOpened)
													{
														goto IL_0269;
													}
													goto IL_026b;
													IL_0269:
													return OpenPremiumStashSettingResult.Failed;
													IL_026b:
													return OpenPremiumStashSettingResult.None;
													IL_01ae:
													element = GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabsContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name2);
													if (!(element == null))
													{
														goto IL_01ea;
													}
													goto IL_026f;
													IL_01ea:
													vector2i = element.CenterClickLocation();
													goto IL_01f2;
													IL_01f2:
													pos = new Vector2i(vector2i.X + (int)GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabContainerXOffset, vector2i.Y);
													goto IL_0227;
													IL_0227:
													SpecialSetMousePosition(pos);
													Thread.Sleep(100);
													goto IL_0236;
													IL_0236:
													MouseManager.ClickRMB(vector2i.X, vector2i.Y);
													Thread.Sleep(100);
													if (!LokiPoe.InGameState.PremiumStashSettingsUi.IsOpened)
													{
														goto IL_0257;
													}
													goto IL_026d;
													IL_0257:
													num3++;
													goto IL_025b;
													continue;
													end_IL_0112:
													break;
												}
												continue;
											}
											goto IL_0271;
											IL_0271:
											return OpenPremiumStashSettingResult.Failed;
											continue;
											end_IL_0124:
											break;
										}
										continue;
										end_IL_013c:
										break;
									}
									continue;
								}
								goto IL_016e;
								IL_016e:
								return OpenPremiumStashSettingResult.ProcessHookManagerNotEnabled;
								continue;
								end_IL_0143:
								break;
							}
							continue;
						}
						goto IL_0273;
						IL_0273:
						return OpenPremiumStashSettingResult.NotSupported;
						continue;
						end_IL_014c:
						break;
					}
					continue;
				}
				goto IL_0170;
				IL_0170:
				return OpenPremiumStashSettingResult.NotSupported;
				continue;
				end_IL_015a:
				break;
			}
		}
	}

	private bool IsRemoveOnly(InventoryTabFlags flag)
	{
		return (flag & InventoryTabFlags.RemoveOnly) == InventoryTabFlags.RemoveOnly;
	}

	private bool IsHidden(InventoryTabFlags flag)
	{
		return (flag & InventoryTabFlags.Hidden) == InventoryTabFlags.Hidden;
	}

	private int GetIndexByTabData(ClassTabData class258_0)
	{
		if (class258_0 == null)
		{
			return -1;
		}
		List<ClassTabData> list_ = List_1;
		for (int i = 0; i < list_.Count; i++)
		{
			if (list_[i].IntPtr_0 == class258_0.IntPtr_0 && list_[i].IntPtr_1 == class258_0.IntPtr_1 && list_[i].Name == class258_0.Name)
			{
				return i;
			}
		}
		return -1;
	}

	private ClassTabData GetTabDataByIndex(int index)
	{
		List<ClassTabData> list_ = List_1;
		if (index >= 0 && index < list_.Count)
		{
			return list_[index];
		}
		return null;
	}

	private ClassTabData GetTabDataByName(string name)
	{
		return List_1.FirstOrDefault((ClassTabData x) => x.Name.Equals(name));
	}
}
