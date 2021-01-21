﻿using STRINGS;
using System.Collections.Generic;

namespace Blueprints {
    public sealed class UseBlueprintToolHoverCard : HoverTextConfiguration {
        public int PrefabErrorCount = 0;

        public UseBlueprintToolHoverCard() {
            ToolName = Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_TOOLTIP_TITLE);
        }

        public override void UpdateHoverElements(List<KSelectable> hoveredObjects) {
            HoverTextScreen screenInstance = HoverTextScreen.Instance;
            HoverTextDrawer drawer = screenInstance.BeginDrawing();
            drawer.BeginShadowBar(false);

            DrawTitle(screenInstance, drawer);
            drawer.NewLine(26);

            drawer.DrawIcon(screenInstance.GetSprite("icon_mouse_left"), 20);
            drawer.DrawText(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_ACTION_CLICK), Styles_Instruction.Standard);
            drawer.AddIndent(8);

            drawer.DrawIcon(screenInstance.GetSprite("icon_mouse_right"), 20);
            drawer.DrawText(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_ACTION_BACK), Styles_Instruction.Standard);
            drawer.NewLine(32);

            if (BlueprintsState.HasBlueprints()) {
                if (BlueprintsState.SelectedFolder.BlueprintCount > 0) {
                    drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_CYCLEFOLDERS), UI.FormatAsHotkey("[" + GameUtil.GetActionString(BlueprintsAssets.BLUEPRINTS_USE_CYCLEFOLDERS_NEXT.GetKAction()) + "]"), UI.FormatAsHotkey("[" + GameUtil.GetActionString(BlueprintsAssets.BLUEPRINTS_USE_CYCLEFOLDERS_PREVIOUS.GetKAction()) + "]")), Styles_Instruction.Standard);
                    drawer.NewLine(20);

                    drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_CYCLEBLUEPRINTS), UI.FormatAsHotkey("[" + GameUtil.GetActionString(BlueprintsAssets.BLUEPRINTS_USE_CYCLEBLUEPRINTS_NEXT.GetKAction()) + "]"), UI.FormatAsHotkey("[" + GameUtil.GetActionString(BlueprintsAssets.BLUEPRINTS_USE_CYCLEBLUEPRINTS_PREVIOUS.GetKAction()) + "]")), Styles_Instruction.Standard);
                    drawer.NewLine(32);

                    drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_FOLDERBLUEPRINT), UI.FormatAsHotkey("[" + GameUtil.GetActionString(BlueprintsAssets.BLUEPRINTS_USE_CREATEFOLDER.GetKAction()) + "]")), Styles_Instruction.Standard);
                    drawer.NewLine(20);

                    drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_NAMEBLUEPRINT), UI.FormatAsHotkey("[" + GameUtil.GetActionString(BlueprintsAssets.BLUEPRINTS_USE_RENAME.GetKAction()) + "]")), Styles_Instruction.Standard);
                    drawer.NewLine(20);

                    drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_DELETEBLUEPRINT), UI.FormatAsHotkey("[" + GameUtil.GetActionString(BlueprintsAssets.BLUEPRINTS_MULTI_DELETE.GetKAction()) + "]")), Styles_Instruction.Standard);

                    if (PrefabErrorCount > 0) {
                        drawer.NewLine(32);
                        drawer.DrawIcon(screenInstance.GetSprite("iconWarning"), 18);
                        drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_ERRORMESSAGE), PrefabErrorCount), Styles_Instruction.Selected);
                    }

                    drawer.NewLine(32);
                    drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_SELECTEDBLUEPRINT), BlueprintsState.SelectedBlueprint.FriendlyName, BlueprintsState.SelectedFolder.SelectedBlueprintIndex + 1, BlueprintsState.SelectedFolder.BlueprintCount, BlueprintsState.SelectedFolder.Name, BlueprintsState.SelectedBlueprintFolderIndex + 1, BlueprintsState.LoadedBlueprints.Count), Styles_Instruction.Standard);
                }

                else {
                    drawer.DrawText(string.Format(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_FOLDEREMPTY), BlueprintsState.SelectedFolder.Name), Styles_Instruction.Standard);
                }
            }

            else {
                drawer.DrawText(Strings.Get(BlueprintsStrings.STRING_BLUEPRINTS_USE_NOBLUEPRINTS), Styles_Instruction.Standard);
            }

            drawer.EndShadowBar();
            drawer.EndDrawing();
        }
    }
}
